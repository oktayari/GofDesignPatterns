namespace GoFPatternsLibAdv.CreationalPatterns
{
    /// <summary>
    ///     The intent of the Builder design pattern is to separate the construction of a complex object from its representation.
    ///     By doing so, the same construction process can create different representations
    /// </summary>
    public class Builder
    {
        // Builder - abstract interface for creating objects (the product, in this case)

        // Director - responsible for managing the correct sequence of object creation.
        // Receives a Concrete Builder as a parameter and executes the necessary operations on it.
        public void TestBuilder()
        {
            PizzaBuilder hawaiianPizzaBuilder = new HawaiianPizzaBuilder();
            var cook = new Cook();
            cook.SetPizzaBuilder(hawaiianPizzaBuilder);
            cook.ConstructPizza();
            // create the product
            Pizza hawaiian = cook.GetPizza();

            PizzaBuilder spicyPizzaBuilder = new SpicyPizzaBuilder();
            cook.SetPizzaBuilder(spicyPizzaBuilder);
            cook.ConstructPizza();
            // create another product
            Pizza spicy = cook.GetPizza();
        }

        private class Cook
        {
            private PizzaBuilder _pizzaBuilder;

            public void SetPizzaBuilder(PizzaBuilder pb)
            {
                _pizzaBuilder = pb;
            }

            public Pizza GetPizza()
            {
                return _pizzaBuilder.GetPizza();
            }

            public void ConstructPizza()
            {
                _pizzaBuilder.CreateNewPizzaProduct();
                _pizzaBuilder.BuildDough();
                _pizzaBuilder.BuildSauce();
                _pizzaBuilder.BuildTopping();
            }
        }

        private class HawaiianPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough()
            {
                Pizza.Dough = "cross";
            }

            public override void BuildSauce()
            {
                Pizza.Sauce = "mild";
            }

            public override void BuildTopping()
            {
                Pizza.Topping = "ham+pineapple";
            }
        }

        // Product - The final object that will be created by the Director using Builder
        public class Pizza
        {
            public string Dough = string.Empty;
            public string Sauce = string.Empty;
            public string Topping = string.Empty;
        }

        private abstract class PizzaBuilder
        {
            protected Pizza Pizza;

            public Pizza GetPizza()
            {
                return Pizza;
            }

            public void CreateNewPizzaProduct()
            {
                Pizza = new Pizza();
            }

            public abstract void BuildDough();
            public abstract void BuildSauce();
            public abstract void BuildTopping();
        }

        private class SpicyPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough()
            {
                Pizza.Dough = "pan baked";
            }

            public override void BuildSauce()
            {
                Pizza.Sauce = "hot";
            }

            public override void BuildTopping()
            {
                Pizza.Topping = "pepperoni + salami";
            }
        }
    }
}