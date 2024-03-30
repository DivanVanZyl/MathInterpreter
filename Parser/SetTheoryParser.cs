using Lexer;
using Lexer.Extensions;
using System.Data;
using System.Globalization;
using System.Linq.Expressions;

namespace Parser
{
    /*The SetTheoryParser builds a tree of what needs to happen.*/
    public class SetTheoryParser : IParser
    {
        private List<Token> _tokens;
        private int _position = 0;
        public Node Parse(List<Token>? tokens)
        {
            if (tokens is not null && tokens.Count > 0)
                _tokens = tokens;
            else
                throw new InvalidDataException("You cannot create a parser with zero tokens.");

            var result = Expression();  //This Node would be the "root" node of the tree.

            if (_position < _tokens.Count - 1)  //In this case, not all nodes have been processed, and is caused by invalid syntax/expression
                throw new Exception("Invalid syntax");

            return result;
        }

        private Node Expression()
        {
            var result = Term();

            while (_position < _tokens.Count && (_tokens[_position].TokenType == TokenTypes.TokenType.Intersect
                            || _tokens[_position].TokenType == TokenTypes.TokenType.Union
                            || _tokens[_position].TokenType == TokenTypes.TokenType.SetDifference
                            || _tokens[_position].TokenType == TokenTypes.TokenType.SymmetricSetDifference))
            {
                if (_tokens[_position].TokenType == TokenTypes.TokenType.Intersect)
                {
                    _position++;
                    result = new IntersectNode(result, Term());
                }
                else if (_tokens[_position].TokenType == TokenTypes.TokenType.Union)
                {
                    _position++; 
                    result = new UnionNode(result, Term());
                }
                else if (_tokens[_position].TokenType == TokenTypes.TokenType.SetDifference)
                {
                    _position++;
                    result = new SetDifferenceNode(result, Term());
                }
                else if (_tokens[_position].TokenType == TokenTypes.TokenType.SymmetricSetDifference)
                {
                    _position++;
                    result = new SymmertricSetDifferenceNode(result, Term());
                }
            }
            return result;
        }

        //Term is a set or another expression
        private Node Term()
        {
            if(_tokens[_position].TokenType != TokenTypes.TokenType.OpenBrace)
                throw new Exception("Invalid Syntax: Expected { at the start of the set, but received: " + _tokens[_position].Value + " of type: " + _tokens[_position].TokenType);

            _position++;
            SetNode result = new SetNode( new List<Node> { Factor() });

            while (_position < _tokens.Count && (_tokens[_position].TokenType == TokenTypes.TokenType.Comma))
            {
                _position++;
                result.AddNode(Factor());
            }

            if(_tokens[_position].TokenType == TokenTypes.TokenType.CloseBrace)
            {
                _position++;
                return result;
            }
            else
            {
                throw new Exception("Invalid Syntax: Expected } at the end of the set, but received: " + _tokens[_position].Value + " of type: " + _tokens[_position].TokenType);
            }
        }

        //Factor is a specific element
        private Node Factor()
        {
            var token = _tokens[_position];
            if (token.TokenType == TokenTypes.TokenType.Element)
            {
                return new ElementNode(_tokens[_position++].Value);
            }

            throw new Exception("Invalid Element");
        }
    }
}
