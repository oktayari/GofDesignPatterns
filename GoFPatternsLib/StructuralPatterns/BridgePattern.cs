using System;

namespace GoFPatternsLib.StructuralPatterns
{
    /// <summary>
    ///     Intent
    ///     Decouple an abstraction from its implementation so that the two can vary independently.
    ///     Publish interface in an inheritance hierarchy, and bury implementation in
    ///     its own inheritance hierarchy.Beyond encapsulation, to insulation
    ///     Problem
    ///     “Hardening of the software arteries” has occurred by using subclassing
    ///     of an abstract base class to provide alternative implementations.
    ///     This locks in compile-time binding between interface and implementation.
    ///     The abstraction and implementation cannot be independently extended or composed.
    /// </summary>
    internal class BridgePattern
    {
        // "Abstraction" 
        public void TestBridgePattern()
        {
            Abstraction ab = new RefinedAbstraction();

            // Set implementation and call 
            ab.Implementor = new ConcreteImplementorA();
            ab.Operation();

            // Change implemention and call 
            ab.Implementor = new ConcreteImplementorB();
            ab.Operation();

            // Wait for user 
            Console.Read();
        }

        private class Abstraction
        {
            protected Implementor implementor;

            // Property 
            public Implementor Implementor
            {
                set { implementor = value; }
            }

            public virtual void Operation()
            {
                implementor.Operation();
            }
        }

        // "Implementor" 

        // "ConcreteImplementorA" 
        private class ConcreteImplementorA : Implementor
        {
            public override void Operation()
            {
                Console.WriteLine("ConcreteImplementorA Operation");
            }
        }

        // "ConcreteImplementorB" 
        private class ConcreteImplementorB : Implementor
        {
            public override void Operation()
            {
                Console.WriteLine("ConcreteImplementorB Operation");
            }
        }

        private abstract class Implementor
        {
            public abstract void Operation();
        }

        // "RefinedAbstraction" 
        private class RefinedAbstraction : Abstraction
        {
            public override void Operation()
            {
                implementor.Operation();
            }
        }
    }
}