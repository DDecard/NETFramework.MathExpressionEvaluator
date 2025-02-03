using System;
using NUnit.Framework;
using MathExpressionEvaluator;

namespace MathExpressionEvaluator.Test
{
    [TestFixture]
    public class MathExpressionsTests
    {
        private readonly Random _random = new Random();
        private readonly ExpressionEvaluator _evaluator = new ExpressionEvaluator();
        
        /**/
        [Test]
        public void Test1()
        {
            var n1 = (double)_random.Next();
            var n2 = (double)_random.Next();
            var result1 = n1 + n2;
            var result2 = n1 - n2;
            
            Assert.AreEqual(result1, _evaluator.Parse($"{n1}+{n2}"));
            Assert.AreEqual(result2, _evaluator.Parse($"{n1} - {n2}"));
        }
        /**/
        [Test]
        public void Test2()
        { 
            var n1 = (double)_random.Next();
            var n2 = (double)_random.Next();
            var result1 = n1 + n2;
            var result2 = n1 - n2;
            
            Assert.AreEqual(result1, _evaluator.Parse($"{n1}    +    {n2}"));
            Assert.AreEqual(result1, _evaluator.Parse($"{n1}    +{n2}"));
            Assert.AreEqual(result1, _evaluator.Parse($"{n1}+    {n2}"));
            
            Assert.AreEqual(result2, _evaluator.Parse($"{n1}    -    {n2}"));
            Assert.AreEqual(result2, _evaluator.Parse($"{n1}    -{n2}"));
            Assert.AreEqual(result2, _evaluator.Parse($"{n1}-    {n2}"));
        }
        /**/
        [Test]
        public void Test3()
        {
            var n1 = (double)_random.Next();
            var n2 = (double)_random.Next();
            var result1 = n1 * n2;
            var result2 = n1 / n2;
            
            Assert.AreEqual(result1, _evaluator.Parse($"{n1}*{n2}"));
            Assert.AreEqual(result2, _evaluator.Parse($"{n1}/{n2}"));
        }
        /**/
        [Test]
        public void Test4()
        {
            var n1 = (double)_random.Next();
            var n2 = (double)_random.Next();
            var result1 = n1 * n2;
            var result2 = n1 / n2; 
            
            Assert.AreEqual(result1, _evaluator.Parse($"{n1}    *    {n2}"));
            Assert.AreEqual(result1, _evaluator.Parse($"{n1}    *{n2}"));
            Assert.AreEqual(result1, _evaluator.Parse($"{n1}    *    {n2}"));
            
            Assert.AreEqual(result2, _evaluator.Parse($"{n1}    /    {n2}"));
            Assert.AreEqual(result2, _evaluator.Parse($"{n1}    /{n2}"));
            Assert.AreEqual(result2, _evaluator.Parse($"{n1}/    {n2}"));
        }
        /**/
        [Test]
        public void Test5()
        {
            var n1 = (double)_random.Next();
            var n2 = (double)_random.Next();
            
            Assert.AreEqual( Math.Sin(n1), _evaluator.Parse($"sin({n1})"));
            Assert.AreEqual( Math.Cos(n1), _evaluator.Parse($"cos({n1})"));
            Assert.AreEqual( Math.Tan(n1), _evaluator.Parse($"tan({n1})"));
            Assert.AreEqual(Math.Asin(n1), _evaluator.Parse($"asin({n1})"));
            Assert.AreEqual(Math.Acos(n1), _evaluator.Parse($"acos({n1})"));
            Assert.AreEqual(Math.Atan(n1), _evaluator.Parse($"atan({n1})"));
            Assert.AreEqual(Math.Sqrt(n1), _evaluator.Parse($"sqrt({n1})"));
        }
        /**/
        [Test]
        public void Test6()
        {
            var n1 = (double)_random.Next();
            var n2 = (double)_random.Next();
            
            Assert.AreEqual( Math.Sin(n1),  _evaluator.Parse($"sin(    {n1}    )"));
            Assert.AreEqual( Math.Sin(n1),  _evaluator.Parse($"sin({n1}    )"));
            Assert.AreEqual( Math.Sin(n1),  _evaluator.Parse($"sin(    {n1})"));
            
            Assert.AreEqual( Math.Cos(n1),  _evaluator.Parse($"cos(    {n1}    )"));
            Assert.AreEqual( Math.Cos(n1),  _evaluator.Parse($"cos({n1}    )"));
            Assert.AreEqual( Math.Cos(n1),  _evaluator.Parse($"cos(    {n1})"));
            
            Assert.AreEqual( Math.Tan(n1),  _evaluator.Parse($"tan(    {n1}    )"));
            Assert.AreEqual( Math.Tan(n1),  _evaluator.Parse($"tan({n1}    )"));
            Assert.AreEqual( Math.Tan(n1),  _evaluator.Parse($"tan(    {n1})"));
            
            Assert.AreEqual(Math.Asin(n1), _evaluator.Parse($"asin(    {n1}    )"));
            Assert.AreEqual(Math.Asin(n1), _evaluator.Parse($"asin({n1}    )"));
            Assert.AreEqual(Math.Asin(n1), _evaluator.Parse($"asin(    {n1})"));
            
            Assert.AreEqual(Math.Acos(n1), _evaluator.Parse($"acos(    {n1}    )"));
            Assert.AreEqual(Math.Acos(n1), _evaluator.Parse($"acos({n1}    )"));
            Assert.AreEqual(Math.Acos(n1), _evaluator.Parse($"acos(    {n1})"));
            
            Assert.AreEqual(Math.Atan(n1), _evaluator.Parse($"atan(    {n1}    )"));
            Assert.AreEqual(Math.Atan(n1), _evaluator.Parse($"atan({n1}    )"));
            Assert.AreEqual(Math.Atan(n1), _evaluator.Parse($"atan(    {n1})"));
            
            Assert.AreEqual(Math.Sqrt(n1), _evaluator.Parse($"sqrt(    {n1}    )"));
            Assert.AreEqual(Math.Sqrt(n1), _evaluator.Parse($"sqrt({n1}   )"));
            Assert.AreEqual(Math.Sqrt(n1), _evaluator.Parse($"sqrt(    {n1})"));
        }
        /**/
        [Test]
        public void Test7()
        {
            var n1 = (double)_random.Next();
            var n2 = (double)_random.Next();
            
            Assert.AreEqual( Math.Pow(n1, n2),  _evaluator.Parse($"{n1}^{n2}"));
        }
        /**/
        [Test]
        public void Test8()
        {
            var n1 = (double)_random.Next();
            var n2 = (double)_random.Next();
            
            Assert.AreEqual( Math.Pow(n1, n2),  _evaluator.Parse($"{n1}    ^    {n2}"));
            Assert.AreEqual( Math.Pow(n1, n2),  _evaluator.Parse($"{n1}^    {n2}"));
            Assert.AreEqual( Math.Pow(n1, n2),  _evaluator.Parse($"{n1}    ^{n2}"));
        }
        /**/
        [Test]
        public void Test9()
        {
            var n1 = (double)_random.Next();
            
            Assert.AreEqual( Math.PI + n1,  _evaluator.Parse($"pi + {n1}"));
            Assert.AreEqual( Math.PI - n1,  _evaluator.Parse($"pi - {n1}"));
            Assert.AreEqual( Math.PI * n1,  _evaluator.Parse($"pi * {n1}"));
            Assert.AreEqual( Math.PI / n1,  _evaluator.Parse($"pi / {n1}"));
            Assert.AreEqual( Math.E + n1,  _evaluator.Parse($"e + {n1}"));
            Assert.AreEqual( Math.E - n1,  _evaluator.Parse($"e - {n1}"));
            Assert.AreEqual( Math.E * n1,  _evaluator.Parse($"e * {n1}"));
            Assert.AreEqual( Math.E / n1,  _evaluator.Parse($"e / {n1}"));
        }
    }
}