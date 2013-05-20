using System;
using System.Collections.Generic;

namespace GoFPatternsLibAdv.BehavioralPatterns
{
    /// <summary>
    ///     The memento pattern is a software design pattern that provides the ability
    ///     to restore an object to its previous state (undo via rollback).
    ///     The memento pattern is implemented with two objects: the originator and a caretaker.
    /// </summary>
    internal class MementoPattern
    {
        public void TestMemento()
        {
            var savedStates = new List<Originator.Memento>();

            var originator = new Originator();
            originator.Set("State1");
            originator.Set("State2");
            savedStates.Add(originator.SaveToMemento());
            originator.Set("State3");
            // We can request multiple mementos, and choose which one to roll back to.
            savedStates.Add(originator.SaveToMemento());
            originator.Set("State4");

            originator.RestoreFromMemento(savedStates[1]);
        }

        public class Originator
        {
            private String _state;
            // The class could also contain additional data that is not part of the
            // state saved in the memento.

            public void Set(String state)
            {
                Console.WriteLine("Originator: Setting state to " + state);

                _state = state;
            }

            public Memento SaveToMemento()
            {
                Console.WriteLine("Originator: Saving to Memento.");

                return new Memento(_state);
            }

            public void RestoreFromMemento(Memento memento)
            {
                _state = memento.GetSavedState();
                Console.WriteLine("Originator: State after restoring from Memento: " + _state);
            }

            public class Memento
            {
                private static String state;

                public Memento(String stateToSave)
                {
                    state = stateToSave;
                }

                public String GetSavedState()
                {
                    return state;
                }
            }
        }
    }
}