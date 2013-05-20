using System;

namespace GoFPatternsLibAdv.CreationalPatterns
{
    /// <summary>
    ///     The prototype pattern is a creational design pattern used in software development when the
    ///     type of objects to create is determined by a prototypical instance, which is cloned to produce new objects.
    ///     This pattern is used to:
    ///     avoid subclasses of an object creator in the client application, like the abstract factory pattern does.
    ///     avoid the inherent cost of creating a new object in the standard way (e.g., using the 'new' keyword)
    ///     when it is prohibitively expensive for a given application.
    /// </summary>
    internal class ProtoType
    {
        public void TestProtoType()
        {
            var prototype = new ConcretePrototype(1000);

            for (int i = 1; i < 10; i++)
            {
                var tempotype = prototype.Clone() as ConcretePrototype;

                // Usage of values in prototype to derive a new value.
                tempotype.X *= i;
                tempotype.PrintX();
            }
            Console.ReadKey();
        }

        private class ConcretePrototype : ICloneable
        {
            public ConcretePrototype(int x)
            {
                X = x;
            }

            public int X { get; set; }

            public object Clone()
            {
                return MemberwiseClone();
            }

            public void PrintX()
            {
                Console.WriteLine("Value :" + X);
            }
        }
    }
}