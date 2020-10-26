using System;
using System.Collections.Generic;

namespace Task4Ad2
{
    public static class StackBracketsParser
    {
        public static bool Parse(string brackets)
        {
            Task6.Stack<char> bracketsStack = new Task6.Stack<char>();
            Task6.Stack<bool> stack = new Task6.Stack<bool>();

            // Проверяем что правых скобочек сбалансированное количество
            foreach (var bracket in brackets)
            {
                bracketsStack.Push(bracket);
            }
            
            while (bracketsStack.Size() != 0)
            {
                while (bracketsStack.Peek() == ')')
                {
                    bracketsStack.Pop();
                    stack.Push(true);
                }

                while (bracketsStack.Peek() == '(')
                {
                    bracketsStack.Pop();
                    stack.Pop();
                }
            }

            for (int i = 0; i < stack.Size(); i++)
                return false;
            
            // Проверяем что левых скобочек сбалансированное количество
            bracketsStack = new Task6.Stack<char>();
            stack = new Task6.Stack<bool>();

            for (var index = brackets.Length - 1; index >= 0; index--)
            {
                var bracket = brackets[index];
                bracketsStack.Push(bracket);
            }

            while (bracketsStack.Size() != 0)
            {
                while (bracketsStack.Peek() == '(')
                {
                    bracketsStack.Pop();
                    stack.Push(true);
                }

                while (bracketsStack.Peek() == ')')
                {
                    bracketsStack.Pop();
                    stack.Pop();
                }
            }

            for (int i = 0; i < stack.Size(); i++)
                return false;
            
            // Если всех скобочек сбалансированно то true
            return true;
        }
    }
}