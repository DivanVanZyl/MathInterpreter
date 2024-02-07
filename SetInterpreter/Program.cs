﻿// See https://aka.ms/new-console-template for more information

using System.Diagnostics.Metrics;
using Lexer;

string text = Console.ReadLine();
//string text = "{10,2.0,3}";
//Console.WriteLine(text);

ILexer lexer = new SetTheoryLexer(text);
var tokens = lexer.GenerateTokens();
foreach (var token in tokens)
{ Console.WriteLine( token.ToString()); }