using Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Assert.That(results[0].TokenType, Is.EqualTo(TokenTypes.TokenType.OpenBrace));
            Assert.That(results[1].TokenType, Is.EqualTo(TokenTypes.TokenType.Number));
            Assert.That(results[2].TokenType, Is.EqualTo(TokenTypes.TokenType.Comma));
            Assert.That(results[3].TokenType, Is.EqualTo(TokenTypes.TokenType.Number));
            Assert.That(results[4].TokenType, Is.EqualTo(TokenTypes.TokenType.Comma));
            Assert.That(results[5].TokenType, Is.EqualTo(TokenTypes.TokenType.Number));
            Assert.That(results[6].TokenType, Is.EqualTo(TokenTypes.TokenType.CloseBrace));

            for (int i = 0; i < results.Count; i++)
            {
                Assert.That(char.Parse(results[i].Value), Is.EqualTo(testData[i]));
            }
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
            Assert.That(results[2].TokenType, Is.EqualTo(TokenTypes.TokenType.OpenBrace));
            Assert.That(results[3].TokenType, Is.EqualTo(TokenTypes.TokenType.Number));
            Assert.That(results[4].TokenType, Is.EqualTo(TokenTypes.TokenType.Comma));
            Assert.That(results[5].TokenType, Is.EqualTo(TokenTypes.TokenType.Number));
            Assert.That(results[6].TokenType, Is.EqualTo(TokenTypes.TokenType.Comma));
            Assert.That(results[7].TokenType, Is.EqualTo(TokenTypes.TokenType.Number));
            Assert.That(results[8].TokenType, Is.EqualTo(TokenTypes.TokenType.CloseBrace));

            var testDataTrimmed = testData.Replace(" ", "");
            for (int i = 0; i < results.Count; i++)
            {
                Assert.That(char.Parse(results[i].Value), Is.EqualTo(testDataTrimmed[i]));
            }
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
            Assert.That(results[0].TokenType, Is.EqualTo(TokenTypes.TokenType.OpenBrace));
            Assert.That(results[1].TokenType, Is.EqualTo(TokenTypes.TokenType.Number));
            Assert.That(results[2].TokenType, Is.EqualTo(TokenTypes.TokenType.Comma));
            Assert.That(results[3].TokenType, Is.EqualTo(TokenTypes.TokenType.Number));
            Assert.That(results[4].TokenType, Is.EqualTo(TokenTypes.TokenType.Comma));
            Assert.That(results[5].TokenType, Is.EqualTo(TokenTypes.TokenType.Number));
            Assert.That(results[6].TokenType, Is.EqualTo(TokenTypes.TokenType.CloseBrace));

            Assert.That(results[7].TokenType, Is.EqualTo(TokenTypes.TokenType.Union));

            Assert.That(results[8].TokenType, Is.EqualTo(TokenTypes.TokenType.OpenBrace));
            Assert.That(results[9].TokenType, Is.EqualTo(TokenTypes.TokenType.Number));
            Assert.That(results[10].TokenType, Is.EqualTo(TokenTypes.TokenType.Comma));
            Assert.That(results[11].TokenType, Is.EqualTo(TokenTypes.TokenType.Number));
            Assert.That(results[12].TokenType, Is.EqualTo(TokenTypes.TokenType.Comma));
            Assert.That(results[13].TokenType, Is.EqualTo(TokenTypes.TokenType.Number));
            Assert.That(results[14].TokenType, Is.EqualTo(TokenTypes.TokenType.CloseBrace));

            var testDataTrimmed = testData.Replace(" ", "");
            for (int i = 0; i < 7; i++)
            {
                Assert.That(char.Parse(results[i].Value), Is.EqualTo(testDataTrimmed[i]));
            }
            Assert.That(char.Parse(results[7].Value), Is.EqualTo('∪'));
        }
    }
}
