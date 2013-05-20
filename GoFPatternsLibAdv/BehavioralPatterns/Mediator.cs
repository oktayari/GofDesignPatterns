using System;

namespace GoFPatternsLibAdv.BehavioralPatterns
{
    internal class MediatorPattern
    {
        public void TestMeadator()
        {
            var m = new ConcreteMediator();


            var c1 = new ConcreteColleague1(m);

            var c2 = new ConcreteColleague2(m);


            m.Colleague1 = c1;

            m.Colleague2 = c2;


            c1.Send("How are you?");

            c2.Send("Fine, thanks");


            // Wait for user

            Console.ReadKey();
        }

        /// <summary>
        ///     The 'Colleague' abstract class
        /// </summary>
        private abstract class Colleague
        {
            protected readonly Mediator mediator;


            // Constructor

            public Colleague(Mediator mediator)
            {
                this.mediator = mediator;
            }
        }


        /// <summary>
        ///     A 'ConcreteColleague' class
        /// </summary>
        private class ConcreteColleague1 : Colleague
        {
            // Constructor

            public ConcreteColleague1(Mediator mediator)
                : base(mediator)
            {
            }


            public void Send(string message)
            {
                mediator.Send(message, this);
            }


            public void Notify(string message)
            {
                Console.WriteLine("Colleague1 gets message: "
                                  + message);
            }
        }


        /// <summary>
        ///     A 'ConcreteColleague' class
        /// </summary>
        private class ConcreteColleague2 : Colleague
        {
            // Constructor

            public ConcreteColleague2(Mediator mediator)
                : base(mediator)
            {
            }


            public void Send(string message)
            {
                mediator.Send(message, this);
            }


            public void Notify(string message)
            {
                Console.WriteLine("Colleague2 gets message: "
                                  + message);
            }
        }

        /// <summary>
        ///     The 'ConcreteMediator' class
        /// </summary>
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


            public override void Send(string message, Colleague colleague)
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

        /// <summary>
        ///     The essence of the Mediator Pattern is to "Define an object that encapsulates
        ///     how a set of objects interact. Mediator promotes loose coupling by keeping objects from referring to each other explicitly,
        ///     and it lets you vary their interaction independently
        /// </summary>
        private abstract class Mediator
        {
            public abstract void Send(string message, Colleague colleague);
        }
    }
}