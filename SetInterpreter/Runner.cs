﻿using Interpreter;
using Lexer;
using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterUI
{
    public class Runner(ILexer lexer, IParser parser, IInterpreter<double> interpreter) : IRunner
    {
        private ILexer _lexer = lexer;
        private IParser _parser = parser;
        private IInterpreter<double> _interpreter = interpreter;
        public void Run(string text)
        {
            try
            {
                var tokens = lexer.GenerateTokens(text).ToList();
#if DEBUG
                Console.WriteLine("\nLexer Debug: ");
                foreach (var token in tokens)
                    Console.WriteLine(token.TokenType.ToString());
#endif
                var tree = parser.Parse(tokens);

#if DEBUG
                Console.WriteLine("\nParser Debug: ");
                Console.WriteLine(tree);
#endif
                var value = interpreter.Visit(tree);
                Console.WriteLine(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    public interface IRunner
    {
        public void Run(string text);
    }
}
