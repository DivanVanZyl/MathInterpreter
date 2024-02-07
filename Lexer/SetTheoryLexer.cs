﻿using Lexer.Extensions;

namespace Lexer
{
    public class SetTheoryLexer : ILexer
    {
        private readonly string _text;
        private int _position = 0;
        public SetTheoryLexer(string text)
        {
            _text = text;
        }
        public IEnumerable<Token> GenerateTokens()
        {
            while(_position < _text.Length)
            {
                if (Char.IsDigit(_text[_position]) || _text[_position] == '.')
                {
                    yield return GenerateNumber();
                }
                else if (_text[_position] == '{')
                {
                    yield return new Token(TokenTypes.TokenType.OpenBrace, _text[_position++].ToString());
                }
                else if (_text[_position] == '}')
                {
                    yield return new Token(TokenTypes.TokenType.CloseBrace, _text[_position++].ToString());
                }
                else if (_text[_position] == ',')
                {
                    yield return new Token(TokenTypes.TokenType.Comma, _text[_position++].ToString());
                }
                else
                {
                    throw new Exception ("Illegal character: " + _text[_position++]);
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
            return new Token(TokenTypes.TokenType.Number,number);
        }        
    }
}
