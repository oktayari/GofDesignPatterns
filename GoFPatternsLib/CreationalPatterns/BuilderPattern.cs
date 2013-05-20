using System;
using System.Collections;

namespace GoFPatternsLib.CreationalPatterns
{
    /// <summary>
    ///     Intent
    ///     Separate the construction of a complex object from its representation so that the same construction
    ///     process can create different representations.Parse a complex representation,
    ///     create one of several targets.
    ///     Problem
    ///     An application needs to create the elements of a complex aggregate.
    ///     The specification for the aggregate exists on secondary storage and one of
    ///     many representations needs to be built in primary storage.
    /// </summary>
    internal class BuilderPattern
    {
        // "Director" 

        // "Builder" 
        public void TestBuilderPattern()
        {
            // Create director and builders 
            var director = new Director();

            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            // Construct two products 
            director.Construct(b1);
            Product p1 = b1.GetResult();
            p1.Show();

            director.Construct(b2);
            Product p2 = b2.GetResult();
            p2.Show();

            // Wait for user 
            Console.Read();
        }

        private abstract class Builder
        {
            public abstract void BuildPartA();
            public abstract void BuildPartB();
            public abstract Product GetResult();
        }

        // "ConcreteBuilder1" 
        private class ConcreteBuilder1 : Builder
        {
            private readonly Product _product = new Product();

            public override void BuildPartA()
            {
                _product.Add("PartA");
            }

            public override void BuildPartB()
            {
                _product.Add("PartB");
            }

            public override Product GetResult()
            {
                return _product;
            }
        }

        // "ConcreteBuilder2" 
        private class ConcreteBuilder2 : Builder
        {
            private readonly Product _product = new Product();

            public override void BuildPartA()
            {
                _product.Add("PartX");
            }

            public override void BuildPartB()
            {
                _product.Add("PartY");
            }

            public override Product GetResult()
            {
                return _product;
            }
        }

        private class Director
        {
            // Builder uses a complex series of steps 
            public void Construct(Builder builder)
            {
                builder.BuildPartA();
                builder.BuildPartB();
            }
        }

        // "Product" 
        private class Product
        {
            private readonly ArrayList _parts = new ArrayList();

            public void Add(string part)
            {
                _parts.Add(part);
            }

            public void Show()
            {
                Console.WriteLine("\nProduct Parts -------");
                foreach (string part in _parts)
                    Console.WriteLine(part);
            }
        }
    }
}