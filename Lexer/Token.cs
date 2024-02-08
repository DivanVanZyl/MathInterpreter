using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexer
{
    public class TokenTypes
    {
        public enum TokenType
        {
            Number,
            OpenBrace,
            CloseBrace,
            Intersect,
            Union,
            OpenParenthesis,
            CloseParenthesis,
            Comma,
            Equals,
            Variable,
            Set
        }
    }

    //This is a struct as I want to allocate it on the stack for performance reasons.
    public struct Token
    {
        private TokenTypes.TokenType _tokenType;
        private string? _value = null;

        public TokenTypes.TokenType TokenType => _tokenType;
        public string? Value => _value;

        public Token(TokenTypes.TokenType tokenType, string value)
        {
            _tokenType = tokenType;
            _value = value;
        }

        public override string ToString()
        {
            return this._tokenType.ToString() + (_value is not null ? " " + _value.ToString() : "");
        }
    }
}
