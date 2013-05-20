using System;

namespace GoFPatternsLib.StructuralPatterns
{
    /// <summary>
    ///     Intent
    ///     Provide a surrogate or placeholder for another object to control access to it.
    ///     Use an extra level of indirection to support distributed, controlled, or intelligent access.
    ///     Add a wrapper and delegation to protect the real component from undue complexity.
    ///     Problem
    ///     You need to support resource-hungry objects,
    ///     and you do not want to instantiate such objects unless
    ///     and until they are actually requested by the client.
    /// </summary>
    internal class ProxyPattern
    {
        // "Subject" 

        public void TestProxyPattern()
        {
            // Create proxy and request a service 
            var proxy = new Proxy();
            proxy.Request();

            // Wait for user 
            Console.Read();
        }

        private class Proxy : Subject
        {
            private RealSubject _realSubject;

            public override void Request()
            {
                // Use 'lazy initialization' 
                if (_realSubject == null)
                {
                    _realSubject = new RealSubject();
                }

                _realSubject.Request();
            }
        }

        private class RealSubject : Subject
        {
            public override void Request()
            {
                Console.WriteLine("Called RealSubject.Request()");
            }
        }

        private abstract class Subject
        {
            public abstract void Request();
        }
    }
}