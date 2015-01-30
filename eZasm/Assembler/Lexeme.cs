using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZasm.Assembler
{
    /// <summary>
    /// Class for individual tokens. It might seem like overkill, but it'll
    /// make doing macros that alter the program easier.
    /// </summary>
    public class Lexeme
    {
        /// <summary>
        /// Specifies the file this token appears in
        /// </summary>
        public readonly InputSource File;
        
        /// <summary>
        /// Specifies the line number in the file this token appears in
        /// </summary>
        public readonly int Line;

        /// <summary>
        /// Original raw text of Token
        /// </summary>
        public readonly string Text;

        public enum LexemeClass
        {
            Symbol,
            Operator,
            IndentWhitespace,
            NewLineWhitespace,
            QuotedString,
            Comment,
        }

        public readonly LexemeClass Type;

        public Lexeme(LexemeClass type, string text, InputSource file, int line)
        {
            Text = text;
            File = file;
            Line = line;
            Type = type;
        }


    }
}
