﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexer
{
    public interface ILexer
    {
        public IEnumerable<Token> GenerateTokens(string? text);
    }
}
