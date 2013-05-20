using System;
using System.Collections.Generic;
using System.Linq;

namespace GoFPatternsLibAdv.BehavioralPatterns
{
    /// <summary>
    ///     the interpreter pattern is a design pattern that specifies how to evaluate sentences in a language.
    ///     The basic idea is to have a class for each symbol (terminal or nonterminal) in a specialized computer language.
    ///     The syntax tree of a sentence in the language is
    ///     an instance of the composite pattern and is used to evaluate (interpret) the sentence.
    /// </summary>
    internal class InterpreterPattern
    {
        public void TestInterpreter()
        {
            String expression = "w x z - +";
            var sentence = new Evaluator(expression);
            var variables = new Dictionary<String, IExpression>();
            variables.Add("w", new Number(5));
            variables.Add("x", new Number(10));
            variables.Add("z", new Number(42));
            int result = sentence.Interpret(variables);

            Console.WriteLine(result);
        }

        private class Evaluator : IExpression
        {
            private readonly IExpression syntaxTree;


            public Evaluator(String expression)
            {
                var expressionStack = new Stack<IExpression>();


                foreach (String token in expression.Split(' '))
                {
                    if (token.Equals("+"))
                    {
                        IExpression subExpression = new Plus(expressionStack.Pop(), expressionStack.Pop());
                        expressionStack.Push(subExpression);
                    }
                    else if (token.Equals("-"))
                    {
                        // it's necessary remove first the right operand from the stack
                        IExpression right = expressionStack.Pop();
                        // ..and after the left one
                        IExpression left = expressionStack.Pop();
                        IExpression subExpression = new Minus(left, right);
                        expressionStack.Push(subExpression);
                    }
                    else
                        expressionStack.Push(new Variable(token));
                }
                syntaxTree = expressionStack.Pop();
            }

            public int Interpret(Dictionary<String, IExpression> context)
            {
                return syntaxTree.Interpret(context);
            }
        }

        public interface IExpression
        {
            int Interpret(Dictionary<String, IExpression> variables);
        }

        private class Minus : IExpression
        {
            private readonly IExpression leftOperand;
            private readonly IExpression rightOperand;

            public Minus(IExpression left, IExpression right)
            {
                leftOperand = left;
                rightOperand = right;
            }

            public int Interpret(Dictionary<String, IExpression> variables)
            {
                return leftOperand.Interpret(variables) - rightOperand.Interpret(variables);
            }
        }

        private class Number : IExpression
        {
            private readonly int number;

            public Number(int number)
            {
                this.number = number;
            }

            public int Interpret(Dictionary<String, IExpression> variables)
            {
                return number;
            }
        }

        private class Plus : IExpression
        {
            private readonly IExpression leftOperand;
            private readonly IExpression rightOperand;

            public Plus(IExpression left, IExpression right)
            {
                leftOperand = left;
                rightOperand = right;
            }

            public int Interpret(Dictionary<String, IExpression> variables)
            {
                return leftOperand.Interpret(variables) + rightOperand.Interpret(variables);
            }
        }

        public class Variable : IExpression
        {
            private readonly String _name;

            public Variable(String name)
            {
                _name = name;
            }

            public int Interpret(Dictionary<String, IExpression> variables)
            {
                return false ? 0 : Convert.ToInt32(variables.Select(t => t.Key == _name).Single());
            }
        }
    }
}