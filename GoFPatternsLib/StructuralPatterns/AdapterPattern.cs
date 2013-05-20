using System;

namespace GoFPatternsLib.StructuralPatterns
{
    /// <summary>
    ///     Intent
    ///     Convert the interface of a class into another interface clients expect.
    ///     Adapter lets classes work together that couldn’t otherwise because of incompatible interfaces.
    ///     Wrap an existing class with a new interface.Impedance match an old component to a new system
    ///     Problem
    ///     An “off the shelf” component offers compelling functionality that you would like to reuse,
    ///     but its “view of the world” is not compatible with the philosophy
    ///     and architecture of the system currently being developed.
    /// </summary>
    internal class AdapterPattern
    {
        // "Target" 


        public void TestAdapterPattern()
        {
            // Create adapter and place a request 
            Target target = new Adapter();
            target.Request();

            // Wait for user 
            Console.Read();
        }

        private class Adaptee
        {
            public void SpecificRequest()
            {
                Console.WriteLine("Called SpecificRequest()");
            }
        }

        private class Adapter : Target
        {
            private readonly Adaptee _adaptee = new Adaptee();

            public override void Request()
            {
                // Possibly do some other work 
                // and then call SpecificRequest 
                _adaptee.SpecificRequest();
            }
        }

        private class Target
        {
            public virtual void Request()
            {
                Console.WriteLine("Called Target Request()");
            }
        }
    }
}