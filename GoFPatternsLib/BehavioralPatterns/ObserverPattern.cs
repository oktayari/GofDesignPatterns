using System;
using System.Collections;

namespace GoFPatternsLib.BehavioralPatterns
{
    /// <summary>
    ///     Intent
    ///     Define a one-to-many dependency between objects so that when one object changes state,
    ///     all its dependents are notified and updated automatically.
    ///     Encapsulate the core (or common or engine) components in a Subject abstraction,
    ///     and the variable (or optional or user interface) components in an Observer hierarchy.
    ///     The “View” part of Model-View-Controller.
    ///     Problem
    ///     A large monolithic design does not scale well as new graphing or
    ///     monitoring requirements are levied.
    /// </summary>
    internal class ObserverPattern
    {
        // "Subject" 

        // "ConcreteSubject" 
        public void TestObserverPattern()
        {
            // Configure Observer pattern 
            var s = new ConcreteSubject();

            s.Attach(new ConcreteObserver(s, "X"));
            s.Attach(new ConcreteObserver(s, "Y"));
            s.Attach(new ConcreteObserver(s, "Z"));

            // Change subject and notify observers 
            s.SubjectState = "ABC";
            s.Notify();

            // Wait for user 
            Console.Read();
        }

        private class ConcreteObserver : Observer
        {
            private readonly string _name;
            private string _observerState;

            // Constructor 
            public ConcreteObserver(
                ConcreteSubject subject, string name)
            {
                Subject = subject;
                _name = name;
            }

            // Property 
            public ConcreteSubject Subject { get; set; }

            public override void Update()
            {
                _observerState = Subject.SubjectState;
                Console.WriteLine("Observer {0}'s new state is {1}",
                                  _name, _observerState);
            }
        }

        private class ConcreteSubject : Subject
        {
            // Property 
            public string SubjectState { get; set; }
        }

        // "Observer" 
        private abstract class Observer
        {
            public abstract void Update();
        }

        private abstract class Subject
        {
            private readonly ArrayList _observers = new ArrayList();

            public void Attach(Observer observer)
            {
                _observers.Add(observer);
            }

            public void Detach(Observer observer)
            {
                _observers.Remove(observer);
            }

            public void Notify()
            {
                foreach (Observer o in _observers)
                {
                    o.Update();
                }
            }
        }

        // "ConcreteObserver" 
    }
}