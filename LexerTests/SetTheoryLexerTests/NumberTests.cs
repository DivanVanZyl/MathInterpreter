using Lexer;

namespace LexerTests.SetTheoryLexerTests
{
    public class NumberTests
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
            Assert.That(result.TokenType, Is.EqualTo(TokenTypes.TokenType.Number));
            Assert.That(result.Value, Is.EqualTo("2"));
        }

        [Test]
        public void MultiDigitNumber()
        {
            //Arrange
            SetTheoryLexer lexer = new SetTheoryLexer("256");

            //Act
            var tokens = lexer.GenerateTokens();
            Token result = tokens.FirstOrDefault();

            //Assert
            Assert.That(result.TokenType, Is.EqualTo(TokenTypes.TokenType.Number));
            Assert.That(result.Value, Is.EqualTo("256"));
        }

        [Test]
        public void NumberWithDecimal()
        {
            //Arrange
            SetTheoryLexer lexer = new SetTheoryLexer(".");

            //Act
            var tokens = lexer.GenerateTokens();
            Token result = tokens.FirstOrDefault();

            //Assert
            Assert.That(result.TokenType, Is.EqualTo(TokenTypes.TokenType.Number));
            Assert.That(result.Value, Is.EqualTo("."));
        }
    }
}