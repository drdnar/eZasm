using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eZasm.Assembler.Tokens;

namespace eZasm.Assembler
{
    class TokenStream
    {
        Lexer Lexer;

        TokenStream Child;

        InputSource InputSource;

        public TokenStream(InputSource source)
        {
            InputSource = source;
            Child = null;
            Lexer = new Lexer(source);
        }

        public Token GetNextToken()
        {
            if (Child != null)
                return Child.GetNextToken();

            return null;
        }

    }
}
