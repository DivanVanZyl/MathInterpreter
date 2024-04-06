using Interpreter;
using Lexer;
using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterTests
{
    public  class ExpressionTests
    {        
        [Test]
        public void EmptySetDifferenceNode()
        {
            //Arrange
            string testData = "{1,2,3} \\diff {1,2,3}";
            SetTheoryLexer lexer = new SetTheoryLexer();
            SetTheoryParser parser = new SetTheoryParser();
            SetTheoryInterpreter interpreter = new SetTheoryInterpreter();

            //Act
            var tokens = lexer.GenerateTokens(testData).ToList();
            var tree = parser.Parse(tokens);
            var result = interpreter.Visit(tree);

            //Assert
            Assert.That(result, Is.EqualTo("{}"));
        }
        [Test]
        public void DifferenceNode()
        {
            //Arrange
            string testData = "{1,2,3} \\diff {3,4,5}";
            SetTheoryLexer lexer = new SetTheoryLexer();
            SetTheoryParser parser = new SetTheoryParser();
            SetTheoryInterpreter interpreter = new SetTheoryInterpreter();

            //Act
            var tokens = lexer.GenerateTokens(testData).ToList();
            var tree = parser.Parse(tokens);
            var result = interpreter.Visit(tree);

            //Assert
            Assert.That(result, Is.EqualTo("{1,2}"));
        }
    }
}
