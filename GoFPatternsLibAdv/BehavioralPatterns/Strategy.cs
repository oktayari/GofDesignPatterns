using System;

namespace GoFPatternsLibAdv.BehavioralPatterns
{
    // a.k.a. Policy Pattern

    /// <summary>
    ///     In computer programming, the strategy pattern (also known as the policy pattern) is a software design pattern,
    ///     whereby an algorithm's behaviour can be selected at runtime.
    ///     Formally speaking, the strategy pattern defines a family of algorithms, encapsulates each one, and makes them interchangeable.
    ///     Strategy lets the algorithm vary independently from clients that use it
    /// </summary>
    internal class StrategyPattern
    {
        /** The classes that implement a concrete strategy should implement this.
           * The Context class uses this to call the concrete strategy. */

        /** Implements the algorithm using the strategy interface */

        public void TestStrategy()
        {
            // Three contexts following different strategies
            var context = new Context(new Add());
            int resultA = context.ExecuteStrategy(3, 4);

            context = new Context(new Subtract());
            int resultB = context.ExecuteStrategy(3, 4);

            context = new Context(new Multiply());
            int resultC = context.ExecuteStrategy(3, 4);

            Console.WriteLine("Result A : " + resultA);
            Console.WriteLine("Result B : " + resultB);
            Console.WriteLine("Result C : " + resultC);
        }

        private class Add : IStrategy
        {
            public int Execute(int a, int b)
            {
                Console.WriteLine("Called Add's execute()");

                return a + b; // Do an addition with a and b
            }
        }

        private class Context
        {
            private readonly IStrategy _strategy;

            public Context(IStrategy strategy)
            {
                _strategy = strategy;
            }

            public int ExecuteStrategy(int a, int b)
            {
                return _strategy.Execute(a, b);
            }
        }

        private interface IStrategy
        {
            int Execute(int a, int b);
        }

        private class Multiply : IStrategy
        {
            public int Execute(int a, int b)
            {
                Console.WriteLine("Called Multiply's execute()");

                return a*b; // Do a multiplication with a and b
            }
        }

        private class Subtract : IStrategy
        {
            public int Execute(int a, int b)
            {
                Console.WriteLine("Called Subtract's execute()");

                return a - b; // Do a subtraction with a and b
            }
        }
    }
}