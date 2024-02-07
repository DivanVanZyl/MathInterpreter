using Lexer;

namespace LexerTests
{
    public class SetTheoryLexerTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void SingleNumber()
        {
            //Arrange
            SetTheoryLexer lexer = new SetTheoryLexer("2");

            //Act
            var tokens = lexer.GenerateTokens();
            Token result = tokens.FirstOrDefault();

            //Assert
            Assert.That(result.TokenType,Is.EqualTo(TokenTypes.TokenType.Number));
            Assert.That(result.Value,Is.EqualTo("2"));
        }
    }
}