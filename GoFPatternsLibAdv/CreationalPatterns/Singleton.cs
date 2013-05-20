namespace GoFPatternsLibAdv.CreationalPatterns
{
    /// <summary>
    ///     he singleton pattern is a design pattern that restricts the instantiation of a class to one object.
    ///     This is useful when exactly one object is needed to coordinate actions across the system.
    /// </summary>
    public class Singleton
    {
        private static readonly Singleton Instance = new Singleton();

        private Singleton()
        {
        }

        public static Singleton getInstance()
        {
            return Instance;
        }
    }
}