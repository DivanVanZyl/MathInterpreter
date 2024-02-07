using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexer.Extensions
{
    public static class CharExtensions
    {
        public static bool IsNumber(this char c)
        {
            return Char.IsDigit(c) || c == '.';
        }
    }
}
