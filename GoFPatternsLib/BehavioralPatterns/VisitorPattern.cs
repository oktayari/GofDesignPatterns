using System;
using System.Collections;

namespace GoFPatternsLib.BehavioralPatterns
{
    /// <summary>
    ///     Intent
    ///     Represent an operation to be performed on the elements of an object structure.
    ///     Visitor lets you define a new operation without changing the classes of the elements
    ///     on which it operates.The classic technique for recovering lost type information.
    ///     Do the right thing based on the type of two objects.Double dispatch
    ///     Problem
    ///     Many distinct and unrelated operations need to be performed on node objects
    ///     in a heterogeneous aggregate structure. You want to avoid “polluting” the node classes
    ///     with these operations. And, you don’t want to have to query the type of each node
    ///     and cast the pointer to the correct type before performing the desired operation.
    /// </summary>
    internal class VisitorPattern
    {
        // "Visitor" 

        // "ConcreteVisitor1" 
        public void TestVisitorPattern()
        {
            // Setup structure 

            Element aE = new ConcreteElementA();
            Element bE = new ConcreteElementB();
            var o = new ObjectStructure();
            o.Attach(aE);
            o.Attach(bE);


            // Create visitor objects 
            var v1 = new ConcreteVisitor1();
            var v2 = new ConcreteVisitor2();

            // Structure accepting visitors 
            o.Accept(v1);
            o.Accept(v2);

            o.Detach(aE);
            o.Detach(bE);
            // Wait for user 
            Console.Read();
        }

        private class ConcreteElementA : Element
        {
            public override void Accept(Visitor visitor)
            {
                visitor.VisitConcreteElementA(this);
            }

            public void OperationA()
            {
                Console.WriteLine("Operating");
            }
        }

        // "ConcreteElementB" 
        private class ConcreteElementB : Element
        {
            public override void Accept(Visitor visitor)
            {
                visitor.VisitConcreteElementB(this);
            }

            public void OperationB()
            {
                Console.WriteLine("Operating");
            }
        }

        private class ConcreteVisitor1 : Visitor
        {
            public override void VisitConcreteElementA(
                ConcreteElementA concreteElementA)
            {
                Console.WriteLine("{0} visited by {1}",
                                  concreteElementA.GetType().Name, GetType().Name);
            }

            public override void VisitConcreteElementB(
                ConcreteElementB concreteElementB)
            {
                Console.WriteLine("{0} visited by {1}",
                                  concreteElementB.GetType().Name, GetType().Name);
            }
        }

        // "ConcreteVisitor2" 
        private class ConcreteVisitor2 : Visitor
        {
            public override void VisitConcreteElementA(
                ConcreteElementA concreteElementA)
            {
                Console.WriteLine("{0} visited by {1}",
                                  concreteElementA.GetType().Name, GetType().Name);
                concreteElementA.OperationA();
            }

            public override void VisitConcreteElementB(
                ConcreteElementB concreteElementB)
            {
                Console.WriteLine("{0} visited by {1}",
                                  concreteElementB.GetType().Name, GetType().Name);
                concreteElementB.OperationB();
            }
        }

        // "Element" 
        private abstract class Element
        {
            public abstract void Accept(Visitor visitor);
        }

        // "ConcreteElementA" 

        // "ObjectStructure" 
        private class ObjectStructure
        {
            private readonly ArrayList _elements = new ArrayList();

            public void Attach(Element element)
            {
                _elements.Add(element);
            }

            public void Detach(Element element)
            {
                _elements.Remove(element);
            }

            public void Accept(Visitor visitor)
            {
                foreach (Element e in _elements)
                {
                    e.Accept(visitor);
                }
            }
        }

        private abstract class Visitor
        {
            public abstract void VisitConcreteElementA(
                ConcreteElementA concreteElementA);

            public abstract void VisitConcreteElementB(
                ConcreteElementB concreteElementB);
        }
    }
}