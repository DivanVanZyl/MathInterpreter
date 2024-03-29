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

namespace InterpreterTests
{
    public class CalculationTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void SimpleAddition()
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

        [Test]
        public void SimpleSubtraction()
        {
            //Arrange
            string testData = "1-2";
            SimpleLexer lexer = new SimpleLexer();
            SimpleParser parser = new SimpleParser();
            SimpleInterpreter interpreter = new SimpleInterpreter();

            //Act
            var tokens = lexer.GenerateTokens(testData).ToList();
            var tree = parser.Parse(tokens);
            var value = interpreter.Visit(tree);

            //Assert
            Assert.That(value, Is.EqualTo(-1.0));
        }

        [Test]
        public void SimpleMultiplication()
        {
            //Arrange
            string testData = "2*16";
            SimpleLexer lexer = new SimpleLexer();
            SimpleParser parser = new SimpleParser();
            SimpleInterpreter interpreter = new SimpleInterpreter();

            //Act
            var tokens = lexer.GenerateTokens(testData).ToList();
            var tree = parser.Parse(tokens);
            var value = interpreter.Visit(tree);

            //Assert
            Assert.That(value, Is.EqualTo(32.0));
        }

        [Test]
        public void SimpleDivision()
        {
            //Arrange
            string testData = "16/2";
            SimpleLexer lexer = new SimpleLexer();
            SimpleParser parser = new SimpleParser();
            SimpleInterpreter interpreter = new SimpleInterpreter();

            //Act
            var tokens = lexer.GenerateTokens(testData).ToList();
            var tree = parser.Parse(tokens);
            var value = interpreter.Visit(tree);

            //Assert
            Assert.That(value, Is.EqualTo(8.0));
        }

        [Test]
        public void ComplexCalculation_Mixed()
        {
            //Arrange
            string testData = "2+4*2-16/2";
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
