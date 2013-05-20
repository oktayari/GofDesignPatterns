using System;
using System.Configuration;
using System.Diagnostics;

namespace GoFPatternsLibAdv.CreationalPatterns
{
    //The essence of the Abstract Factory Pattern is to "Provide an interface for 
    //creating families of related or dependent objects without specifying their concrete classes"
    internal class AbstractFactory
    {
        public class Application
        {
            public Application(IGuiFactory factory)
            {
                IButton button = factory.CreateButton();
                button.Paint();
            }
        }

        public class ApplicationRunner
        {
            private static IGuiFactory CreateOsSpecificFactory()
            {
                // Executes second
                // Contents of App.Config associated with this C# project
                //<?xml version="1.0" encoding="utf-8" ?>
                //<configuration>
                //  <appSettings>
                //    <!-- Uncomment either Win or OSX OS_TYPE to test -->
                //    <add key="OS_TYPE" value="Win" />
                //    <!-- <add key="OS_TYPE" value="OSX" /> -->
                //  </appSettings>
                //</configuration>

                Debug.Assert(ConfigurationSettings.AppSettings != null, "ConfigurationSettings.AppSettings != null");
                string sysType = ConfigurationSettings.AppSettings["OS_TYPE"];

                if (sysType == "Win")
                    return new WinFactory();


                return new OsxFactory();
            }

            public void AbstracfactoryTester()
            {
                new Application(CreateOsSpecificFactory());
                Console.ReadLine();
            }
        }

        public interface IButton
        {
            void Paint();
        }

        public interface IGuiFactory
        {
            IButton CreateButton();
        }

        public class OsxButton : IButton
        {
            // Executes fourth if OS:OSX
            public void Paint()
            {
                Console.WriteLine("I'm an OSXButton");
            }
        }

        public class OsxFactory : IGuiFactory
        {
            // Executes third if OS:OSX
            IButton IGuiFactory.CreateButton()
            {
                return new OsxButton();
            }
        }

        public class WinButton : IButton
        {
            // Executes fourth if OS:WIN
            public void Paint()
            {
                Console.WriteLine("I'm a WinButton");
            }
        }

        public class WinFactory : IGuiFactory
        {
            // Executes third if OS:WIN
            IButton IGuiFactory.CreateButton()
            {
                return new WinButton();
            }
        }
    }
}