using System;

namespace GoFPatternsLibAdv.CreationalPatterns
{
    /// <summary>
    ///     Define an interface for creating an object, but let the classes that implement
    ///     the interface decide which class to instantiate.
    ///     The Factory method lets a class defer instantiation to subclasses
    /// </summary>
    internal class FactoryMethod
    {
        private Complex _product = Complex.FromPolarFactory(1, Math.PI);

        public class Complex
        {
            public double Imaginary;
            public double Real;

            private Complex(double real, double imaginary)
            {
                Real = real;
                Imaginary = imaginary;
            }

            public static Complex FromCartesianFactory(double real, double imaginary)
            {
                return new Complex(real, imaginary);
            }

            public static Complex FromPolarFactory(double modulus, double angle)
            {
                return new Complex(modulus*Math.Cos(angle), modulus*Math.Sin(angle));
            }
        }
    }
}