using Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpreter;
using Parser;
using static Lexer.TokenTypes;
using static System.Net.Mime.MediaTypeNames;

namespace LexerTests.SimpleMathTests
{
    public class CalculationTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void SimpleCalculation()
        {
            //Arrange
            string testData = "1+1";
            SimpleLexer lexer = new SimpleLexer();
            SimpleParser parser = new SimpleParser();
            SimpleInterpreter interpreter = new SimpleInterpreter();

            //Act
            var tokens = lexer.GenerateTokens(testData).ToList();
            var tree = parser.Parse(tokens);
            var value = interpreter.Visit(tree);

            //Assert
            Assert.That(value, Is.EqualTo(2.0));
        }
    }
}
