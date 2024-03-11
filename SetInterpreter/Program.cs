// See https://aka.ms/new-console-template for more information

using System.Diagnostics.Metrics;
using Interpreter;
using InterpreterUI;
using Lexer;
using Microsoft.Extensions.DependencyInjection;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Startup startup = new Startup();
#if SIMPLEMATH
startup.ConfigureServices(ServiceType.Simple);
#elif SET
startup.ConfigureServices(ServiceType.Set); 
#endif
IServiceProvider serviceProvider = startup.Services.BuildServiceProvider();

//Simple example
IRunner interpreter = serviceProvider.GetService<IRunner>();
interpreter.Run(
    Console.ReadLine()
    );
