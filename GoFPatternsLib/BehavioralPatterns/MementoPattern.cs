using System;

namespace GoFPatternsLib.BehavioralPatterns
{
    /// <summary>
    ///     Intent
    ///     Without violating encapsulation, capture and externalize an object’s internal state
    ///     so that the object can be returned to this state later.
    ///     A magic cookie that encapsulates a “check point” capability.
    ///     Promote undo or rollback to full object status.
    ///     Problem
    ///     Need to restore an object back to its previous state (e.g. “undo” or “rollback” operations).
    /// </summary>
    internal class MementoPattern
    {
        // The 'Originator' class


        public void TestMementoPattern()
        {
            var o = new Originator();
            o.State = "On";

            // Store internal state
            var c = new Caretaker();
            c.Memento = o.CreateMemento();

            // Continue changing originator
            o.State = "Off";

            // Restore saved state
            o.SetMemento(c.Memento);

            // Wait for user
            Console.ReadKey();
        }

        private class Caretaker
        {
            // Gets or sets memento
            public Memento Memento { set; get; }
        }

        private class Memento
        {
            private readonly string _state;

            // Constructor
            public Memento(string state)
            {
                _state = state;
            }

            // Gets or sets state
            public string State
            {
                get { return _state; }
            }
        }

        private class Originator
        {
            private string _state;

            // Property
            public string State
            {
/*
                get { return _state; }
*/
                set
                {
                    _state = value;
                    Console.WriteLine("State = " + _state);
                }
            }

            // Creates memento 
            public Memento CreateMemento()
            {
                return (new Memento(_state));
            }

            // Restores original state
            public void SetMemento(Memento memento)
            {
                Console.WriteLine("Restoring state...");
                State = memento.State;
            }
        }
    }
}