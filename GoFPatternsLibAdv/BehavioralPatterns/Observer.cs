using System;
using System.Collections.Generic;

namespace GoFPatternsLibAdv.BehavioralPatterns
{
    /// <summary>
    ///     The observer pattern is a software design pattern in which an object, called the subject,
    ///     maintains a list of its dependents, called observers, and notifies them automatically of any state changes,
    ///     usually by calling one of their methods.
    ///     It is mainly used to implement distributed event handling systems.
    /// </summary>
    internal class ObserverPattern
    {
        public void TestObserver()
        {
            // Create IBM stock and attach investors

            var ibm = new Ibm("IBM", 120.00);

            ibm.Attach(new Investor("Sorros"));

            ibm.Attach(new Investor("Berkshire"));

            // Fluctuating prices will notify investors

            ibm.Price = 120.10;

            ibm.Price = 121.00;

            ibm.Price = 120.50;

            ibm.Price = 120.75;

            // Wait for user

            Console.ReadKey();
        }

        private interface IInvestor
        {
            void Update(Stock stock);
        }

        private class Ibm : Stock
        {
            // Constructor

            public Ibm(string symbol, double price)
                : base(symbol, price)
            {
            }
        }

        private class Investor : IInvestor
        {
            private readonly string _name;

            // Constructor

            public Investor(string name)
            {
                _name = name;
            }


            // Gets or sets the stock

            public Stock Stock { get; set; }

            public void Update(Stock stock)
            {
                Console.WriteLine("Notified {0} of {1}'s " +
                                  "change to {2:C}", _name, stock.Symbol, stock.Price);
            }
        }

        private abstract class Stock
        {
            private readonly List<IInvestor> _investors = new List<IInvestor>();
            private readonly string _symbol;

            private double _price;


            // Constructor

            protected Stock(string symbol, double price)
            {
                _symbol = symbol;

                _price = price;
            }

            public double Price
            {
                get { return _price; }

                set
                {
                    if (_price != value)
                    {
                        _price = value;

                        Notify();
                    }
                }
            }


            // Gets the symbol

            public string Symbol
            {
                get { return _symbol; }
            }


            public void Attach(IInvestor investor)
            {
                _investors.Add(investor);
            }


            public void Detach(IInvestor investor)
            {
                _investors.Remove(investor);
            }


            public void Notify()
            {
                foreach (IInvestor investor in _investors)
                {
                    investor.Update(this);
                }


                Console.WriteLine("");
            }


            // Gets or sets the price
        }
    }
}