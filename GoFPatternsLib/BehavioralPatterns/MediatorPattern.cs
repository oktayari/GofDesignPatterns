using System;

namespace GoFPatternsLib.BehavioralPatterns
{
    /// <summary>
    ///     Intent
    ///     Define an object that encapsulates how a set of objects interact.
    ///     Mediator promotes loose coupling by keeping objects from referring
    ///     to each other explicitly, and it lets you vary their interaction independently.
    ///     Design an intermediary to decouple many peers.
    ///     Promote the many-to-many relationships between interacting peers to “full object status”.
    ///     Problem
    ///     We want to design reusable components, but dependencies between the potentially
    ///     reusable pieces demonstrates the “spaghetti code” phenomenon
    ///     (trying to scoop a single serving results in an “all or nothing clump”).
    /// </summary>
    internal class MediatorPattern
    {
        // "Mediator" 

        // "Colleague" 
        public void TestMediatorPattern()
        {
            var m = new ConcreteMediator();

            var c1 = new ConcreteColleague1(m);
            var c2 = new ConcreteColleague2(m);

            m.Colleague1 = c1;
            m.Colleague2 = c2;

            c1.Send("How are you?");
            c2.Send("Fine, thanks");

            // Wait for user 
            Console.Read();
        }

        private abstract class Colleague
        {
            protected readonly Mediator Mediator;

            // Constructor 
            public Colleague(Mediator mediator)
            {
                this.Mediator = mediator;
            }
        }

        // "ConcreteColleague1" 
        private class ConcreteColleague1 : Colleague
        {
            // Constructor 
            public ConcreteColleague1(Mediator mediator)
                : base(mediator)
            {
            }

            public void Send(string message)
            {
                Mediator.Send(message, this);
            }

            public void Notify(string message)
            {
                Console.WriteLine("Colleague1 gets message: "
                                  + message);
            }
        }

        // "ConcreteColleague2" 
        private class ConcreteColleague2 : Colleague
        {
            // Constructor 
            public ConcreteColleague2(Mediator mediator)
                : base(mediator)
            {
            }

            public void Send(string message)
            {
                Mediator.Send(message, this);
            }

            public void Notify(string message)
            {
                Console.WriteLine("Colleague2 gets message: "
                                  + message);
            }
        }

        private class ConcreteMediator : Mediator
        {
            private ConcreteColleague1 _colleague1;
            private ConcreteColleague2 _colleague2;

            public ConcreteColleague1 Colleague1
            {
                set { _colleague1 = value; }
            }

            public ConcreteColleague2 Colleague2
            {
                set { _colleague2 = value; }
            }

            public override void Send(string message,
                                      Colleague colleague)
            {
                if (colleague == _colleague1)
                {
                    _colleague2.Notify(message);
                }
                else
                {
                    _colleague1.Notify(message);
                }
            }
        }

        private abstract class Mediator
        {
            public abstract void Send(string message,
                                      Colleague colleague);
        }
    }
}