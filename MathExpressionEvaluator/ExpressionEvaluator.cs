using System.Runtime.CompilerServices;
using MathExpressionEvaluator.Models;

namespace MathExpressionEvaluator
{
    public class ExpressionEvaluator
    {
        private readonly ObjectPool<Lexer> _lexerPool = new ObjectPool<Lexer>();
        private readonly ObjectPool<Parser> _parserPool = new ObjectPool<Parser>();
        
        public double Parse(string expression)
        {
            var lexer = _lexerPool.Get();
            lexer.Reset(expression);
            
            var parser = _parserPool.Get();
            parser.Reset(lexer);
            
            var result = parser.Parse().Evaluate();
            
            _lexerPool.Return(lexer);
            _parserPool.Return(parser);
            
            return result;
        }
    }
}