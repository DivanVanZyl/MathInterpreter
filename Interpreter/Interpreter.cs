using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser;

namespace Interpreter
{
    internal class SimpleInterpreter: IInterpreter<double>
    {
        public double Visit(Node node)
        {
            throw new NotImplementedException();
        }
    }
}
