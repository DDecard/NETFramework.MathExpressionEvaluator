namespace MathExpressionEvaluator.Core
{
    /// <summary>
    /// Represents a <see cref="double"/>
    /// </summary>
    internal class NumberNode : INode
    {
        private readonly double _value;

        public NumberNode(double value)
        {
            _value = value;
        }
        public NumberNode(string value) : this(double.Parse(value)) {}

        public double Evaluate()
            => _value;
    }
}