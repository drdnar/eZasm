using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZasm.Assembler
{
    /// <summary>
    /// Represents an input file
    /// </summary>
    public abstract class InputSource
    {
        /// <summary>
        /// File name or other name
        /// </summary>
        public string Name;

        /// <summary>
        /// Contents
        /// </summary>
        public string Text;
    }
}
