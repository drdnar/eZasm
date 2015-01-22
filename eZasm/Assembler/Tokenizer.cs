﻿using System;
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
    public class Tokenizer
    {
        /// <summary>
        /// String containing a regex that describes what an operator looks like
        /// </summary>
        internal readonly static string Operators = "!\\@\\#\\$\\%\\^\\&\\*\\(\\)\\[\\]\\\\{\\}\\<\\>,\\.\\|\\-\\+=`~/:\"'";
        /// <summary>
        /// String containing a regex that describes what whitespace looks like
        /// </summary>
        internal readonly static string WhitespaceChars = " \\t";
        internal readonly static string NewLineChars = "(\\r\\n|\\n|\\r)";
        internal readonly static string QuotedStringChars = "\"([^\\\\\"\r\n]|(\\\\[\"ntr\\\\]))*\"";
        internal readonly static string CommentChars = ";[^\\r\\n]*";
        // ("[^"
        /// <summary>
        /// Regex that describes what a token looks like
        /// </summary>
        //internal readonly static Regex TokenRegex = new Regex("(|" + QuotedStringChars + "|[^" + Operators + WhitespaceChars + "\\n\\r]+|[" + Operators + "]|[" + WhitespaceChars + "]+|" + NewLineChars + ")");
        internal readonly static Regex TokenRegex = new Regex("(" + QuotedStringChars + "|" + CommentChars + "|[^" + Operators + WhitespaceChars + "\\n\\r]+|[" + Operators + "]|[" + WhitespaceChars + "]+|" + NewLineChars + ")");
        /// <summary>
        /// Regex that describes what an operator looks like
        /// </summary>
        internal readonly static Regex IsOperatorToken = new Regex("[" + Operators + "]");
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
        int TokensLeft;
        InputFile InputFile;
        int LineNumber;

        bool FirstToken;

        public Tokenizer(InputFile file)
        {
            InputFile = file;
            Text = file.Text;
            StartParse();
        }


        void StartParse()
        {
            Matches = TokenRegex.Matches(Text);
            MatchesEnumerator = Matches.GetEnumerator();
            FirstToken = true;
            TokensLeft = Matches.Count;
            LineNumber = 1;
        }

        public Token GetNextToken()
        {
            if (TokensLeft == 0)
                return null;
            MatchesEnumerator.MoveNext();
            FirstToken = false;
            CurrentMatch = ((Match)MatchesEnumerator.Current);
            CurrentString = CurrentMatch.Value;
            TokensLeft--;
            Token token = null;
            if (IsOperatorToken.IsMatch(CurrentString))
                token = new Token(Token.TokenClass.Operator, CurrentString, InputFile, LineNumber);
            else if (IsCommentToken.IsMatch(CurrentString))
                token = new Token(Token.TokenClass.Comment, CurrentString, InputFile, LineNumber);
            else if (IsQuotedStringToken.IsMatch(CurrentString))
                token = new Token(Token.TokenClass.QuotedString, CurrentString, InputFile, LineNumber);
            else if (IsNewLineToken.IsMatch(CurrentString))
                token = new Token(Token.TokenClass.NewLineWhitespace, CurrentString, InputFile, LineNumber++);
            else if (IsWhitespaceToken.IsMatch(CurrentString))
                token = new Token(Token.TokenClass.IndentWhitespace, CurrentString, InputFile, LineNumber);
            else
                token = new Token(Token.TokenClass.Symbol, CurrentString, InputFile, LineNumber);
            return token;
        }

        public string GetCurrentToken()
        {
            return CurrentString;
        }

        public bool HasMoreTokens
        {
            get
            {
                return TokensLeft > 0;
            }
        }
    }
}
