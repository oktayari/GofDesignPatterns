using System;
using System.Collections.Generic;

namespace GoFPatternsLibAdv.StructuralPatterns
{
    /// <summary>
    ///     the composite pattern is a partitioning design pattern. The composite pattern
    ///     describes that a group of objects are to be treated in the same way as a single instance of an object.
    /// </summary>
    internal class CompositePattern
    {
        //Component


        public void TestComposite()
        {
            // initialize variables
            var compositeGraphic = new CompositeGraphic();
            var compositeGraphic1 = new CompositeGraphic();
            var compositeGraphic2 = new CompositeGraphic();

            //Add 1 Graphic to compositeGraphic1
            compositeGraphic1.Add(new Ellipse());

            //Add 2 Graphic to compositeGraphic2
            compositeGraphic2.AddRange(new Ellipse(),
                                       new Ellipse());

            /*Add 1 Graphic, compositeGraphic1, and 
              compositeGraphic2 to compositeGraphic */
            compositeGraphic.AddRange(new Ellipse(),
                                      compositeGraphic1,
                                      compositeGraphic2);

            /*Prints the complete graphic 
            (four times the string "Ellipse").*/
            compositeGraphic.Print();
            Console.ReadLine();
        }

        public class CompositeGraphic : IGraphic
        {
            //Collection of Graphics.
            private readonly List<IGraphic> _graphics;

            //Constructor 
            public CompositeGraphic()
            {
                //initialize generic Colleciton(Composition)
                _graphics = new List<IGraphic>();
            }

            public void Print()
            {
                foreach (IGraphic childGraphic in _graphics)
                {
                    childGraphic.Print();
                }
            }

            //Adds the graphic to the composition
            public void Add(IGraphic graphic)
            {
                _graphics.Add(graphic);
            }

            //Adds multiple graphics to the composition
            public void AddRange(params IGraphic[] graphic)
            {
                _graphics.AddRange(graphic);
            }

            //Removes the graphic from the composition
            public void Delete(IGraphic graphic)
            {
                _graphics.Remove(graphic);
            }

            //Prints the graphic.
        }

        public class Ellipse : IGraphic
        {
            //Prints the graphic
            public void Print()
            {
                Console.WriteLine("Ellipse");
            }
        }

        public interface IGraphic
        {
            void Print();
        }
    }
}