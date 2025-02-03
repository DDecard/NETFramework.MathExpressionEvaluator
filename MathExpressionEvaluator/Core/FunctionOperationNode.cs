using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace MathExpressionEvaluator.Core
{
    /// <summary>
    /// Operation with function
    /// </summary>
    internal class FunctionOperationNode : INode
    {
        private readonly INode _argument;
        private readonly string _function;
        

        public FunctionOperationNode(INode argument, string function)
        {
            _argument = argument;
            _function = function;
        }
        
        public double Evaluate()
        {
            if (_function == "sin")
                return Math.Sin(_argument.Evaluate());
            
            if (_function == "cos")
                return Math.Cos(_argument.Evaluate());
            
            if (_function == "tan")
                return Math.Tan(_argument.Evaluate());
            
            if (_function == "asin")
                return Math.Asin(_argument.Evaluate());
            
            if (_function == "acos")
                return Math.Acos(_argument.Evaluate());
            
            if (_function == "atan")
                return Math.Atan(_argument.Evaluate());

            if (_function == "sqrt")
                return Math.Sqrt(_argument.Evaluate());
            
            if (_function == "log")
                return Math.Log10(_argument.Evaluate());
            
            if (_function == "ln")
                return Math.Log(_argument.Evaluate());

            if (_function == "fact")
            {
                var result = 1;
                
                for (var i = 1; i <= _argument.Evaluate(); i++)
                    result*=i;
                
                return result;
            }

            if (_function == "abs")
                return Math.Abs(_argument.Evaluate());
            
            throw new InvalidOperationException("Unknown function");
        }
    }
}