using System.Diagnostics;
using System.Reflection.Emit;

namespace MathExpressionEvaluator.Models
{
    /// <summary>
    /// Analyzes an input string and converts it into a sequence of <see cref="Token"/>
    /// </summary>
    internal class Lexer
    {
        private string _input;
        private int _index;
        
        public Lexer(string input)
        {
            _input = input;
            _index = 0;
        }

        public Lexer() : this(string.Empty) { }

        public void Reset(string line)
        {
            _input = line;
            _index = 0;
        }

        public Token GetNextToken()
        {
            while (_input.Length > _index && char.IsWhiteSpace(_input[_index]))
                _index++;

            if (_index >= _input.Length)
                return new Token(TokenType.EOS);

            char current = _input[_index++];

            if (current == '+')
                return new Token(TokenType.Plus);

            if (current == '-')
                return new Token(TokenType.Minus);

            if (current == '^')
                return new Token(TokenType.Power);
            
            if (current == '*' && _input[_index++] == '*')
                return new Token(TokenType.Power);
            
            if (current == '*')
                return new Token(TokenType.Multiply);

            if (current == '/')
                return new Token(TokenType.Divide);
            
            if (current == '(')
                return new Token(TokenType.LeftParenthesis);

            if (current == ')')
                return new Token(TokenType.RightParenthesis);

            if (current == ',')
                return new Token(TokenType.Comma);

            if (char.IsDigit(current) || current == '.')
                return ReadNumber(current);

            if (current == 'l' && _input.Substring(_index, 3) == "ogb")
                return ReadLog();

            if (char.IsLetter(current))
                return ReadIdentifier(current);

            return new Token(TokenType.EOS);
        }

        private Token ReadLog()
        {
            _index += 2;
            return new Token(TokenType.Log, "log");
        }
        
        private Token ReadNumber(char firstChar)
        {
            var outStr = firstChar.ToString();
            
            while (   _index < _input.Length 
                   && (char.IsDigit(_input[_index]) || _input[_index] == ','))
                
                outStr += _input[_index++];
            
            return new Token(TokenType.Number, outStr);
        }

        private Token ReadIdentifier(char firstChar)
        {
            var outStr = firstChar.ToString();
            
            while (   _index < _input.Length 
                   && char.IsLetterOrDigit(_input[_index]))
                
                outStr += _input[_index++];
            
            return new Token(TokenType.Identifier, outStr.ToLowerInvariant());
        }
    }
}