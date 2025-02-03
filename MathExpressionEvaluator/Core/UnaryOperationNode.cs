using System;
using MathExpressionEvaluator.Models;

namespace MathExpressionEvaluator.Core
{
    /// <summary>
    /// Unary operation is aт unary operation
    /// </summary>
    internal class UnaryOperationNode : INode
    {
        private readonly INode _node;
        private readonly TokenType _operator;

        public UnaryOperationNode(INode node, TokenType operatorType)
        {
            _node = node;
            _operator = operatorType;
        }
        
        public double Evaluate()
        {
            if (_operator == TokenType.Minus)
                return -_node.Evaluate();

            throw new InvalidOperationException("Unknown unary operator");
        }
    }
}