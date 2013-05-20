using System;

namespace GoFPatternsLib.BehavioralPatterns
{
    /// <summary>
    ///     Intent
    ///     Avoid coupling the sender of a request to its receiver by giving more
    ///     than one object a chance to handle the request. Chain the receiving objects
    ///     and pass the request along the chain until an object handles it.
    ///     Launch-and-leave requests with a single processing pipeline that contains many possible handlers.
    ///     An object-oriented linked list with recursive traversal.
    ///     Intent
    ///     Avoid coupling the sender of a request to its receiver
    ///     by giving more than one object a chance to handle the request.
    ///     Chain the receiving objects and pass the request along the chain until an object handles it.
    ///     Launch-and-leave requests with a single processing pipeline that contains many possible handlers.
    ///     An object-oriented linked list with recursive traversal.
    /// </summary>
    internal class ChainOfResponsibilityPattern
    {
        // "Handler" 

        // "ConcreteHandler1" 
        public void TestChainOfResponsibilityPattern()
        {
            // Setup Chain of Responsibility 
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            Handler h3 = new ConcreteHandler3();
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            // Generate and process request 
            int[] requests = {2, 5, 14, 22, 18, 3, 27, 20};

            foreach (int request in requests)
            {
                h1.HandleRequest(request);
            }

            // Wait for user 
            Console.Read();
        }

        private class ConcreteHandler1 : Handler
        {
            public override void HandleRequest(int request)
            {
                if (request >= 0 && request < 10)
                {
                    Console.WriteLine("{0} handled request {1}",
                                      GetType().Name, request);
                }
                else if (Successor != null)
                {
                    Successor.HandleRequest(request);
                }
            }
        }

        // "ConcreteHandler2" 
        private class ConcreteHandler2 : Handler
        {
            public override void HandleRequest(int request)
            {
                if (request >= 10 && request < 20)
                {
                    Console.WriteLine("{0} handled request {1}",
                                      GetType().Name, request);
                }
                else if (Successor != null)
                {
                    Successor.HandleRequest(request);
                }
            }
        }

        // "ConcreteHandler3" 
        private class ConcreteHandler3 : Handler
        {
            public override void HandleRequest(int request)
            {
                if (request >= 20 && request < 30)
                {
                    Console.WriteLine("{0} handled request {1}",
                                      GetType().Name, request);
                }
                else if (Successor != null)
                {
                    Successor.HandleRequest(request);
                }
            }
        }

        private abstract class Handler
        {
            protected Handler Successor;

            public void SetSuccessor(Handler successor)
            {
                Successor = successor;
            }

            public abstract void HandleRequest(int request);
        }
    }
}