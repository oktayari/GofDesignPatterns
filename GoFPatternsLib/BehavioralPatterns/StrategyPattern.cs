using System;

namespace GoFPatternsLib.BehavioralPatterns
{
    /// <summary>
    ///     Intent
    ///     Define a family of algorithms, encapsulate each one, and make them interchangeable.
    ///     Strategy lets the algorithm vary independently from the clients that use it.
    ///     Capture the abstraction in an interface, bury implementation details in derived classes.
    ///     Problem
    ///     One of the dominant strategies of object-oriented design is the “open-closed principle”.
    /// </summary>
    internal class StrategyPattern
    {
        // "Strategy" 

        // "ConcreteStrategyA" 
        public void TestStrategyPattern()
        {
            Context context;

            // Three contexts following different strategies 
            context = new Context(new ConcreteStrategyA());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyB());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyC());
            context.ContextInterface();

            // Wait for user 
            Console.Read();
        }

        private class ConcreteStrategyA : Strategy
        {
            public override void AlgorithmInterface()
            {
                Console.WriteLine(
                    "Called ConcreteStrategyA.AlgorithmInterface()");
            }
        }

        // "ConcreteStrategyB" 
        private class ConcreteStrategyB : Strategy
        {
            public override void AlgorithmInterface()
            {
                Console.WriteLine(
                    "Called ConcreteStrategyB.AlgorithmInterface()");
            }
        }

        // "ConcreteStrategyC" 
        private class ConcreteStrategyC : Strategy
        {
            public override void AlgorithmInterface()
            {
                Console.WriteLine(
                    "Called ConcreteStrategyC.AlgorithmInterface()");
            }
        }

        // "Context" 
        private class Context
        {
            private readonly Strategy _strategy;

            // Constructor 
            public Context(Strategy strategy)
            {
                this._strategy = strategy;
            }

            public void ContextInterface()
            {
                _strategy.AlgorithmInterface();
            }
        }

        private abstract class Strategy
        {
            public abstract void AlgorithmInterface();
        }
    }
}