using System;

namespace GoFPatternsLibAdv.StructuralPatterns
{
    /// <summary>
    ///     the decorator pattern is a design pattern that allows behavior to be added to an individual object, either
    ///     statically or dynamically, without affecting the behavior of other objects from the same class.
    /// </summary>
    internal class Decorator
    {
        // The abstract Coffee class defines the functionality of Coffee implemented by decorator
        public void TestDecorater()
        {
            Coffee c = new SimpleCoffee();
            Console.WriteLine("Cost: " + c.GetCost() + "; Ingredients: " + c.GetIngredients());


            c = new Milk(c);
            Console.WriteLine("Cost: " + c.GetCost() + "; Ingredients: " + c.GetIngredients());

            c = new Sprinkles(c);
            Console.WriteLine("Cost: " + c.GetCost() + "; Ingredients: " + c.GetIngredients());

            c = new Whip(c);
            Console.WriteLine("Cost: " + c.GetCost() + "; Ingredients: " + c.GetIngredients());

            // Note that you can also stack more than one decorator of the same type
            c = new Sprinkles(c);
            Console.WriteLine("Cost: " + c.GetCost() + "; Ingredients: " + c.GetIngredients());
        }

        public abstract class Coffee
        {
            public abstract double GetCost(); // returns the cost of the coffee
            public abstract String GetIngredients(); // returns the ingredients of the coffee
        }

        // extension of a simple coffee without any extra ingredients


        // abstract decorator class - note that it extends Coffee abstract class
        public abstract class CoffeeDecorator : Coffee
        {
            protected Coffee DecoratedCoffee;
            protected String IngredientSeparator = ", ";

            public CoffeeDecorator(Coffee decoratedCoffee)
            {
                DecoratedCoffee = decoratedCoffee;
            }

            public override double GetCost()
            {
                // implementing methods of the abstract class
                return DecoratedCoffee.GetCost();
            }

            public override String GetIngredients()
            {
                return DecoratedCoffee.GetIngredients();
            }
        }


        // Decorator Milk that mixes milk with coffee
        // note it extends CoffeeDecorator
        private class Milk : CoffeeDecorator
        {
            public Milk(Coffee decoratedCoffee)
                : base(decoratedCoffee)
            {
            }

            public override double GetCost()
            {
                // overriding methods defined in the abstract superclass
                return base.GetCost() + 0.5;
            }

            public override String GetIngredients()
            {
                return base.GetIngredients() + IngredientSeparator + "Milk";
            }
        }

        public class SimpleCoffee : Coffee
        {
            public override double GetCost()
            {
                return 1;
            }

            public override String GetIngredients()
            {
                return "Coffee";
            }
        }


        // Decorator Whip that mixes whip with coffee
        // note it extends CoffeeDecorator


        // Decorator Sprinkles that mixes sprinkles with coffee
        // note it extends CoffeeDecorator
        private class Sprinkles : CoffeeDecorator
        {
            public Sprinkles(Coffee decoratedCoffee)
                : base(decoratedCoffee)
            {
            }

            public override double GetCost()
            {
                return base.GetCost() + 0.2;
            }

            public override String GetIngredients()
            {
                return base.GetIngredients() + IngredientSeparator + "Sprinkles";
            }
        }

        private class Whip : CoffeeDecorator
        {
            public Whip(Coffee decoratedCoffee)
                : base(decoratedCoffee)
            {
            }

            public override double GetCost()
            {
                return base.GetCost() + 0.7;
            }

            public override String GetIngredients()
            {
                return base.GetIngredients() + IngredientSeparator + "Whip";
            }
        }
    }
}