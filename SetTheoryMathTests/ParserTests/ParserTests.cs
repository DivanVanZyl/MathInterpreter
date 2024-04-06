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
        public void UnionNode()
        {
            //Arrange
            string testData = "{1,2,3} \\union {3,4,5}";
            SetTheoryLexer lexer = new SetTheoryLexer();
            SetTheoryParser parser = new SetTheoryParser();

            //Act
            var tokens = lexer.GenerateTokens(testData).ToList();
            var tree = parser.Parse(tokens);

            //Assert
            Assert.That(tree.GetType(), Is.EqualTo(typeof(UnionNode)));
        }

        [Test]
        public void UnionSingleElementSetNode()
        {
            //Arrange
            string testData = "{1} \\union {2}";
            SetTheoryLexer lexer = new SetTheoryLexer();
            SetTheoryParser parser = new SetTheoryParser();

            //Act
            var tokens = lexer.GenerateTokens(testData).ToList();
            var tree = parser.Parse(tokens);

            var type = tree.GetType();
            //Assert
            Assert.That(tree.GetType(), Is.EqualTo(typeof(UnionNode)));
        }

        [Test]
        public void IntersectNode()
        {
            //Arrange
            string testData = "{1,2,3} \\intersect {3,4,5}";
            SetTheoryLexer lexer = new SetTheoryLexer();
            SetTheoryParser parser = new SetTheoryParser();

            //Act
            var tokens = lexer.GenerateTokens(testData).ToList();
            var tree = parser.Parse(tokens);

            var type = tree.GetType();
            //Assert
            Assert.That(tree.GetType(), Is.EqualTo(typeof(IntersectNode)));
        }

        [Test]
        public void DifferenceNode()
        {
            //Arrange
            string testData = "{1,2,3} \\diff {3,4,5}";
            SetTheoryLexer lexer = new SetTheoryLexer();
            SetTheoryParser parser = new SetTheoryParser();

            //Act
            var tokens = lexer.GenerateTokens(testData).ToList();
            var tree = parser.Parse(tokens);
            var interpteter = new SetTheoryInterpreter();

            //Assert
            Assert.That(tree.GetType(), Is.EqualTo(typeof(SetDifferenceNode)));
            Assert.That(tree.ToString(), Is.EqualTo("{1,2,3} - {3,4,5}"));
        }

        [Test]
        public void SymmetricDifferenceNode()
        {
            //Arrange
            string testData = "{1,2,3} \\sym {3,4,5}";
            SetTheoryLexer lexer = new SetTheoryLexer();
            SetTheoryParser parser = new SetTheoryParser();

            //Act
            var tokens = lexer.GenerateTokens(testData).ToList();
            var tree = parser.Parse(tokens);

            var type = tree.GetType();
            //Assert
            Assert.That(tree.GetType(), Is.EqualTo(typeof(SymmertricSetDifferenceNode)));
        }

        [Test]
        public void CombinationUnionNode()
        {
            //Arrange
            string testData = "{1,2,3} \\union {3,4,5} \\union {6}";
            SetTheoryLexer lexer = new SetTheoryLexer();
            SetTheoryParser parser = new SetTheoryParser();

            //Act
            var tokens = lexer.GenerateTokens(testData).ToList();
            var tree = parser.Parse(tokens);

            var type = tree.GetType();
            //Assert
            Assert.That(tree.GetType(), Is.EqualTo(typeof(UnionNode)));
        }
    }
}
