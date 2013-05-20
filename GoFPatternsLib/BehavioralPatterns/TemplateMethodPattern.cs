using System;

namespace GoFPatternsLib.BehavioralPatterns
{
    /// <summary>
    ///     Intent
    ///     Define the skeleton of an algorithm in an operation, deferring some steps to client subclasses.
    ///     Template Method lets subclasses redefine certain steps of an algorithm without
    ///     changing the algorithm’s structure.Base class declares algorithm ‘placeholders’,
    ///     and derived classes implement the placeholders.
    ///     Problem
    ///     Two different components have significant similarities,
    ///     but demonstrate no reuse of common interface or implementation.
    ///     If a change common to both components becomes necessary, duplicate effort must be expended.
    /// </summary>
    internal class TemplateMethodPattern
    {
        // "AbstractClass"
        public void TestTemplateMethodPattern()
        {
            AbstractClass c;

            c = new ConcreteClassA();
            c.TemplateMethod();

            c = new ConcreteClassB();
            c.TemplateMethod();

            // Wait for user 
            Console.Read();
        }

        private abstract class AbstractClass
        {
            public abstract void PrimitiveOperation1();
            public abstract void PrimitiveOperation2();

            // The "Template method" 
            public void TemplateMethod()
            {
                PrimitiveOperation1();
                PrimitiveOperation2();
                Console.WriteLine("");
            }
        }

        // "ConcreteClass" 
        private class ConcreteClassA : AbstractClass
        {
            public override void PrimitiveOperation1()
            {
                Console.WriteLine("ConcreteClassA.PrimitiveOperation1()");
            }

            public override void PrimitiveOperation2()
            {
                Console.WriteLine("ConcreteClassA.PrimitiveOperation2()");
            }
        }

        private class ConcreteClassB : AbstractClass
        {
            public override void PrimitiveOperation1()
            {
                Console.WriteLine("ConcreteClassB.PrimitiveOperation1()");
            }

            public override void PrimitiveOperation2()
            {
                Console.WriteLine("ConcreteClassB.PrimitiveOperation2()");
            }
        }
    }
}