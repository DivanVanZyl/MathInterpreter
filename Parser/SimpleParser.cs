using Lexer;
using Lexer.Extensions;
using System.Data;
using System.Linq.Expressions;

namespace Parser
{
    /*The SimpleParser builds a tree of what needs to happen.*/
    public class SimpleParser
    {
        private List<Token> _tokens;
        private int _position = 0;
        public SimpleParser(List<Token> tokens)
        {
            if (tokens.Count == 0)
                throw new InvalidDataException("You cannot create a parser with zero tokens.");
            _tokens = tokens;
        }

        public Node Parse()
        {
            var result = Expression();  //This Node would be the "root" node of the tree.

            if (_position < _tokens.Count - 1)  //In this case, not all nodes have been processed, and is caused by invalid syntax/expression
                throw new Exception("Invalid syntax");

            return result;
        }

        /// <summary>
        /// Looks for the plus and minus operations: Term (plus OR minus) Term
        /// </summary>
        /// <returns></returns>
        private Node Expression()
        {
            var result = Term();

            while (_position < _tokens.Count && (_tokens[_position].TokenType == TokenTypes.TokenType.Plus || _tokens[_position].TokenType == TokenTypes.TokenType.Minus))
            {
                if(_tokens[_position].TokenType == TokenTypes.TokenType.Plus)
                {
                    _position++;
                    result = new AddNode(result, Term());    
                }
                else if (_tokens[_position].TokenType == TokenTypes.TokenType.Minus)
                {
                    _position++;
                    result = new SubtractNode(result, Term());
                }
            }
            return result;
        }

        /// <summary>
        /// Look for multiply and divide operators, which take the most precedence: Factor (multiply OR divide) AnotherFactor.
        /// Note, that a term has zero or more operators. eg. you could have a term like 8, 8*2, 2*2/16 etc.
        /// </summary>
        /// <returns></returns>
        private Node Term()
        {
            var result = Factor();

            while (_position < _tokens.Count && (_tokens[_position].TokenType == TokenTypes.TokenType.Multiply || _tokens[_position].TokenType == TokenTypes.TokenType.Divide))
            {
                if (_tokens[_position].TokenType == TokenTypes.TokenType.Multiply)
                {
                    _position++;
                    result = new MultiplyNode(result, Factor());
                }
                else if (_tokens[_position].TokenType == TokenTypes.TokenType.Divide)
                {
                    _position++;
                    result = new DivideNode(result, Factor());
                }
            }
            return result;
        }

        /// <summary>
        /// Look for a number token. A factor will consist of a number.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private Node Factor()
        {
            //var result = Factor();
            var token = _tokens[_position];

            if (token.TokenType == TokenTypes.TokenType.Number)
            {                
                return new NumberNode(float.Parse(_tokens[_position++].Value));
            }
            if(token.TokenType  == TokenTypes.TokenType.Plus)
            {
                _position++;
                return new PlusNode(Factor());
            }
            if (token.TokenType == TokenTypes.TokenType.Minus)
            {
                _position++;
                return new MinusNode(Factor());
            }

            throw new Exception("Invalid factor syntax");
        }
    }
}
