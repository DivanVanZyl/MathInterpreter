using Lexer;
using Lexer.Extensions;
using System.Data;
using System.Linq.Expressions;

namespace Parser
{
    /*The SetTheoryParser builds a tree of what needs to happen.*/
    public class SetTheoryParser
    {
        private List<Token> _tokens;
        private int _position = 0;

        public Node Parse(List<Token>? tokens)
        {
            var result = Expr();

            if (_position < _tokens.Count - 1)
                throw new Exception("Invalid expression");

            return result;
        }

        private Node Expr()
        {
            var result = Term();

            while (_position < _tokens.Count && (_tokens[_position].TokenType == TokenTypes.TokenType.Intersect || _tokens[_position].TokenType == TokenTypes.TokenType.Union))
            {
                if (_tokens[_position].TokenType == TokenTypes.TokenType.Intersect)
                    result = new IntersectNode((SetNode)result, (SetNode)Term());
                else if (_tokens[_position].TokenType == TokenTypes.TokenType.Union)
                    result = new UnionNode((SetNode)result, (SetNode)Term());
            }
            return result;
        }

        private Node Term()
        {
            var result = Factor();

            while (_position < _tokens.Count && (false))
            {
                /* if (_tokens[_position].TokenType == TokenTypes.TokenType.Intersect)
                     //result = new IntersectNode(result, Factor());
                 else if (_tokens[_position].TokenType == TokenTypes.TokenType.Union)*/
                //result = new UnionNode(result, Factor());
            }

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
                    bool isElement = false;
                    if (token.Value[i] != '{' && token.Value[i] != ',' && token.Value[i] != '}')
                    {
                        sub += token.Value[i];
                    }
                    else if (token.Value[i] != '{')
                    {
                        elements.Add(sub);
                        sub = "";
                    }
                }
                return new SetNode(elements);
            }

            throw new Exception("Invalid factor");
        }
    }
}
