using System;

namespace GoFPatternsLib.CreationalPatterns
{
    /// <summary>
    ///     Intent
    ///     Ensure a class has only one instance, and provide a global point of access to it.
    ///     Encapsulated “just-in-time initialization” or “initialization on first use”.
    ///     Problem
    ///     Application needs one, and only one, instance of an object.
    ///     Additionally, lazy initialization and global access are necessary.
    /// </summary>
    internal class SingletonPattern
    {
        public void TestSingletonPattern()
        {
            // Constructor is protected -- cannot use new 
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();

            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }

            // Wait for user 
            Console.Read();
        }

        private class Singleton
        {
            private static Singleton _instance;

            // Note: Constructor is 'protected' 
            protected Singleton()
            {
            }

            public static Singleton Instance()
            {
                // Use 'Lazy initialization' 
                if (_instance == null)
                {
                    _instance = new Singleton();
                }

                return _instance;
            }
        }
    }
}