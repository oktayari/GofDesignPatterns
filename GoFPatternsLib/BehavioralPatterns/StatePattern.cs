using System;

namespace GoFPatternsLib.BehavioralPatterns
{
    /// <summary>
    ///     Intent
    ///     Allow an object to alter its behavior when its internal state changes.
    ///     The object will appear to change its class.
    ///     An object-oriented state machine
    ///     wrapper + polymorphic wrappee + collaboration
    ///     Problem
    ///     A monolithic object’s behavior is a function of its state,
    ///     and it must change its behavior at run-time depending on that state.
    ///     Or, an application is characterixed by large and numerous case statements t
    ///     hat vector flow of control based on the state of the application.
    /// </summary>
    internal class StatePattern
    {
        // "State" 

        // "ConcreteStateA" 
        public void TestStatePattern()
        {
            // Setup context in a state 
            var c = new Context(new ConcreteStateA());

            // Issue requests, which toggles state 
            c.Request();
            c.Request();
            c.Request();
            c.Request();

            // Wait for user 
            Console.Read();
        }

        private class ConcreteStateA : State
        {
            public override void Handle(Context context)
            {
                context.State = new ConcreteStateB();
            }
        }

        // "ConcreteStateB" 
        private class ConcreteStateB : State
        {
            public override void Handle(Context context)
            {
                context.State = new ConcreteStateA();
            }
        }

        // "Context" 
        private class Context
        {
            private State _state;

            // Constructor 
            public Context(State state)
            {
                State = state;
            }

            // Property 
            public State State
            {
/*
                get { return _state; }
*/
                set
                {
                    _state = value;
                    Console.WriteLine("State: " +
                                      _state.GetType().Name);
                }
            }

            public void Request()
            {
                _state.Handle(this);
            }
        }

        private abstract class State
        {
            public abstract void Handle(Context context);
        }
    }
}