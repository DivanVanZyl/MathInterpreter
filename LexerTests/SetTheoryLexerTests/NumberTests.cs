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
            string testData = "2";
            SetTheoryLexer lexer = new SetTheoryLexer();

            //Act
            var tokens = lexer.GenerateTokens(testData);
            Token result = tokens.FirstOrDefault();

            //Assert
            Assert.That(result.TokenType, Is.EqualTo(TokenTypes.TokenType.Number));
            Assert.That(result.Value, Is.EqualTo(testData));
        }

        [Test]
        public void MultiDigitNumber()
        {
            //Arrange
            string testData = "256";
            SetTheoryLexer lexer = new SetTheoryLexer();

            //Act
            var tokens = lexer.GenerateTokens(testData);
            Token result = tokens.FirstOrDefault();

            //Assert
            Assert.That(result.TokenType, Is.EqualTo(TokenTypes.TokenType.Number));
            Assert.That(result.Value, Is.EqualTo(testData));
        }

        [Test]
        public void NumberWithDecimal()
        {
            //Arrange
            string testData = ".";
            SetTheoryLexer lexer = new SetTheoryLexer();

            //Act
            var tokens = lexer.GenerateTokens(testData);
            Token result = tokens.FirstOrDefault();

            //Assert
            Assert.That(result.TokenType, Is.EqualTo(TokenTypes.TokenType.Number));
            Assert.That(result.Value, Is.EqualTo(testData));
        }
    }
}