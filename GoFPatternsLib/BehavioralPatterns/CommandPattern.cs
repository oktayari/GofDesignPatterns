using System;

namespace GoFPatternsLib.BehavioralPatterns
{
    /// <summary>
    ///     Intent
    ///     Encapsulate a request as an object, thereby letting you parameterize clients
    ///     with different requests, queue or log requests, and support undoable operations.
    ///     Promote “invocation of a method on an object” to full object status
    ///     An object-oriented callback
    ///     Problem
    ///     Need to issue requests to objects without knowing anything about the operation
    ///     being requested or the receiver of the request.
    /// </summary>
    internal class CommandPattern
    {
        // "Command" 
        public void TestCommandPattern()
        {
            // Create receiver, command, and invoker 
            var receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            var invoker = new Invoker();

            // Set and execute command 
            invoker.SetCommand(command);
            invoker.ExecuteCommand();

            // Wait for user 
            Console.Read();
        }

        private abstract class Command
        {
            protected readonly Receiver Receiver;

            // Constructor 
            public Command(Receiver receiver)
            {
                Receiver = receiver;
            }

            public abstract void Execute();
        }

        // "ConcreteCommand" 
        private class ConcreteCommand : Command
        {
            // Constructor 
            public ConcreteCommand(Receiver receiver) :
                base(receiver)
            {
            }

            public override void Execute()
            {
                Receiver.Action();
            }
        }

        // "Receiver" 

        // "Invoker" 
        private class Invoker
        {
            private Command _command;

            public void SetCommand(Command command)
            {
                _command = command;
            }

            public void ExecuteCommand()
            {
                _command.Execute();
            }
        }

        private class Receiver
        {
            public void Action()
            {
                Console.WriteLine("Called Receiver.Action()");
            }
        }
    }
}