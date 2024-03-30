using Lexer;
using Lexer.Extensions;
using System.Data;
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

            //Variable assignment operation for eg. A = {1,2,3}
            //TODO

            //Operation expression eg. {1,2,3} /union {3,4,5}
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
                    result = new IntersectNode((SetNode)result, (SetNode)Term());
                }
                else if (_tokens[_position].TokenType == TokenTypes.TokenType.Union)
                {
                    _position++; 
                    result = new UnionNode((SetNode)result, (SetNode)Term());
                }
                else if (_tokens[_position].TokenType == TokenTypes.TokenType.SetDifference)
                {
                    _position++;
                    result = new SetDifferenceNode((SetNode)result, (SetNode)Term());
                }
                else if (_tokens[_position].TokenType == TokenTypes.TokenType.SymmetricSetDifference)
                {
                    _position++;
                    result = new SymmertricSetDifferenceNode((SetNode)result, (SetNode)Term());
                }
            }
            return result;
        }

        private Node Term()
        {
            var result = Factor();

            /*while (_position < _tokens.Count && (false))
            {
                *//* if (_tokens[_position].TokenType == TokenTypes.TokenType.Intersect)
                     //result = new IntersectNode(result, Factor());
                 else if (_tokens[_position].TokenType == TokenTypes.TokenType.Union)*//*
                //result = new UnionNode(result, Factor());
            }*/

            return result;
        }

        private Node Factor()
        {
            //var result = Factor();
            var token = _tokens[_position];

            if (token.TokenType == TokenTypes.TokenType.Set)
            {
                List<string> elements = new List<string>();
                string sub = "";
                for (int i = 0; i < token.Value.Length; i++)
                {
                    char testChar = token.Value[i];
                    if (token.Value[i] != '{' && token.Value[i] != ',' && token.Value[i] != '}')
                    {
                        if (token.Value[i] == '-')
                        {
                            sub += "-";
                            i++;
                        }
                        else if (token.Value[i] == '+')
                        {
                            i++;
                        }
                        sub += token.Value[i];
                    }
                    else if (token.Value[i] != '{')
                    {
                        elements.Add(sub);
                        sub = "";
                    }
                }
                _position++;
                return new SetNode(elements);
            }

            throw new Exception("Invalid factor");
        }
    }
}
