using System;

namespace GoFPatternsLibAdv.StructuralPatterns
{
    /// <summary>
    ///     The bridge pattern is a design pattern used in software engineering which
    ///     is meant to "decouple an abstraction from its implementation so that the two can vary independently".[1]
    ///     The bridge uses encapsulation,
    ///     aggregation, and can use inheritance to separate responsibilities into different classes.
    /// </summary>
    internal class BridgePattern
    {
        /** "Implementor" */

        /** "ConcreteImplementor"  1/2 */

        public void TestBridge()
        {
            var shapes = new Shape[]
                {
                    new CircleShape(1, 2, 3, new DrawingApi1()),
                    new CircleShape(5, 7, 11, new DrawingApi2())
                };

            foreach (Shape shape in shapes)
            {
                shape.ResizeByPercentage(2.5);
                shape.Draw();
            }
        }

        private class CircleShape : Shape
        {
            private readonly double _x;
            private readonly double _y;
            private double _radius;

            public CircleShape(double x, double y, double radius, IDrawingApi drawingApi)
                : base(drawingApi)
            {
                _x = x;
                _y = y;
                _radius = radius;
            }


            // low-level i.e. Implementation specific
            public override void Draw()
            {
                DrawingApi.DrawCircle(_x, _y, _radius);
            }

            // high-level i.e. Abstraction specific
            public override void ResizeByPercentage(double pct)
            {
                _radius *= pct;
            }
        }

        private class DrawingApi1 : IDrawingApi
        {
            public void DrawCircle(double x, double y, double radius)
            {
                Console.WriteLine("API1.circle at {0} {1} radius {2}", x, y, radius);
            }
        }

        /** "ConcreteImplementor" 2/2 */

        private class DrawingApi2 : IDrawingApi
        {
            public void DrawCircle(double x, double y, double radius)
            {
                Console.WriteLine("API2.circle at {0}:{1} radius {2}", x, y, radius);
            }
        }

        private interface IDrawingApi
        {
            void DrawCircle(double x, double y, double radius);
        }


        /** "Abstraction" */

        private abstract class Shape
        {
            protected readonly IDrawingApi DrawingApi;

            protected Shape(IDrawingApi drawingApi)
            {
                DrawingApi = drawingApi;
            }

            public abstract void Draw(); // low-level
            public abstract void ResizeByPercentage(double pct); // high-level
        }


        /** "Refined Abstraction" */
    }
}