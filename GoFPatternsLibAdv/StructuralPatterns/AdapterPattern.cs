using System;
using System.Collections.Generic;

namespace GoFPatternsLibAdv.StructuralPatterns
{
    /// <summary>
    ///     the adapter pattern (often referred to as the wrapper pattern or simply a wrapper)
    ///     is a design pattern that translates one interface for a class into a compatible interfac
    /// </summary>
    internal class AdapterPattern
    {
        //from the existing library, does not need to be changed


        public void TestAdapter()
        {
            var list = new List<IEmployee>();
            list.Add(new Employee("Tom"));
            list.Add(new Employee("Jerry"));
            list.Add(new ConsultantToEmployeeAdapter("Bruno")); //consultant from existing class
            ShowHappiness(list);
        }

        //*** Code below from the existing library does not need to be changed ***
        public void ShowHappiness(List<IEmployee> list)
        {
            foreach (IEmployee i in list)
                i.ShowHappiness();
        }

        public class Consultant
        {
            private readonly string _name;

            public Consultant(string name)
            {
                _name = name;
            }

            protected void ShowSmile()
            {
                Console.WriteLine("Consultant " + _name + " showed smile");
            }
        }

        public class ConsultantToEmployeeAdapter : Consultant, IEmployee
        {
            public ConsultantToEmployeeAdapter(string name)
                : base(name)
            {
            }

            void IEmployee.ShowHappiness()
            {
                ShowSmile(); //call the parent Consultant class
            }
        }

        public class Employee : IEmployee
        {
            private readonly string _name;

            public Employee(string name)
            {
                _name = name;
            }

            void IEmployee.ShowHappiness()
            {
                Console.WriteLine("Employee " + _name + " showed happiness");
            }
        }

        public interface IEmployee
        {
            void ShowHappiness();
        }
    }
}