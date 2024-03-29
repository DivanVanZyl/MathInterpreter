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

            var type = tree.GetType();
            //Assert
            Assert.That(tree.GetType(), Is.EqualTo(typeof(AddNode)));
        }
    }
}
