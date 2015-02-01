using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZasm.Assembler.AssemblerError
{
    public class GenericException : AssemblerException
    {
        public GenericException(InputSource source, int lineNumber, Exception child, string info)
            : base(source, lineNumber, child, info)
        {
            Info += info;
        }

    }
}
