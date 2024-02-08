using Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lexer.TokenTypes;

namespace LexerTests.SetTheoryLexerTests
{
    public class ExpressionTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void SimpleExpression()
        {
            //Arrange
            string testData = "{1,2,3}";
            SetTheoryLexer lexer = new SetTheoryLexer(testData);

            //Act
            var tokens = lexer.GenerateTokens();

            List<Token> results = new List<Token>();
            foreach (var token in tokens)
            {
                results.Add(token);
            }

            //Assert
            Assert.That(results[0].TokenType, Is.EqualTo(TokenType.Set));
            Assert.That(results[0].Value, Is.EqualTo(testData));
        }

        [Test]
        public void AssignmentExpression()
        {
            //Arrange
            string testData = "A = {1,2,3}";
            SetTheoryLexer lexer = new SetTheoryLexer(testData);

            //Act
            var tokens = lexer.GenerateTokens();

            List<Token> results = new List<Token>();
            foreach (var token in tokens)
            {
                results.Add(token);
            }

            //Assert
            Assert.That(results[0].TokenType, Is.EqualTo(TokenTypes.TokenType.Variable));
            Assert.That(results[1].TokenType, Is.EqualTo(TokenTypes.TokenType.Equals));
            Assert.That(results[2].TokenType, Is.EqualTo(TokenTypes.TokenType.Set));

            var testDataTrimmed = testData.Replace(" ", "");
            Assert.That(results[0].Value, Is.EqualTo("A"));
            Assert.That(results[1].Value, Is.EqualTo("="));
            Assert.That(results[2].Value, Is.EqualTo("{1,2,3}"));
        }

        [Test]
        public void UnionExpression()
        {
            //Arrange
            string testData = @"{1,2,3} \union {4,5,6}";
            SetTheoryLexer lexer = new SetTheoryLexer(testData);

            //Act
            var tokens = lexer.GenerateTokens();

            List<Token> results = new List<Token>();
            foreach (var token in tokens)
            {
                results.Add(token);
            }

            //Assert
            Assert.That(results[0].TokenType, Is.EqualTo(TokenTypes.TokenType.Set));
            Assert.That(results[1].TokenType, Is.EqualTo(TokenTypes.TokenType.Union));
            Assert.That(results[2].TokenType, Is.EqualTo(TokenTypes.TokenType.Set));
                        
            Assert.That(results[0].Value, Is.EqualTo("{1,2,3}"));
            Assert.That(char.Parse(results[1].Value), Is.EqualTo('∪'));
            Assert.That(results[2].Value, Is.EqualTo("{4,5,6}"));
        }
    }
}
