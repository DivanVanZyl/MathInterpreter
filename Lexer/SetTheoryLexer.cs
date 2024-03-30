using Lexer.Extensions;
using System.Security.AccessControl;
using static Lexer.TokenTypes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lexer
{
    public class SetTheoryLexer : ILexer
    {
        private string _text;
        private int _position = 0;
        public IEnumerable<Token> GenerateTokens(string? text)
        {
            if(text is not null)
                _text = text;

            while (_position < _text.Length)
            {
                if (_text[_position].IsWhitespace())
                {
                    _position++;
                }
                else
                {
                    if (Char.IsDigit(_text[_position]) || _text[_position] == '.')
                    {
                        yield return GenerateNumber();
                    }
                    else if (_text[_position] == '\\')
                    {
                        yield return GenerateSetTheoryOperator();
                    }
                    else if (_text[_position] == '{')
                    {
                        yield return GenerateSet();
                    }
                    else if (_text[_position] == '}')
                    {
                        yield return new Token(TokenType.CloseBrace, _text[_position++].ToString());
                    }   
                    else if (_text[_position] == ',')
                    {
                        yield return new Token(TokenType.Comma, _text[_position++].ToString());
                    }
                    else if (_text[_position] == '=')
                    {
                        yield return new Token(TokenType.Equals, _text[_position++].ToString());
                    }
                    else if (_text[_position].IsLetter())
                    {
                        yield return new Token(TokenType.Variable, _text[_position++].ToString());
                    }
                    else if (_text[_position] == '∩')
                    {
                        yield return new Token(TokenType.Intersect, _text[_position++].ToString());
                    }
                    else if (_text[_position] == '∪')
                    {
                        yield return new Token(TokenType.Union, _text[_position++].ToString());
                    }
                    else if (_text[_position] == '(')
                    {
                        yield return new Token(TokenType.OpenParenthesis, _text[_position++].ToString());
                    }
                    else if (_text[_position] == ')')
                    {
                        yield return new Token(TokenType.CloseParenthesis, _text[_position++].ToString());
                    }
                    else if (_text[_position] == '∅')
                    {
                        yield return new Token(TokenType.CloseParenthesis, _text[_position++].ToString());
                    }
                    else if (_text[_position] == '-')
                    {
                        yield return new Token(TokenType.SetDifference, _text[_position++].ToString());
                    }
                    else if (_text[_position] == '+')
                    {
                        yield return new Token(TokenType.SymmetricSetDifference, _text[_position++].ToString());
                    }
                    else
                    {
                        throw new Exception("Illegal character: " + _text[_position++]);
                    }
                }
            }
        }

        private Token GenerateNumber()
        {
            string number = "";
            while (_position < _text.Length && _text[_position].IsNumber())
            {
                number += _text[_position++].ToString();
            }
            return new Token(TokenType.Number, number);
        }

        private Token GenerateSet()
        {
            string set = "";
            while (_position < _text.Length && _text[_position] != '}')
            {
                set += _text[_position++].ToString();
            }
            set += _text[_position++].ToString();

            return new Token(TokenType.Set, set);
        }

        private Token GenerateSetTheoryOperator()
        {
            string operatorText = "";
            while (_position < _text.Length && (_text[_position].IsLetter() || _text[_position] == '\\'))
            {
                operatorText += _text[_position++].ToString();
            }
            if (operatorText.ToLower() == @"\int" || operatorText.ToLower() == @"\intersect")
            {
                return new Token(TokenType.Intersect, "∩");
            }
            else if (operatorText.ToLower() == @"\un" || operatorText.ToLower() == @"\union")
            {
                return new Token(TokenType.Union, "∪");
            }
            else
            {
                throw new Exception("Illegal set theory operator: " + operatorText);
            }
        }
    }
}
