using System;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Task4
    {
        
        [TestCase(1, 4, 4, 4)]
        [TestCase(0, 0, 1, 0)]
        [TestCase(0, -1, 0, 0)]
        public void CreateStackTest(int start, int end, int expectedCount, int expectedPeek)
        {
            var stack = GenerateStack(start, end);
            
            Assert.True(stack.Peek() == expectedPeek);
            Assert.True(stack.Size() == expectedCount);
        }
        
        [Test]
        public void PushPeekTest()
        {
            var stack = GenerateStack(1, 3);

            var pop = stack.Pop();
            Assert.True(pop == 3);
            Assert.True(stack.Size() == 2);
            Assert.True(stack.Peek() == 2);
            
            stack.Push(5);
            Assert.True(stack.Size() == 3);
            Assert.True(stack.Peek() == 5);
            
            stack.Push(6);
            stack.Push(7);
            Assert.True(stack.Size() == 5);
            Assert.True(stack.Peek() == 7);
        }

        private Stack<int> GenerateStack(int from, int toInclusive)
        {
            Stack<int> s = new Stack<int>();
            for (int i = from; i <= toInclusive; i++)
            {
                s.Push(i);
            }

            return s;
        }
    }
}