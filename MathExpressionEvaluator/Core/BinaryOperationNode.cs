using System;
using MathExpressionEvaluator.Models;

namespace MathExpressionEvaluator.Core
{
    /// <summary>
    /// Operation with two operands
    /// </summary>
    internal class BinaryOperationNode : INode
    {
        private readonly INode _left;
        private readonly INode _right;
        private readonly TokenType _operator;

        public BinaryOperationNode(INode left, INode right, TokenType op)
        {
            _left = left;
            _right = right;
            _operator = op;
        }
        
        public double Evaluate()
        {
            if (_operator == TokenType.Plus)
                return _left.Evaluate() + _right.Evaluate();
            
            if (_operator == TokenType.Minus)
                return _left.Evaluate() - _right.Evaluate();
            
            if (_operator == TokenType.Multiply)
                return _left.Evaluate() * _right.Evaluate();
            
            if (_operator == TokenType.Divide)
                return _left.Evaluate() / _right.Evaluate();
            
            if (_operator == TokenType.Power)
                return Math.Pow(_left.Evaluate(), _right.Evaluate());
            
            if (_operator == TokenType.Logb)
                return Math.Log(_left.Evaluate(), _right.Evaluate());
            
            throw new InvalidOperationException("Unknow operator");
        }
    }
}