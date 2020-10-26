using System;
using Task6;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Tests
{
    [TestFixture]
    public class Task3
    {
        [TestCase(1, 1, 1, 16)]
        [TestCase(1, 2, 2, 16)]
        [TestCase(1, 16, 16, 16)]
        [TestCase(1, 17, 17, 32)]
        public void CreateArrayTest(int start, int end, int expectedCount, int expectedCapacity)
        {
            DynArray<int> array = CreateDynArrayWithRange(start, end);
            
            Assert.True(array.count == expectedCount);
            Assert.True(array.capacity == expectedCapacity);
        }
        
        [TestCase(1, 1, 0, 1, 1, 16)]
        [TestCase(1, 2, 0, 1, 2, 16)]
        [TestCase(1, 2, 1, 2, 2, 16)]
        [TestCase(1, 16, 15, 16, 16, 16)]
        [TestCase(1, 17, 15, 16, 17, 32)]
        [TestCase(1, 17, 16, 17, 17, 32)]
        public void CorrectGetElementTest(
            int start, int end,
            int getIndex, int expectedValue,
            int expectedCount, int expectedCapacity)
        {
            DynArray<int> array = CreateDynArrayWithRange(start, end);
            
            Assert.True(array.count == expectedCount);
            Assert.True(array.capacity == expectedCapacity);
            Assert.True(array.GetItem(getIndex) == expectedValue);
        }
        
        [TestCase(0, -1, 0)]
        [TestCase(1, 1, 1)]
        [TestCase(1, 1, -1)]
        [TestCase(1, 1, 16)]
        [TestCase(1, 16, 16)]
        [TestCase(1, 16, -1)]
        [TestCase(1, 17, 17)]
        public void IncorrectGetElementTest(
            int start, int end,
            int getIndex)
        {
            DynArray<int> array = CreateDynArrayWithRange(start, end);

            Assert.That(() => array.GetItem(getIndex), Throws.TypeOf<IndexOutOfRangeException>());
        }
        
        [TestCase(0, -1, 0, 1, 1, 1, 16)]
        [TestCase(1, 1, 0, 0, 0, 2, 16)]
        [TestCase(1, 3, 1, 0, 0, 4, 16)]
        [TestCase(1, 15, 15, 16, 16, 16, 16)]
        [TestCase(1, 16, 16, 17, 17, 17, 32)]
        public void CorrectInsertTest(
            int start, int end,
            int insertIndex, int insertValue, int expectedValue,
            int expectedCount, int expectedCapacity)
        {
            DynArray<int> array = CreateDynArrayWithRange(start, end);
            
            array.Insert(insertValue, insertIndex);
            
            Assert.True(array.count == expectedCount);
            Assert.True(array.capacity == expectedCapacity);
            Assert.True(array.GetItem(insertIndex) == expectedValue);
        }
        
        [TestCase(1, 3, 0, 2, 16)]
        [TestCase(1, 3, 1, 2, 16)]
        [TestCase(1, 4, 1, 3, 16)]
        [TestCase(1, 3, 2, 2, 16)]
        public void CorrectRemoveTest(
            int start, int end,
            int removeIndex,
            int expectedCount, int expectedCapacity)
        {
            DynArray<int> array = CreateDynArrayWithRange(start, end);
            
            array.Remove(removeIndex);
            
            Assert.True(array.count == expectedCount);
            Assert.True(array.capacity == expectedCapacity);
        }
        
        [TestCase(1, 32, 30, 2, 16)]
        [TestCase(1, 32, 16, 16, 32)]
        [TestCase(1, 32, 17, 15, 21)]
        public void RemoveDecreaseBufferTest(
            int start, int end,
            int removeNum,
            int expectedCount, int expectedCapacity)
        {
            DynArray<int> array = CreateDynArrayWithRange(start, end);

            for (int i = 0; i < removeNum; i++)
            {
                array.Remove(0);
            }
            
            Assert.True(array.count == expectedCount);
            Assert.True(array.capacity == expectedCapacity);
        }
        
        [TestCase(0, -1, 0)]
        [TestCase(1, 1, 1)]
        [TestCase(1, 1, -1)]
        [TestCase(1, 1, 16)]
        [TestCase(1, 16, 16)]
        [TestCase(1, 16, -1)]
        [TestCase(1, 17, 17)]
        public void IncorrectRemoveTest(
            int start, int end,
            int removeIndex)
        {
            DynArray<int> array = CreateDynArrayWithRange(start, end);

            Assert.That(() => array.Remove(removeIndex), Throws.TypeOf<IndexOutOfRangeException>());
        }
        

        [TestCase(0, -1, 1, 2)]
        [TestCase(1, 1, 2, 2)]
        [TestCase(1, 1, -1, 2)]
        [TestCase(1, 1, 40, 40)]
        [TestCase(1, 1, 16, 2)]
        [TestCase(1, 16, 17, 2)]
        [TestCase(1, 18, 20, 2)]
        [TestCase(1, 16, -1, 2)]
        public void IncorrectInsertTest(
            int start, int end,
            int insertIndex, int insertValue)
        {
            DynArray<int> array = CreateDynArrayWithRange(start, end);

            Assert.That(
                () => array.Insert(insertValue, insertIndex),
                Throws.TypeOf<IndexOutOfRangeException>()
                );
        }

        private DynArray<int> CreateDynArrayWithRange(int start, int end)
        {
            DynArray<int> result = new DynArray<int>();

            for (int i = start; i <= end; i++)
            {
                result.Append(i);
            }

            return result;
        }
    }
}