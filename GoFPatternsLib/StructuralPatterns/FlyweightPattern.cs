using System;
using System.Collections;

namespace GoFPatternsLib.StructuralPatterns
{
    /// <summary>
    ///     Intent
    ///     Use sharing to support large numbers of fine-grained objects efficiently.
    ///     The Motif GUI strategy of replacing heavy-weight widgets with light-weight gadgets.
    ///     Problem
    ///     Designing objects down to the lowest levels of system “granularity” provides
    ///     optimal flexibility, but can be unacceptably expensive in terms of performance and memory usage.
    /// </summary>
    internal class FlyweightPattern
    {
// "FlyweightFactory" 

        // "ConcreteFlyweight" 

        public void TestFlyWeigthPattern()
        {
            // Arbitrary extrinsic state 
            int extrinsicstate = 22;

            var f = new FlyweightFactory();

            // Work with different flyweight instances 
            Flyweight fx = f.GetFlyweight("X");
            fx.Operation(--extrinsicstate);

            Flyweight fy = f.GetFlyweight("Y");
            fy.Operation(--extrinsicstate);

            Flyweight fz = f.GetFlyweight("Z");
            fz.Operation(--extrinsicstate);

            var uf = new
                UnsharedConcreteFlyweight();

            uf.Operation(--extrinsicstate);

            // Wait for user 
            Console.Read();
        }

        private class ConcreteFlyweight : Flyweight
        {
            public override void Operation(int extrinsicstate)
            {
                Console.WriteLine("ConcreteFlyweight: " + extrinsicstate);
            }
        }

        private abstract class Flyweight
        {
            public abstract void Operation(int extrinsicstate);
        }

        private class FlyweightFactory
        {
            private readonly Hashtable _flyweights = new Hashtable();

            // Constructor 
            public FlyweightFactory()
            {
                _flyweights.Add("X", new ConcreteFlyweight());
                _flyweights.Add("Y", new ConcreteFlyweight());
                _flyweights.Add("Z", new ConcreteFlyweight());
            }

            public Flyweight GetFlyweight(string key)
            {
                return ((Flyweight) _flyweights[key]);
            }
        }

        // "UnsharedConcreteFlyweight" 
        private class UnsharedConcreteFlyweight : Flyweight
        {
            public override void Operation(int extrinsicstate)
            {
                Console.WriteLine("UnsharedConcreteFlyweight: " +
                                  extrinsicstate);
            }
        }
    }
}