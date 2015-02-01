using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZasm.Assembler.AssemblerError
{
    public abstract class AssemblerException : Exception
    {
        public InputSource Source;
        public int LineNumber;
        protected string Info;
        AssemblerException Child;

        public AssemblerException(InputSource source, int lineNumber, Exception child, string info)
            : base(info, child)
        {
            Info = Source.ToString() + " line " + lineNumber.ToString() + ": ";
            Source = source;
            LineNumber = lineNumber;
        }

        public override string Message
        {
            get
            {
                return Info;
            }
        }
    }
}
