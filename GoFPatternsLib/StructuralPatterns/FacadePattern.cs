using System;

namespace GoFPatternsLib.StructuralPatterns
{
    /// <summary>
    ///     Intent
    ///     Provide a unified interface to a set of interfaces in a subsystem.
    ///     Facade defines a higher-level interface that makes the subsystem easier to use.
    ///     Wrap a complicated subsystem with a simpler interface.
    ///     Problem
    ///     A segment of the client community needs a simplified interface to
    ///     the overall functionality of a complex subsystem.
    /// </summary>
    internal class FacadePattern
    {
        // "Subsystem ClassA" 
        public void TestFacadePattern()
        {
            var facade = new Facade();

            facade.MethodA();
            facade.MethodB();

            // Wait for user 
            Console.Read();
        }

        private class Facade
        {
            private readonly SubSystemFour _four;
            private readonly SubSystemOne _one;
            private readonly SubSystemThree _three;
            private readonly SubSystemTwo _two;

            public Facade()
            {
                _one = new SubSystemOne();
                _two = new SubSystemTwo();
                _three = new SubSystemThree();
                _four = new SubSystemFour();
            }

            public void MethodA()
            {
                Console.WriteLine("\nMethodA() ---- ");
                _one.MethodOne();
                _two.MethodTwo();
                _four.MethodFour();
            }

            public void MethodB()
            {
                Console.WriteLine("\nMethodB() ---- ");
                _two.MethodTwo();
                _three.MethodThree();
            }
        }

        private class SubSystemFour
        {
            public void MethodFour()
            {
                Console.WriteLine(" SubSystemFour Method");
            }
        }

        private class SubSystemOne
        {
            public void MethodOne()
            {
                Console.WriteLine(" SubSystemOne Method");
            }
        }

        // Subsystem ClassB" 

        // Subsystem ClassC" 
        private class SubSystemThree
        {
            public void MethodThree()
            {
                Console.WriteLine(" SubSystemThree Method");
            }
        }

        private class SubSystemTwo
        {
            public void MethodTwo()
            {
                Console.WriteLine(" SubSystemTwo Method");
            }
        }

        // Subsystem ClassD" 
    }
}