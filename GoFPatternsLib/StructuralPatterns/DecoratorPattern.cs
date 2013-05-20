using System;

namespace GoFPatternsLib.StructuralPatterns
{
    /// <summary>
    ///     Intent
    ///     Attach additional responsibilities to an object dynamically.
    ///     Decorators provide a flexible alternative to subclassing for extending functionality.
    ///     Client-specified embellishment of a core object by recursively wrapping it.
    ///     Wrapping a gift, putting it in a box, and wrapping the box.
    ///     Problem
    ///     You want to add behavior or state to individual objects at run-time.
    ///     Inheritance is not feasible because it is static and applies to an entire class.
    /// </summary>
    internal class DecoratorPattern
    {
        // "Component" 
        public void TestDecoratorPattern()
        {
            // Create ConcreteComponent and two Decorators 
            var c = new ConcreteComponent();
            var d1 = new ConcreteDecoratorA();
            var d2 = new ConcreteDecoratorB();

            // Link decorators 
            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();

            // Wait for user 
            Console.Read();
        }

        private abstract class Component
        {
            public abstract void Operation();
        }

        // "ConcreteComponent" 
        private class ConcreteComponent : Component
        {
            public override void Operation()
            {
                Console.WriteLine("ConcreteComponent.Operation()");
            }
        }

        // "Decorator" 

        // "ConcreteDecoratorA" 
        private class ConcreteDecoratorA : Decorator
        {
            private string AddedState { get; set; }

            public override void Operation()
            {
                base.Operation();
                AddedState = "New State";
                Console.WriteLine("ConcreteDecoratorA.Operation()");
            }
        }

        // "ConcreteDecoratorB" 
        private class ConcreteDecoratorB : Decorator
        {
            public override void Operation()
            {
                base.Operation();
                AddedBehavior();
                Console.WriteLine("ConcreteDecoratorB.Operation()");
            }

            private void AddedBehavior()
            {
            }
        }

        private abstract class Decorator : Component
        {
            private Component _component;

            public void SetComponent(Component component)
            {
                _component = component;
            }

            public override void Operation()
            {
                if (_component != null)
                {
                    _component.Operation();
                }
            }
        }
    }
}