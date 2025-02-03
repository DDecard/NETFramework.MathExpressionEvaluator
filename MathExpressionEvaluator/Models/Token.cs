namespace MathExpressionEvaluator.Models
{
    internal class Token
    {
        public TokenType Type { get; }
        public string Value { get; }

        public Token(TokenType type, string value = "")
        {
            Type = type;
            Value = value;
        }

        public static Token Empty => new Token(TokenType.EOS);
        
        public override string ToString()
            => $"{Type}: {Value}";
    }
}