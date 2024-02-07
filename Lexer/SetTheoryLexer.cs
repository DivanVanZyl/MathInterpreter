namespace Lexer
{
    public class SetTheoryLexer : ILexer
    {
        private string _text;
        private int _position = 0;
        public SetTheoryLexer(string text)
        {
            _text = text;
        }
        public IEnumerable<Token> GenerateTokens()
        {
            while(_position < _text.Length)
            {
                if (_text[_position] == '{')
                {
                    yield return new Token(TokenTypes.TokenType.OpenBrace, _text[_position++]);
                }
                else if (_text[_position] == '}')
                {
                    yield return new Token(TokenTypes.TokenType.CloseBrace, _text[_position++]);
                }
                else if (_text[_position] == ',')
                {
                    yield return new Token(TokenTypes.TokenType.Comma, _text[_position++]);
                }
                else
                {
                    throw new Exception ("Illegal character: " + _text[_position++]);
                }
            }
        }
    }
}
