using System;
using System.Collections.Generic;

namespace Task4Ad2
{
    public static class StackBracketsParser
    {
        public static bool Parse(string brackets)
        {
            AlgorithmsDataStructures.Stack<bool> stack = new AlgorithmsDataStructures.Stack<bool>();

            foreach (var bracket in brackets)
            {
                if (bracket == '(')
                {
                    stack.Push(true);
                }
                else
                {
                    if (stack.Size() == 0)
                         return false;

                    stack.Pop();
                }
            }

            return stack.Size() == 0;
        }
    }
}