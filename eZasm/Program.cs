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
            InputString blah = new InputString();
            blah.Text = ".org 9D95h\r\n\tld hl, hello\r\n\tb_call(_PutS);Show something\r\n\tb_call(_NewLine)\r\n\tret\r\n; String to show\r\nhello: .db \"Hello; \\\"world\\\\!\\\"\", 0";
            Lexer tokenizer = new Lexer(blah);

            Console.WriteLine("***BEGIN INPUT***");

            Console.WriteLine(blah.Text);
            Console.WriteLine("***END INPUT***");
            Console.WriteLine("Tokens:");
            while (tokenizer.HasMoreLexemes)
            {
                Lexeme x = tokenizer.GetNextLexeme();
                switch (x.Type)
                {
                    case Lexeme.LexemeClass.IndentWhitespace:
                        Console.Write("Indent: ");
                        break;
                    case Lexeme.LexemeClass.NewLineWhitespace:
                        Console.WriteLine("Newline.");
                        break;
                    case Lexeme.LexemeClass.Operator:
                        Console.Write("Operator: ");
                        break;
                    case Lexeme.LexemeClass.Symbol:
                        Console.Write("Symbol: ");
                        break;
                    case Lexeme.LexemeClass.Comment:
                        Console.Write("Comment: ");
                        break;
                    case Lexeme.LexemeClass.QuotedString:
                        Console.Write("Quoted string: ");
                        break;
                }
                if (x.Type != Lexeme.LexemeClass.NewLineWhitespace)
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
