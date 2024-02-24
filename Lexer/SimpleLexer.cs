using Lexer.Extensions;
using System.Security.AccessControl;
using static Lexer.TokenTypes;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lexer
{
    public class SimpleLexer : ILexer
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
                    else if (_text[_position] == '=')
                    {
                        yield return new Token(TokenType.Equals, _text[_position++].ToString());
                    }
                    else if (_text[_position] == '+')
                    {
                        yield return new Token(TokenType.Plus, _text[_position++].ToString());
                    }
                    else if (_text[_position] == '-')
                    {
                        yield return new Token(TokenType.Minus, _text[_position++].ToString());
                    }
                    else if (_text[_position] == '*')
                    {
                        yield return new Token(TokenType.Multiply, _text[_position++].ToString());
                    }
                    else if (_text[_position] == '/')
                    {
                        yield return new Token(TokenType.Divide, _text[_position++].ToString());
                    }
                    else if (_text[_position] == '(')
                    {
                        yield return new Token(TokenType.OpenParenthesis, _text[_position++].ToString());
                    }
                    else if (_text[_position] == ')')
                    {
                        yield return new Token(TokenType.CloseParenthesis, _text[_position++].ToString());
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
    }
}
