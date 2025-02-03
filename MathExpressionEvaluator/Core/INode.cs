namespace MathExpressionEvaluator.Core
{
    /// <summary>
    /// Base element of AST
    /// </summary>
    internal interface INode
    {
        double Evaluate();
    }
}