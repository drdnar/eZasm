﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZasm.Assembler
{
    class InputString : InputSource
    {
        public string ToString()
        {
            return "Input string " + Name;
        }
    }
}
