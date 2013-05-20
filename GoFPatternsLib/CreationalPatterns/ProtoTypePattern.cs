using System;

namespace GoFPatternsLib.CreationalPatterns
{
    /// <summary>
    ///     Intent
    ///     Specify the kinds of objects to create using a prototypical instance,
    ///     and create new objects by copying this prototype.
    ///     Co-opt one instance of a class for use as a breeder of all future instances.
    ///     The new operator considered harmful.
    ///     Problem
    ///     Application “hard wires” the class of object to create in each “new” expression.
    /// </summary>
    internal class ProtoTypePattern
    {
        // "Prototype" 

        // "ConcretePrototype1" 
        public void TestProtoTypePattern()
        {
            // Create two instances and clone each 
            var p1 = new ConcretePrototype1("I");
            var c1 = (ConcretePrototype1) p1.Clone();
            Console.WriteLine("Cloned: {0}", c1.Id);

            var p2 = new ConcretePrototype2("II");
            var c2 = (ConcretePrototype2) p2.Clone();
            Console.WriteLine("Cloned: {0}", c2.Id);

            // Wait for user 
            Console.Read();
        }

        private class ConcretePrototype1 : Prototype
        {
            // Constructor 
            public ConcretePrototype1(string id)
                : base(id)
            {
            }

            public override Prototype Clone()
            {
                // Shallow copy 
                return (Prototype) MemberwiseClone();
            }
        }

        // "ConcretePrototype2" 
        private class ConcretePrototype2 : Prototype
        {
            // Constructor 
            public ConcretePrototype2(string id)
                : base(id)
            {
            }

            public override Prototype Clone()
            {
                // Shallow copy 
                return (Prototype) MemberwiseClone();
            }
        }

        private abstract class Prototype
        {
            private readonly string _id;

            // Constructor 
            public Prototype(string id)
            {
                _id = id;
            }

            // Property 
            public string Id
            {
                get { return _id; }
            }

            public abstract Prototype Clone();
        }
    }
}