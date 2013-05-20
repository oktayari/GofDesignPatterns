using System;
using System.Collections.Generic;

namespace GoFPatternsLibAdv.BehavioralPatterns
{
    /// <summary>
    ///     the command pattern is a behavioral design pattern in which an object is used
    ///     to represent and encapsulate all the information needed to call a method at a later time.
    ///     This information includes the method name,
    ///     the object that owns the method and values for the method parameters.
    /// </summary>
    internal class CommandPattern
    {
        public void TestCommand(string[] args)
        {
            var lamp = new Light();
            ICommand switchUp = new FlipUpCommand(lamp);
            ICommand switchDown = new FlipDownCommand(lamp);

            var s = new Switch();
            string arg = args.Length > 0 ? args[0].ToUpper() : null;
            if (arg == "ON")
            {
                s.StoreAndExecute(switchUp);
            }
            else if (arg == "OFF")
            {
                s.StoreAndExecute(switchDown);
            }
            else
            {
                Console.WriteLine("Argument \"ON\" or \"OFF\" is required.");
            }
        }

        public class FlipDownCommand : ICommand
        {
            private readonly Light _light;

            public FlipDownCommand(Light light)
            {
                _light = light;
            }

            public void Execute()
            {
                _light.TurnOff();
            }
        }

        public class FlipUpCommand : ICommand
        {
            private readonly Light _light;

            public FlipUpCommand(Light light)
            {
                _light = light;
            }

            public void Execute()
            {
                _light.TurnOn();
            }
        }

        public interface ICommand
        {
            void Execute();
        }

        /* The Invoker class */

        /* The Receiver class */

        public class Light
        {
            public void TurnOn()
            {
                Console.WriteLine("The light is on");
            }

            public void TurnOff()
            {
                Console.WriteLine("The light is off");
            }
        }

        public class Switch
        {
            private readonly List<ICommand> _commands = new List<ICommand>();

            public void StoreAndExecute(ICommand command)
            {
                _commands.Add(command);
                command.Execute();
            }
        }

        /* The Command for turning on the light - ConcreteCommand #1 */
    }
}