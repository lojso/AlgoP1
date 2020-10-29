using AlgorithmsDataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Task7
    {
        
        [Test]
        public void TestAddingItemsAsc()
        {
            var stack = new OrderedList<int>(true);
            
            stack.Add(1);
            stack.Add(3);
            stack.Add(5);
            stack.Add(0);
            stack.Add(2);
            stack.Add(7);
            stack.Add(4);
            stack.Add(4);
            
            Assert.True(stack.ToString().Equals("0 1 2 3 4 4 5 7"));
        }
        
        [Test]
        public void TestAddingItemsDec()
        {
            var stack = new OrderedList<int>(false);
            
            stack.Add(1);
            stack.Add(3);
            stack.Add(5);
            stack.Add(0);
            stack.Add(2);
            stack.Add(7);
            stack.Add(4);
            stack.Add(4);
            
            Assert.True(stack.ToString().Equals("7 5 4 4 3 2 1 0"));
        }
        
        [Test]
        public void TestRemoveAsc()
        {
            var stack = new OrderedList<int>(true);
            stack.Add(1);
            stack.Add(3);
            stack.Add(5);
            stack.Add(0);
            stack.Add(2);
            stack.Add(7);
            stack.Add(4);
            stack.Add(4);
            
            stack.Delete(0);
            stack.Delete(2);
            stack.Delete(4);
            stack.Delete(7);
            
            Assert.True(stack.ToString().Equals("1 3 4 5"));
        }
        
        [Test]
        public void TestRemoveDes()
        {
            var stack = new OrderedList<int>(false);
            stack.Add(1);
            stack.Add(3);
            stack.Add(5);
            stack.Add(0);
            stack.Add(2);
            stack.Add(7);
            stack.Add(4);
            stack.Add(4);
            
            stack.Delete(0);
            stack.Delete(2);
            stack.Delete(4);
            stack.Delete(7);
            
            Assert.True(stack.ToString().Equals("5 4 3 1"));
        }
        
        [Test]
        public void TestClearDec()
        {
            var stack = new OrderedList<int>(false);
            stack.Add(1);
            stack.Add(3);
            stack.Add(5);
            stack.Add(0);
            stack.Add(2);
            stack.Add(7);
            stack.Add(4);
            stack.Add(4);
            
            stack.Clear(false);
            Assert.True(stack.Count() == 0);
            
            stack.Add(1);
            stack.Add(2);
            
            Assert.True(stack.ToString().Equals("2 1"));
            Assert.True(stack.Count() == 2);
        }
        
        [Test]
        public void TestClearAsc()
        {
            var stack = new OrderedList<int>(true);
            stack.Add(1);
            stack.Add(3);
            stack.Add(5);
            stack.Add(0);
            stack.Add(2);
            stack.Add(7);
            stack.Add(4);
            stack.Add(4);
            
            stack.Clear(true);
            Assert.True(stack.Count() == 0);
            stack.Add(1);
            stack.Add(2);
            
            Assert.True(stack.ToString().Equals("1 2"));
            Assert.True(stack.Count() == 2);
        }
        
        [Test]
        public void TestCreateSize()
        {
            var stack = new OrderedList<int>(true);

            Assert.True(stack.Count() == 0);
            Assert.True(stack.head == null);
            Assert.True(stack.tail == null);
        }
    }
}