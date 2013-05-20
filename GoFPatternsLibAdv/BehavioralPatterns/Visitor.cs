using System;

namespace GoFPatternsLibAdv.BehavioralPatterns
{
    //he visitor design pattern is a way of separating an algorithm from an object structure on which it operates

    /// <summary>
    ///     the visitor design pattern is a way of separating an algorithm from an object structure on which it operates.
    ///     A practical result of this separation is the ability to add new operations
    ///     to existing object structures without modifying those structures.
    ///     It is one way to easily follow the open/closed principle.
    /// </summary>
    internal class VisitorPattern
    {
        public void TestVisitor()
        {
            ICarElement car = new Car();
            car.Accept(new CarElementPrintVisitor());
            car.Accept(new CarElementDoVisitor());
        }

        private class Body : ICarElement
        {
            public void Accept(ICarElementVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        private class Car : ICarElement
        {
            private readonly ICarElement[] _elements;

            public Car()
            {
                //create new Array of elements
                _elements = new ICarElement[]
                    {
                        new Wheel("front left"),
                        new Wheel("front right"), new Wheel("back left"),
                        new Wheel("back right"), new Body(), new Engine()
                    };
            }

            public void Accept(ICarElementVisitor visitor)
            {
                foreach (ICarElement elem in _elements)
                {
                    elem.Accept(visitor);
                }

                visitor.Visit(this);
            }
        }


        private class CarElementDoVisitor : ICarElementVisitor
        {
            public void Visit(Wheel wheel)
            {
                Console.WriteLine("Kicking my " + wheel.GetName() + " wheel");
            }

            public void Visit(Engine engine)
            {
                Console.WriteLine("Starting my engine");
            }

            public void Visit(Body body)
            {
                Console.WriteLine("Moving my body");
            }

            public void Visit(Car car)
            {
                Console.WriteLine("Starting my car");
            }
        }

        private class CarElementPrintVisitor : ICarElementVisitor
        {
            public void Visit(Wheel wheel)
            {
                Console.WriteLine("Visiting " + wheel.GetName() + " wheel");
            }

            public void Visit(Engine engine)
            {
                Console.WriteLine("Visiting engine");
            }

            public void Visit(Body body)
            {
                Console.WriteLine("Visiting body");
            }

            public void Visit(Car car)
            {
                Console.WriteLine("Visiting car");
            }
        }

        private class Engine : ICarElement
        {
            public void Accept(ICarElementVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        private interface ICarElement
        {
            void Accept(ICarElementVisitor visitor); // CarElements have to provide accept().
        }

        private interface ICarElementVisitor
        {
            void Visit(Wheel wheel);
            void Visit(Engine engine);
            void Visit(Body body);
            void Visit(Car car);
        }

        private class Wheel : ICarElement
        {
            private readonly String _name;

            public Wheel(String name)
            {
                _name = name;
            }

            public void Accept(ICarElementVisitor visitor)
            {
                /*
                 * accept(CarElementVisitor) in Wheel implements
                 * accept(CarElementVisitor) in CarElement, so the call
                 * to accept is bound at run time. This can be considered
                 * the first dispatch. However, the decision to call
                 * visit(Wheel) (as opposed to visit(Engine) etc.) can be
                 * made during compile time since 'this' is known at compile
                 * time to be a Wheel. Moreover, each implementation of
                 * CarElementVisitor implements the visit(Wheel), which is
                 * another decision that is made at run time. This can be
                 * considered the second dispatch.
                 */
                visitor.Visit(this);
            }

            public String GetName()
            {
                return _name;
            }
        }
    }
}