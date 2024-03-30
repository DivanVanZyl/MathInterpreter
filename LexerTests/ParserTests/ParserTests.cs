using Interpreter;
using Lexer;
using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserTests
{
    public class ParserTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void AddNode()
        {
            //Arrange
            string testData = "1+1";
            SimpleLexer lexer = new SimpleLexer();
            SimpleParser parser = new SimpleParser();

            //Act
            var tokens = lexer.GenerateTokens(testData).ToList();
            var tree = parser.Parse(tokens);

            //Assert
            Assert.That(tree.GetType(), Is.EqualTo(typeof(AddNode)));
        }

        [Test]
        public void SubtractNode()
        {
            //Arrange
            string testData = "1-1";
            SimpleLexer lexer = new SimpleLexer();
            SimpleParser parser = new SimpleParser();

            //Act
            var tokens = lexer.GenerateTokens(testData).ToList();
            var tree = parser.Parse(tokens);

            //Assert
            Assert.That(tree.GetType(), Is.EqualTo(typeof(SubtractNode)));
        }

        [Test]
        public void CombinationAddNode()
        {
            //Arrange
            string testData = "1+2+3";
            SimpleLexer lexer = new SimpleLexer();
            SimpleParser parser = new SimpleParser();

            //Act
            var tokens = lexer.GenerateTokens(testData).ToList();
            var tree = parser.Parse(tokens);

            //Assert
            Assert.That(tree.GetType(), Is.EqualTo(typeof(AddNode)));
        }
    }
}
