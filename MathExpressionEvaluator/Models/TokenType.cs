namespace MathExpressionEvaluator.Models
{
    internal enum TokenType
    {
        Number,             // double
        Plus,               // +
        Minus,              // -
        Multiply,           // *
        Divide,             // /
        Power,              // ^
        LeftParenthesis,    // (
        RightParenthesis,   // )
        Identifier,         // function
        Comma,              // ,
        Log,                // log
        EOS,                // end of string
        
    }
}