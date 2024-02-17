using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser;

namespace Interpreter
{
    public interface IInterpreter<T>
    {
        public T Visit(Node node);
    }
}
