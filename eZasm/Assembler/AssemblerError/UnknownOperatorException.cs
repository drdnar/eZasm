using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZasm.Assembler.AssemblerError
{
    public class UnknownOperatorException : AssemblerException
    {
        public UnknownOperatorException(InputSource source, int lineNumber, Exception child, string info)
            : base(source, lineNumber, child, info)
        {
            Info += "Invalid operator \'" + info + "\'.";
        }

    }
}
