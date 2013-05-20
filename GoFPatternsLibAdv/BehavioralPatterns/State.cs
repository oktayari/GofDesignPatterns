using System;

namespace GoFPatternsLibAdv.BehavioralPatterns
{
    /// <summary>
    ///     The state pattern, which closely resembles Strategy Pattern, is a behavioral software design pattern,
    ///     also known as the objects for states pattern.
    ///     This pattern is used in computer programming to encapsulate varying behavior
    ///     for the same routine based on an object's state object.
    ///     This can be a cleaner way for an object to change its behavior at runtime without resorting
    ///     to large monolithic conditional statements
    /// </summary>
    internal class StatePattern
    {
        public void TestState()
        {
            var sc = new StateContext();

            sc.WriteName("Monday");
            sc.WriteName("Tuesday");
            sc.WriteName("Wednesday");
            sc.WriteName("Thursday");
            sc.WriteName("Friday");
            sc.WriteName("Saturday");
            sc.WriteName("Sunday");
        }

        internal interface IStatelike
        {
            void WriteName(StateContext stateContext, String name);
        }

        private class StateA : IStatelike
        {
            public void WriteName(StateContext stateContext, String name)
            {
                Console.WriteLine(name.ToLower());
                stateContext.SetState(new StateB());
            }
        }

        private class StateB : IStatelike
        {
            /** State counter */
            private int _count;


            public void WriteName(StateContext stateContext, String name)
            {
                Console.WriteLine(name.ToUpper());
                // Change state after StateB's writeName() gets invoked twice
                if (++_count > 1)
                {
                    stateContext.SetState(new StateA());
                }
            }
        }

        public class StateContext
        {
            private IStatelike _myState;

            public StateContext()
            {
                SetState(new StateA());
            }

            public void SetState(IStatelike newState)
            {
                _myState = newState;
            }


            public void WriteName(String name)
            {
                _myState.WriteName(this, name);
            }
        }
    }
}