using System.Collections.Generic;

namespace MathExpressionEvaluator.Models
{
    public class ObjectPool<T> where T : new()
    {
        private readonly Stack<T> _pool = new Stack<T>();

        public T Get()
            => _pool.Count > 0 ? _pool.Pop() : new T();
        
        public void Return(T obj)
            => _pool.Push(obj);
    }
}