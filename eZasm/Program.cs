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
            InputFile blah = new InputFile();
            blah.Text = ".org 9D95h\r\n\tld hl, hello\r\n\tb_call(_PutS);Show something\r\n\tb_call(_NewLine)\r\n\tret\r\n; String to show\r\nhello: .db \"Hello; \\\"world\\\\!\\\"\", 0";
            Tokenizer tokenizer = new Tokenizer(blah);

            Console.WriteLine("***BEGIN INPUT***");

            Console.WriteLine(blah.Text);
            Console.WriteLine("***END INPUT***");
            Console.WriteLine("Tokens:");
            while (tokenizer.HasMoreTokens)
            {
                Token x = tokenizer.GetNextToken();
                switch (x.Type)
                {
                    case Token.TokenClass.IndentWhitespace:
                        Console.Write("Indent: ");
                        break;
                    case Token.TokenClass.NewLineWhitespace:
                        Console.WriteLine("Newline.");
                        break;
                    case Token.TokenClass.Operator:
                        Console.Write("Operator: ");
                        break;
                    case Token.TokenClass.Symbol:
                        Console.Write("Symbol: ");
                        break;
                    case Token.TokenClass.Comment:
                        Console.Write("Comment: ");
                        break;
                    case Token.TokenClass.QuotedString:
                        Console.Write("Quoted string: ");
                        break;
                }
                if (x.Type != Token.TokenClass.NewLineWhitespace)
                {
                    Console.Write(x.Text);
                    Console.WriteLine("");
                }
            }
            Console.WriteLine("TODO: MAKE UNIT TESTS TOMORROW");
            Console.ReadKey();
        }
    }
}
