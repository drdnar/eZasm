using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eZasm.Assembler;
using System.Text.RegularExpressions;

namespace eZasm
{
    class Program
    {
        static void Main(string[] args)
        {
            string operators = "!\\@\\#\\$\\%\\^\\&\\*\\(\\)\\[\\]\\\\{\\}\\<\\>,\\|\\-\\+=`~/:;\"'";
            string whitespace = " \\r\\n\\t\\f";
            Regex nextToken = new Regex("([^" + operators + whitespace + "]+|[" + operators + "]|[" + whitespace + "]+)");
            Regex isOperatorToken = new Regex("[" + operators + "]");
            Regex isWhitespaceToken = new Regex("[" + whitespace + "]");
            Regex isIndent = new Regex("[ \t]+");

            string[] text = new string[]
            {
                ".org 9D95h",
                "\tld hl, hello",
                "\tb_call(_PutS)",
                "\tb_call(_NewLine)",
                "; Thingy",
                "hello: .db \"Hello, world!\", 0"
            };

            bool moreTokens = true;

            while (moreTokens)
            {
                return;
            }

            string input = "\tld a, (hl) \\ ld (1234h), a\r\n djnz $";
            foreach (Match m in nextToken.Matches(input))
            {
                if (isOperatorToken.IsMatch(m.Value))
                    Console.Write("Operator: ");
                else if (isIndent.IsMatch(m.Value))
                    Console.Write("Indent: ");
                else if (isWhitespaceToken.IsMatch(m.Value))
                    Console.Write("White space: ");
                else
                    Console.Write("Token: ");
                //Console.Write(">");
                Console.WriteLine(m.Value);
            }
            Console.ReadKey();
        }
    }
}
