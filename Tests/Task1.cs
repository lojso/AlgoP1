using AlgorithmsDataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [TestCase(null, 2, "", false,null, null) ]
        [TestCase(new []{1}, 1, "", true, null, null)]
        [TestCase(new []{1}, 2, "1", false, 1, 1)]
        [TestCase(new []{1, 2}, 3, "1 2", false, 1, 2)]
        [TestCase(new []{1, 2, 3, 4}, 1, "2 3 4", true, 2, 4)]
        [TestCase(new []{1, 2, 3, 4}, 2, "1 3 4", true, 1, 4)]
        [TestCase(new []{1, 2, 3, 4}, 4, "1 2 3", true, 1, 3)]
        public void RemoveTest(int[] nodeValues, int valToRemove, string listAfterOperation, bool operationValue, int? head, int? tail)
        {
            var testList = CreateLinkedList(nodeValues);

            var removeOperationResult = testList.Remove(valToRemove);
            
            Assert.True(removeOperationResult == operationValue);
            Assert.True(testList.ToString().Equals(listAfterOperation));
            Assert.True(CheckHeadAndTail(testList.head, head));
            Assert.True(CheckHeadAndTail(testList.tail, tail));
        }
        
        [TestCase(null, "", null,  null)]
        [TestCase(new []{1}, "", null,  null)]
        [TestCase(new []{1, 2, 3, 4}, "", null,  null)]
        public void ClearTest(int[] nodeValues, string listAfterOperation, int? head, int? tail)
        {
            var testList = CreateLinkedList(nodeValues);

            testList.Clear();

            Assert.True(CheckHeadAndTail(testList.head, head));
            Assert.True(CheckHeadAndTail(testList.tail, tail));
        }
        
        
        [TestCase(null, 2, "", null, null)]
        [TestCase(new []{1}, 1, "", null, null)]
        [TestCase(new []{1}, 2, "1", 1, 1)]
        [TestCase(new []{1, 2}, 3, "1 2", 1, 2)]
        [TestCase(new []{1, 2, 3, 4}, 1, "2 3 4", 2, 4)]
        [TestCase(new []{1, 2, 3, 4}, 2, "1 3 4", 1, 4)]
        [TestCase(new []{1, 2, 3, 4}, 4, "1 2 3", 1, 3)]
        [TestCase(new []{1, 1}, 1, "", null, null)]
        [TestCase(new []{1, 1, 2, 3, 4}, 1, "2 3 4", 2, 4)]
        [TestCase(new []{1, 1, 2, 3, 4, 1}, 1, "2 3 4", 2, 4)]
        [TestCase(new []{1, 1, 2, 1, 3, 4, 1}, 1, "2 3 4", 2, 4)]
        [TestCase(new []{2, 3, 4}, 1, "2 3 4", 2, 4)]
        [TestCase(new []{2, 3, 4}, 3, "2 4", 2, 4)]
        public void RemoveAllest(int[] nodeValues, int valToRemove, string listAfterOperation, int? head, int? tail)
        {
            var testList = CreateLinkedList(nodeValues);

            testList.RemoveAll(valToRemove);
            
            Assert.True(testList.ToString().Equals(listAfterOperation));
            Assert.True(CheckHeadAndTail(testList.head, head));
            Assert.True(CheckHeadAndTail(testList.tail, tail));
        }

        private bool CheckHeadAndTail(Node node, int? expectedVal)
        {
            if (expectedVal == null)
            {
                return node == null;
            }
            else
            {
                return node.value == expectedVal.Value;
            }
        }

        private LinkedList CreateLinkedList(int[] values)
        {
            LinkedList result = new LinkedList();

            if (values == null)
            {
                return result;
            }
            
            foreach (var val in values)
            {
                result.AddInTail(new Node(val));
            }

            return result;
        }
        
    }
}