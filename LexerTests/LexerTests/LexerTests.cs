using Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerTests
{
    public class LexerTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GranularLexerOutputItems()
        {
            //Arrange
            string testData = "1+1-(1*2)";
            SimpleLexer lexer = new SimpleLexer();

            //Act
            var tokens = lexer.GenerateTokens(testData).ToList();

            //Assert
            Assert.That(tokens.GetType(), Is.EqualTo(typeof(List<Token>)));
        }
    }
}
