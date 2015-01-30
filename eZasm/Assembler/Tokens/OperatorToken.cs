using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZasm.Assembler.Tokens
{

    enum OperatorType
    {
        /// <summary>
        /// (
        /// </summary>
        ExpressionOpen,
        /// <summary>
        /// )
        /// </summary>
        ExpressionClose,
        /// <summary>
        /// [
        /// </summary>
        IndirectionOpen,
        /// <summary>
        /// ]
        /// </summary>
        IndirectionClose,
        /// <summary>
        /// +
        /// </summary>
        Addition,
        /// <summary>
        /// -
        /// </summary>
        Subtraction,
        /// <summary>
        /// *
        /// </summary>
        Multiplication,
        /// <summary>
        /// /
        /// </summary>
        Division,
        /// <summary>
        /// %
        /// </summary>
        Modulus,
        /// <summary>
        /// <<
        /// </summary>
        LeftBitShift,
        /// <summary>
        /// >>
        /// </summary>
        RightBitShift,
        /// <summary>
        /// &
        /// </summary>
        BitwiseAnd,
        /// <summary>
        /// |
        /// </summary>
        BitwiseOr,
        /// <summary>
        /// ^
        /// </summary>
        BitwiseXor,
        /// <summary>
        /// ~
        /// </summary>
        BitwiseComplement,
        /// <summary>
        /// ==
        /// </summary>
        EqualTo,
        /// <summary>
        /// <
        /// </summary>
        LessThan,
        /// <summary>
        /// >
        /// </summary>
        GreaterThan,
        /// <summary>
        /// <=
        /// </summary>
        LessThanOrEqualTo,
        /// <summary>
        /// >=
        /// </summary>
        GreaterThanOrEqualTo,
        /// <summary>
        /// ,
        /// </summary>
        Comma,
        /// <summary>
        /// =
        /// </summary>
        Assignment,
        /// <summary>
        /// \
        /// </summary>
        LineContinuation,

    }

    class OperatorToken : Token
    {
        public OperatorType Type;
        public OperatorToken(string data, int lineNumber, InputSource source)
        {
            Text = data;
            LineNumber = lineNumber;
            Source = source;

            switch (data)
            {
                case "(":
                    Type = OperatorType.ExpressionOpen;
                    break;
                case ")":
                    Type = OperatorType.ExpressionClose;
                    break;
                case "[":
                    Type = OperatorType.IndirectionOpen;
                    break;
                case "]":
                    Type = OperatorType.IndirectionClose;
                    break;
                case "+":
                    Type = OperatorType.Addition;
                    break;
                case "-":
                    Type = OperatorType.Subtraction;
                    break;
                case "*":
                    Type = OperatorType.Multiplication;
                    break;
                case "/":
                    Type = OperatorType.Division;
                    break;
                case "%":
                    Type = OperatorType.Modulus;
                    break;
                case "<<":
                    Type = OperatorType.LeftBitShift;
                    break;
                case ">>":
                    Type = OperatorType.RightBitShift;
                    break;
                case "&":
                    Type = OperatorType.BitwiseAnd;
                    break;
                case "|":
                    Type = OperatorType.BitwiseOr;
                    break;
                case "^":
                    Type = OperatorType.BitwiseXor;
                    break;
                case "~":
                    Type = OperatorType.BitwiseComplement;
                    break;
                case "==":
                    Type = OperatorType.EqualTo;
                    break;
                case "<":
                    Type = OperatorType.LessThan;
                    break;
                case ">":
                    Type = OperatorType.GreaterThan;
                    break;
                case "<=":
                    Type = OperatorType.LessThanOrEqualTo;
                    break;
                case ">=":
                    Type = OperatorType.GreaterThanOrEqualTo;
                    break;
                case ",":
                    Type = OperatorType.Comma;
                    break;
                case "=":
                    Type = OperatorType.Assignment;
                    break;
                case "\\":
                    Type = OperatorType.LineContinuation;
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}
