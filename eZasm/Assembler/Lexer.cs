using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace eZasm.Assembler
{
    /// <summary>
    /// Digests an input string into Tokens
    /// </summary>
    class Lexer
    {
        /// <summary>
        /// String containing a regex that describes what an operator looks like
        /// </summary>
        internal readonly static string OperatorChars = "!\\@\\$\\%\\^\\&\\*\\(\\)\\[\\]\\\\{\\}\\<\\>,\\|\\-\\+=`~/:\"'";
        internal readonly static string Operators = "\\<\\<|\\>\\>|\\|\\||\\&\\&|\\=\\=|\\<\\=|\\>\\=|[" + OperatorChars + "]";
        /// <summary>
        /// String containing a regex that describes what whitespace looks like
        /// </summary>
        internal readonly static string WhitespaceChars = " \\t";
        internal readonly static string NewLineChars = "(\\r\\n|\\n|\\r)";
        internal readonly static string QuotedStringChars = "\"([^\\\\\"\r\n]|(\\\\[^\\r\\n]))*\"";
        internal readonly static string CommentChars = ";[^\\r\\n]*";
        // ("[^"
        /// <summary>
        /// Regex that describes what a token looks like
        /// </summary>
        //internal readonly static Regex TokenRegex = new Regex("(|" + QuotedStringChars + "|[^" + Operators + WhitespaceChars + "\\n\\r]+|[" + Operators + "]|[" + WhitespaceChars + "]+|" + NewLineChars + ")");
        internal readonly static Regex LexemeRegex = new Regex("(" + QuotedStringChars + "|" + CommentChars + "|[^" + OperatorChars + WhitespaceChars + "\\n\\r]+|" + Operators + "|[" + WhitespaceChars + "]+|" + NewLineChars + ")");
        /// <summary>
        /// Regex that describes what an operator looks like
        /// </summary>
        internal readonly static Regex IsOperatorToken = new Regex("(" + Operators + ")");
        /// <summary>
        /// Regex that describes what any whitespace looks like
        /// </summary>
        //internal readonly static Regex IsWhitespaceToken = new Regex("([" + WhitespaceChars + "]+|" + NewLineChars + ")");
        internal readonly static Regex IsWhitespaceToken = new Regex("[" + WhitespaceChars + "]");
        /// <summary>
        /// Regex that describes what an indent looks like
        /// </summary>
        internal readonly static Regex IsNewLineToken = new Regex(NewLineChars);
        /// <summary>
        /// This is ugly.
        /// </summary>
        internal readonly static Regex IsQuotedStringToken = new Regex(QuotedStringChars);
        /// <summary>
        /// At least checking for comments is easy.
        /// </summary>
        internal readonly static Regex IsCommentToken = new Regex(CommentChars);

        /// <summary>
        /// Text to parse
        /// </summary>
        public string Text;
        MatchCollection Matches;
        System.Collections.IEnumerator MatchesEnumerator;
        Match CurrentMatch;
        string CurrentString;
        
        InputSource InputSource;
        /// <summary>
        /// Line number of the next token
        /// </summary>
        int lineNumber;
        /// <summary>
        /// Returns the line number of the next token.
        /// </summary>
        public int CurrentLineNumber
        {
            get
            {
                return lineNumber;
            }
        }

        bool MoreLexemes = true;
        bool Init = false;

        public Lexer(InputSource file)
        {
            InputSource = file;
            Text = file.Text;
            StartParse();
        }


        void StartParse()
        {
            Matches = LexemeRegex.Matches(Text);
            MatchesEnumerator = Matches.GetEnumerator();
            lineNumber = 1;
        }

        public Lexeme GetNextLexeme()
        {
            if (!Init)
            {
                MoreLexemes = MatchesEnumerator.MoveNext();
                Init = true;
            }
            if (!MoreLexemes)
                if (!(MoreLexemes = MatchesEnumerator.MoveNext()))
                    return null;
            CurrentMatch = ((Match)MatchesEnumerator.Current);
            CurrentString = CurrentMatch.Value;
            Lexeme token = null;
            if (IsOperatorToken.IsMatch(CurrentString))
                token = new Lexeme(Lexeme.LexemeClass.Operator, CurrentString, InputSource, lineNumber);
            else if (IsCommentToken.IsMatch(CurrentString))
                token = new Lexeme(Lexeme.LexemeClass.Comment, CurrentString, InputSource, lineNumber);
            else if (IsQuotedStringToken.IsMatch(CurrentString))
                token = new Lexeme(Lexeme.LexemeClass.QuotedString, CurrentString, InputSource, lineNumber);
            else if (IsNewLineToken.IsMatch(CurrentString))
                token = new Lexeme(Lexeme.LexemeClass.NewLineWhitespace, CurrentString, InputSource, lineNumber++);
            else if (IsWhitespaceToken.IsMatch(CurrentString))
                token = new Lexeme(Lexeme.LexemeClass.IndentWhitespace, CurrentString, InputSource, lineNumber);
            else
                token = new Lexeme(Lexeme.LexemeClass.Symbol, CurrentString, InputSource, lineNumber);
            MoreLexemes = MatchesEnumerator.MoveNext();
            return token;
        }

        public string GetCurrentToken()
        {
            return CurrentString;
        }

        public bool HasMoreLexemes
        {
            get
            {
                return MoreLexemes;
            }
        }
    }
}
