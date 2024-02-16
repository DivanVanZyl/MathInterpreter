// See https://aka.ms/new-console-template for more information

using System.Diagnostics.Metrics;
using Lexer;

Console.OutputEncoding = System.Text.Encoding.UTF8;
/*
string text = Console.ReadLine();
//string text = "{10,2.0,3}";
//Console.WriteLine(text);*/


string text = Console.ReadLine();


ILexer lexer = new SimpleLexer(text);
var tokens = lexer.GenerateTokens().ToList();
#if DEBUG
Console.WriteLine("\nLexer Debug: ");
foreach (var token in tokens)
    Console.WriteLine(token.TokenType.ToString());
#endif

/*ILexer lexer = new SetTheoryLexer(text);
var tokens = lexer.GenerateTokens().ToList();
foreach (var token in tokens)
{ Console.WriteLine(token.ToString()); }*/

var parser = new Parser.SimpleParser(tokens);
var tree = parser.Parse();

#if DEBUG
Console.WriteLine("\nParser Debug: ");
Console.WriteLine(tree);
#endif