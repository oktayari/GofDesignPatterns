using System;

namespace GoFPatternsLibAdv.BehavioralPatterns
{
    /// <summary>
    ///     he chain-of-responsibility pattern is a design pattern consisting of a
    ///     source of command objects and a series of processing objects.
    ///     Each processing object contains logic that defines the types of command objects that it can handle;
    ///     the rest are passed to the next processing object in the chain.
    ///     A mechanism also exists for adding new processing objects to the end of this chain.
    /// </summary>
    internal class ChainOfResponsibility
    {
        public enum LogLevel
        {
            Info = 1,
            Debug = 2,
            Warning = 4,
            Error = 8,
            FunctionalMessage = 16,
            FunctionalError = 32,
            All = 63
        }

        public void TestChainOfResponsibility()
        {
            // Build the chain of responsibility
            Logger logger = new ConsoleLogger(LogLevel.All);
            Logger logger1 = logger.SetNext(new EmailLogger(LogLevel.FunctionalMessage | LogLevel.FunctionalError));
            Logger logger2 = logger1.SetNext(new FileLogger(LogLevel.Warning | LogLevel.Error));

            // Handled by ConsoleLogger
            logger.Message("Entering function ProcessOrder().", LogLevel.Debug);
            logger.Message("Order record retrieved.", LogLevel.Info);

            // Handled by ConsoleLogger and FileLogger
            logger.Message("Customer Address details missing in Branch DataBase.", LogLevel.Warning);
            logger.Message("Customer Address details missing in Organization DataBase.", LogLevel.Error);

            // Handled by ConsoleLogger and EmailLogger
            logger.Message("Unable to Process Order ORD1 Dated D1 For Customer C1.", LogLevel.FunctionalError);

            // Handled by ConsoleLogger and EmailLogger
            logger.Message("Order Dispatched.", LogLevel.FunctionalMessage);
        }

        public class ConsoleLogger : Logger
        {
            public ConsoleLogger(LogLevel mask)
                : base(mask)
            {
            }

            protected override void WriteMessage(string msg)
            {
                Console.WriteLine("Writing to console: " + msg);
            }
        }

        public class EmailLogger : Logger
        {
            public EmailLogger(LogLevel mask)
                : base(mask)
            {
            }

            protected override void WriteMessage(string msg)
            {
                //Placeholder for mail send logic, usually the email configurations are saved in config file.
                Console.WriteLine("Sending via email: " + msg);
            }
        }

        private class FileLogger : Logger
        {
            public FileLogger(LogLevel mask)
                : base(mask)
            {
            }

            protected override void WriteMessage(string msg)
            {
                //Placeholder for File writing logic
                Console.WriteLine("Writing to Log File: " + msg);
            }
        }

        /// <summary>
        ///     Abstract Handler in chain of responsibility Pattern
        /// </summary>
        public abstract class Logger
        {
            protected LogLevel LogMask;

            // The next Handler in the chain
            protected Logger Next;

            public Logger(LogLevel mask)
            {
                LogMask = mask;
            }

            /// <summary>
            ///     Sets the Next logger to make a list/chain of Handlers
            /// </summary>
            public Logger SetNext(Logger nextlogger)
            {
                Next = nextlogger;
                return nextlogger;
            }

            public void Message(string msg, LogLevel severity)
            {
                if ((severity & LogMask) != 0)
                {
                    WriteMessage(msg);
                }
                if (Next != null)
                {
                    Next.Message(msg, severity);
                }
            }

            protected abstract void WriteMessage(string msg);
        }
    }
}