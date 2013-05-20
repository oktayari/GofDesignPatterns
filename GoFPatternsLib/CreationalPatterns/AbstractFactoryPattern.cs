using System;

namespace GoFPatternsLib.CreationalPatterns
{
    /// <summary>
    ///     Intent
    ///     Provide an interface for creating families of related or dependent objects
    ///     without specifying their concrete classes.A hierarchy that encapsulates: many possible “platforms”,
    ///     and the construction of a suite of “products”.The new operator considered harmful.
    ///     Problem
    ///     If an application is to be portable, it needs to encapsulate platform dependencies.
    ///     These “platforms” might include: windowing system, operating system, database, etc.
    ///     Too often, this encapsulatation is not engineered in advance,
    ///     and lots of #ifdef case statements with options for all currently supported platforms
    ///     begin to procreate like rabbits throughout the code.
    /// </summary>
    internal class AbstractFactoryPattern
    {
        // "AbstractFactory" 
        public void TestAbstractFactoryPattern()
        {
            // Abstract factory #1 
            AbstractFactory factory1 = new ConcreteFactory1();
            var c1 = new Client(factory1);
            c1.Run();

            // Abstract factory #2 
            AbstractFactory factory2 = new ConcreteFactory2();
            var c2 = new Client(factory2);
            c2.Run();

            // Wait for user input 
            Console.Read();
        }

        private abstract class AbstractFactory
        {
            public abstract AbstractProductA CreateProductA();
            public abstract AbstractProductB CreateProductB();
        }

        // "ConcreteFactory1" 

        // "AbstractProductA" 
        private abstract class AbstractProductA
        {
        }

        // "AbstractProductB" 
        private abstract class AbstractProductB
        {
            public abstract void Interact(AbstractProductA a);
        }

        private class Client
        {
            private readonly AbstractProductA _abstractProductA;
            private readonly AbstractProductB _abstractProductB;

            // Constructor 
            public Client(AbstractFactory factory)
            {
                _abstractProductB = factory.CreateProductB();
                _abstractProductA = factory.CreateProductA();
            }

            public void Run()
            {
                _abstractProductB.Interact(_abstractProductA);
            }
        }

        private class ConcreteFactory1 : AbstractFactory
        {
            public override AbstractProductA CreateProductA()
            {
                return new ProductA1();
            }

            public override AbstractProductB CreateProductB()
            {
                return new ProductB1();
            }
        }

        // "ConcreteFactory2" 
        private class ConcreteFactory2 : AbstractFactory
        {
            public override AbstractProductA CreateProductA()
            {
                return new ProductA2();
            }

            public override AbstractProductB CreateProductB()
            {
                return new ProductB2();
            }
        }

        // "ProductA1" 
        private class ProductA1 : AbstractProductA
        {
        }

        // "ProductB1" 


        // "ProductA2" 
        private class ProductA2 : AbstractProductA
        {
        }

        private class ProductB1 : AbstractProductB
        {
            public override void Interact(AbstractProductA a)
            {
                Console.WriteLine(GetType().Name + " interacts with " + a.GetType().Name);
            }
        }

        // "ProductB2" 
        private class ProductB2 : AbstractProductB
        {
            public override void Interact(AbstractProductA a)
            {
                Console.WriteLine(GetType().Name + " interacts with " + a.GetType().Name);
            }
        }

        // "Client" - the interaction environment of the products 
    }
}