using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZasm.Assembler
{
    /// <summary>
    /// More or less, a line of source code
    /// </summary>
    public class Statement
    {
        public List<Lexeme> Tokens = new List<Lexeme>();
    }
}
