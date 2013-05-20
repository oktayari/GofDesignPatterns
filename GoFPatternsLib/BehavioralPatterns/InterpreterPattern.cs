using System;
using System.Collections;

namespace GoFPatternsLib.BehavioralPatterns
{
    /// <summary>
    ///     Intent
    ///     Given a language, define a representation for its grammar along with an interpreter
    ///     that uses the representation to interpret sentences in the language.
    ///     Map a domain to a language, the language to a grammar, and the grammar to
    ///     a hierarchical object-oriented design.
    ///     Problem A class of problems occurs repeatedly in a well-defined and well-understood domain.
    ///     If the domain were characterized with a “language”,
    ///     then problems could be easily solved with an interpretation “engine”.
    /// </summary>
    internal class InterpreterPattern
    {
        // "Context" 

        // "AbstractExpression" 
        public void TestInterpreterPattern()
        {
            var context = new Context();

            // Usually a tree 
            var list = new ArrayList();

            // Populate 'abstract syntax tree' 
            list.Add(new TerminalExpression());
            list.Add(new NonterminalExpression());
            list.Add(new TerminalExpression());
            list.Add(new TerminalExpression());

            // Interpret 
            foreach (AbstractExpression exp in list)
            {
                exp.Interpret(context);
            }

            // Wait for user 
            Console.Read();
        }

        private abstract class AbstractExpression
        {
            public abstract void Interpret(Context context);
        }

        private class Context
        {
        }

        // "TerminalExpression" 

        // "NonterminalExpression" 
        private class NonterminalExpression : AbstractExpression
        {
            public override void Interpret(Context context)
            {
                Console.WriteLine("Called Nonterminal.Interpret()");
            }
        }

        private class TerminalExpression : AbstractExpression
        {
            public override void Interpret(Context context)
            {
                Console.WriteLine("Called Terminal.Interpret()");
            }
        }
    }
}