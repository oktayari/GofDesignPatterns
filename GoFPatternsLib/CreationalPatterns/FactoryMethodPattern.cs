using System;

namespace GoFPatternsLib.CreationalPatterns
{
    /// <summary>
    ///     Intent
    ///     Define an interface for creating an object,
    ///     but let subclasses decide which class to instantiate.
    ///     Factory Method lets a class defer instantiation to subclasses.
    ///     Defining a “virtual” constructor.The new operator considered harmful.
    ///     Problem
    ///     A framework needs to standardize the architectural model for a range of applications,
    ///     but allow for individual applications to define their own domain objects
    ///     and provide for their instantiation.
    /// </summary>
    internal class FactoryMethodPattern
    {
        // "Product" 

        // "ConcreteProductA" 
        public void TestFactoryMethodPattern()
        {
            // An array of creators 
            var creators = new Creator[2];
            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();

            // Iterate over creators and create products 
            foreach (Creator creator in creators)
            {
                Product product = creator.FactoryMethod();
                Console.WriteLine("Created {0}",
                                  product.GetType().Name);
            }

            // Wait for user 
            Console.Read();
        }

        private class ConcreteCreatorA : Creator
        {
            public override Product FactoryMethod()
            {
                return new ConcreteProductA();
            }
        }

        // "ConcreteCreator" 
        private class ConcreteCreatorB : Creator
        {
            public override Product FactoryMethod()
            {
                return new ConcreteProductB();
            }
        }

        private class ConcreteProductA : Product
        {
        }

        // "ConcreteProductB" 
        private class ConcreteProductB : Product
        {
        }

        // "Creator" 
        private abstract class Creator
        {
            public abstract Product FactoryMethod();
        }

        private abstract class Product
        {
        }

        // "ConcreteCreator" 
    }
}