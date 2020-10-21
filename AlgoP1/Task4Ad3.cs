using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;

namespace Task4Ad3
{
    public static class Calculator
    {
        private static AlgorithmsDataStructures.Stack<string> _expression;
        private static AlgorithmsDataStructures.Stack<int> _currentResult;
        
        public static int Calculate(string expression)
        {
            Reset();
            _expression = ParseExpression(expression);
            while (_expression.Size() != 0)
            {
                var curVal = _expression.Pop(); 
                switch (curVal)
                {
                    case " ":
                        continue;
                        break;
                    case "+":
                        Sum();
                        break;
                    case "*":
                        Mul();
                        break;
                    case "=":
                        return _currentResult.Pop();
                    default:
                        _currentResult.Push(int.Parse(curVal));
                        break;
                }
                
            }
            return _currentResult.Pop();
        }

        private static void Mul()
        {
            var mul = _currentResult.Pop();
            while (_currentResult.Size() > 0)
            {
                mul *= _currentResult.Pop();
            }
            _currentResult.Push(mul);
        }

        private static void Sum()
        {
            var sum = 0;
            while (_currentResult.Size() > 0)
            {
                sum += _currentResult.Pop();
            }
            _currentResult.Push(sum);
        }

        private static AlgorithmsDataStructures.Stack<string> ParseExpression(string expression)
        {
            AlgorithmsDataStructures.Stack<string> result = new AlgorithmsDataStructures.Stack<string>();
            expression = Reverse(expression);
            var splittedExpr = expression.Split(' ');
            foreach (var ch in splittedExpr)
            {
                result.Push(ch);
            }

            return result;
        }
        
        public static string Reverse( string s )
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse( charArray );
            return new string( charArray );
        }

        private static void Reset()
        {
            _expression = new AlgorithmsDataStructures.Stack<string>();
            _currentResult = new AlgorithmsDataStructures.Stack<int>();
        }
    }
}