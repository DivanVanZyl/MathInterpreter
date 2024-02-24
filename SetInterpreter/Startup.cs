using Lexer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser;
using Interpreter;
using System.Diagnostics.Metrics;

namespace InterpreterUI
{
    internal class Startup
    {
        private IServiceCollection _services = new ServiceCollection();
        public IServiceCollection Services => _services;
        public void ConfigureServices()
        {
            _services.AddSingleton<ILexer,SimpleLexer>();
            _services.AddSingleton<IParser,SimpleParser>();
            _services.AddSingleton<IInterpreter<double>,SimpleInterpreter>();
            _services.AddSingleton<IRunner,Runner>();
        }
    }
}
