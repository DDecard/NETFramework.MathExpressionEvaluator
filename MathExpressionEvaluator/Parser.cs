using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using MathExpressionEvaluator.Core;
using MathExpressionEvaluator.Models;

namespace MathExpressionEvaluator
{
    internal class Parser
    {
        private Lexer _lexer;
        private Token _currentToken;

        public void Reset(Lexer lexer)
        {
            _lexer = lexer;
            _currentToken = _lexer.GetNextToken();
        }
        
        private void Eat(TokenType type)
        {
            if (_currentToken.Type == type)
                _currentToken = _lexer.GetNextToken();
            
            else
                throw new ArgumentException($"Invalid token type: {type}, expected {_currentToken.Type}");
        }
    /**/
        public INode Parse() => ParseAdditive();

        /// <summary>
        /// Handles arithmetic operators + and -
        /// </summary>
        /// <returns><see cref="BinaryOperationNode"/></returns>
        private INode ParseAdditive()
        {
            var node = ParseMultiplicative();

            while (   _currentToken.Type is TokenType.Plus 
                   || _currentToken.Type is TokenType.Minus)
            {
                var op = _currentToken.Type;
                Eat(op);
                var rightNode = ParseMultiplicative();
                
                node = new BinaryOperationNode(node, rightNode, op);
            }
            
            return node;
        }

        /// <summary>
        /// Handles arithmetic operators * and /
        /// </summary>
        /// <returns><see cref="BinaryOperationNode"/></returns>
        private INode ParseMultiplicative()
        {
            var node = ParsePower();
            
            while (   _currentToken.Type == TokenType.Multiply 
                   || _currentToken.Type == TokenType.Divide
                   || _currentToken.Type == TokenType.Logb)
            {
                var op = _currentToken.Type;
                Eat(op);
                var rightNode = ParsePower();
                
                node = new BinaryOperationNode(node, rightNode, op);
            }
            
            return node;
        }
        
        /// <summary>
        /// Handles exponentiation
        /// </summary>
        /// <returns><see cref="BinaryOperationNode"/></returns>
        private INode ParsePower()
        {
            var node = ParsePriority();
    
            if (_currentToken.Type == TokenType.Power)
            {
                Eat(TokenType.Power);
                var rightNode = ParsePriority();
                
                node = new BinaryOperationNode(node, rightNode, TokenType.Power);
            }
            
            return node;
        }

        /// <summary>
        /// Handles handles priority values
        /// </summary>
        private INode ParsePriority()
        {
            // (
            if (_currentToken.Type == TokenType.LeftParenthesis)
            {
                Eat(_currentToken.Type);
                var node = ParseAdditive();
                Eat(TokenType.RightParenthesis);
                
                return node;
            }
            
            // number
            if (_currentToken.Type == TokenType.Number)
            {
                var node = new NumberNode(_currentToken.Value);
                Eat(TokenType.Number);
                
                return node;
            }
            
            // unary
            if (_currentToken.Type == TokenType.Minus)
            {
                Eat(_currentToken.Type);
                var node = ParseMultiplicative();
                
                return new UnaryOperationNode(node, TokenType.Minus);
            }

            // e & pi
            if (_currentToken.Type == TokenType.Identifier
                && (_currentToken.Value == "pi" || _currentToken.Value == "e"))
            {
                var arg = _currentToken.Value == "pi" ? Math.PI : Math.E;
                Eat(TokenType.Identifier);
                
                return new NumberNode(arg);
            }
            
            // function
            if (_currentToken.Type == TokenType.Identifier)
            {
                var fun = _currentToken.Value;
                
                Eat(TokenType.Identifier);
                Eat(TokenType.LeftParenthesis);
                
                var arg = ParsePriority();
                
                Eat(TokenType.RightParenthesis);
                return new FunctionOperationNode(arg, fun);
            }
            
            throw new ArgumentException($"Invalid token type: {_currentToken.Type}");
        }


        /**
        
        private INode ParseAdditive()
        {
            var node = ParseMultiplicative();

            while (_currentToken.Type is TokenType.Plus || _currentToken.Type is TokenType.Minus)
            {
                var op = _currentToken.Type;
                Eat(op);
                var rightNode = ParseMultiplicative();

                node = new BinaryOperationNode((NumberNode)node, (NumberNode)rightNode, op);
            }
            
            return node;
        }
    /**
    /// <summary>
    /// Обрабатывает арефмитические операторы * и /
    /// </summary>
    /// <returns><see cref="BinaryOperationNode"/></returns>
    private INode ParseMultiplicative()
    {
        var node = ParseUnary();

        while (_currentToken.Type != TokenType.Multiply || _currentToken.Type != TokenType.Divide)
        {
            var op = _currentToken.Type;
            Eat(op);
            var rightNode = ParseUnary();
            
            node = new BinaryOperationNode((NumberNode)node, (NumberNode)rightNode, op);
        }

        return node;
        }
    /**
        /// <summary>
        /// Обрабатывает унарные операции
        /// </summary>
        /// <returns><see cref="UnaryOperationNode"/></returns>
        private INode ParseUnary()
        {
            var node = ParsePriority();

            if (_currentToken.Type == TokenType.Power)
            {
                Eat(TokenType.Power);
                var rightNode = ParsePriority();
                
                node = new BinaryOperationNode((NumberNode)node, (NumberNode)rightNode, TokenType.Power);
            }
            
            if (_currentToken.Type == TokenType.Plus)
            {
                Eat(TokenType.Plus);
                ParseUnary();
            }
            
            return node;
        }
    /**
        private INode ParsePriority()
        {
            if (_currentToken.Type == TokenType.LeftParenthesis)
            {
                Eat(TokenType.LeftParenthesis);
                var node = ParseAdditive();
                Eat(TokenType.RightParenthesis);
                return node;
            }

            if (_currentToken.Type == TokenType.Number)
            {
                var node = new NumberNode(double.Parse(_currentToken.Value));
                Eat(TokenType.Number);
                return node;
            }

            // Unary
            if (_currentToken.Type == TokenType.Minus)
            {
                Eat(TokenType.Minus);
                return new UnaryOperationNode(ParsePriority(), TokenType.Minus);
            }

            // function
            if (_currentToken.Type == TokenType.Identifier)
            {
                Eat(TokenType.Identifier);
                Eat(TokenType.LeftParenthesis);
                var arguments = new List<INode> { ParseAdditive() };

                while (_currentToken.Type != TokenType.Comma)
                {
                    Eat(TokenType.Comma);
                    arguments.Add(ParseAdditive());
                }
                
                Eat(TokenType.RightParenthesis);
                return new FunctionNode(arguments, _currentToken.Value);
            }
            
            throw new ArgumentException($"Invalid token type: {_currentToken.Type}");
        }
    /**/
    }
}