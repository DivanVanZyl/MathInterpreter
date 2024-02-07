using Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerTests.SetTheoryLexerTests
{
    public class SyntaxTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void OpenBrace()
        {
            //Arrange
            SetTheoryLexer lexer = new SetTheoryLexer("{");

            //Act
            var tokens = lexer.GenerateTokens();
            Token result = tokens.FirstOrDefault();

            //Assert
            Assert.That(result.TokenType, Is.EqualTo(TokenTypes.TokenType.OpenBrace));
            Assert.That(result.Value, Is.EqualTo("{"));
        }
        
        [Test]
        public void CloseBrace()
        {
            //Arrange
            SetTheoryLexer lexer = new SetTheoryLexer("}");

            //Act
            var tokens = lexer.GenerateTokens();
            Token result = tokens.FirstOrDefault();

            //Assert
            Assert.That(result.TokenType, Is.EqualTo(TokenTypes.TokenType.CloseBrace));
            Assert.That(result.Value, Is.EqualTo("}"));
        }

        [Test]
        public void Comma()
        {
            //Arrange
            SetTheoryLexer lexer = new SetTheoryLexer(",");

            //Act
            var tokens = lexer.GenerateTokens();
            Token result = tokens.FirstOrDefault();

            //Assert
            Assert.That(result.TokenType, Is.EqualTo(TokenTypes.TokenType.Comma));
            Assert.That(result.Value, Is.EqualTo(","));
        }

        [Test]
        public void Equals()
        {
            //Arrange
            SetTheoryLexer lexer = new SetTheoryLexer("=");

            //Act
            var tokens = lexer.GenerateTokens();
            Token result = tokens.FirstOrDefault();

            //Assert
            //Assert.That(result.TokenType, Is.EqualTo(TokenTypes.TokenType.Equals));
            Assert.That(result.Value, Is.EqualTo("="));
        }

        [Test]
        public void Variable()
        {
            //Arrange
            SetTheoryLexer lexer = new SetTheoryLexer("A");

            //Act
            var tokens = lexer.GenerateTokens();
            Token result = tokens.FirstOrDefault();

            //Assert
            //Assert.That(result.TokenType, Is.EqualTo(TokenTypes.TokenType.Equals));
            Assert.That(result.Value, Is.EqualTo("A"));
        }
    }
}
