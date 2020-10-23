using AlgorithmsDataStructures;
using NUnit.Framework;
using Task5;

namespace Tests
{
    [TestFixture]
    public class Task5
    {
        
        [TestCase(1, 4, 3, 1)]
        [TestCase(0, 1, 1, 0)]
        [TestCase(0, 0, 0, 0)]
        [TestCase(0, -1, 0, 0)]
        public void CreateStackTest(int start, int end, int expectedCount, int expectedPeek)
        {
            var stack = GenerateQueue(start, end);
            
            Assert.True(stack.Dequeue() == expectedPeek);
            Assert.True(stack.Size() == expectedCount);
        }
        
        [Test]
        public void PushPeekTest()
        {
            var stack = GenerateQueue(1, 3);

            Assert.True(stack.Size() == 3);
            
            var pop = stack.Dequeue();
            Assert.True(pop == 1);
            Assert.True(stack.Size() == 2);
            
            pop = stack.Dequeue();
            Assert.True(pop == 2);
            Assert.True(stack.Size() == 1);
            
            pop = stack.Dequeue();
            Assert.True(pop == 3);
            Assert.True(stack.Size() == 0);
            
            pop = stack.Dequeue();
            Assert.True(stack.Size() == 0);
            
            pop = stack.Dequeue();
            Assert.True(stack.Size() == 0);
            
            stack.Enqueue(5);
            pop = stack.Dequeue();
            Assert.True(pop == 5);
            Assert.True(stack.Size() == 0);
            
            stack.Enqueue(5);
            Assert.True(stack.Size() == 1);
            stack.Enqueue(4);
            Assert.True(stack.Size() == 2);
            
            pop = stack.Dequeue();
            Assert.True(pop == 5);
            Assert.True(stack.Size() == 1);
            
            pop = stack.Dequeue();
            Assert.True(pop == 4);
            Assert.True(stack.Size() == 0);
        }


        private Queue<int> GenerateQueue(int fromInclusive, int toInclusive)
        {
            Queue<int> q = new Queue<int>();
            for (int i = fromInclusive; i <= toInclusive; i++)
            {
                q.Enqueue(i);
            }

            return q;
        }
    }
}