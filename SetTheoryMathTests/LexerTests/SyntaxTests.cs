using Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerTests
{
    public class SyntaxTests
    {
        [SetUp]
        public void Setup()
        {

        }
        
        [Test]
        public void CloseBrace()
        {
            //Arrange
            string testData = "}";
            SetTheoryLexer lexer = new SetTheoryLexer();

            //Act
            var tokens = lexer.GenerateTokens(testData);
            Token result = tokens.FirstOrDefault();

            //Assert
            Assert.That(result.TokenType, Is.EqualTo(TokenTypes.TokenType.CloseBrace));
            Assert.That(result.Value, Is.EqualTo(testData));
        }

        [Test]
        public void Comma()
        {
            //Arrange
            string testData = ",";
            SetTheoryLexer lexer = new SetTheoryLexer();

            //Act
            var tokens = lexer.GenerateTokens(testData);
            Token result = tokens.FirstOrDefault();

            //Assert
            Assert.That(result.TokenType, Is.EqualTo(TokenTypes.TokenType.Comma));
            Assert.That(result.Value, Is.EqualTo(testData));
        }

        [Test]
        public void Equals()
        {
            //Arrange
            string testData = "=";
            SetTheoryLexer lexer = new SetTheoryLexer();

            //Act
            var tokens = lexer.GenerateTokens(testData);
            Token result = tokens.FirstOrDefault();

            //Assert
            Assert.That(result.TokenType, Is.EqualTo(TokenTypes.TokenType.Equals));
            Assert.That(result.Value, Is.EqualTo(testData));
        }

        [Test]
        public void Variable()
        {
            //Arrange
            string testData = "A";
            SetTheoryLexer lexer = new SetTheoryLexer();

            //Act
            var tokens = lexer.GenerateTokens(testData);
            Token result = tokens.FirstOrDefault();

            //Assert
            //Assert.That(result.TokenType, Is.EqualTo(TokenTypes.TokenType.Equals));
            Assert.That(result.Value, Is.EqualTo(testData));
        }
    }
}
