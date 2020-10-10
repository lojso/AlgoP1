using System.CodeDom;
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
        
        [TestCase(null, 0, 1)]
        [TestCase(new []{1}, 1, 1)]
        [TestCase(new []{1, 1, 1}, 3, 1)]
        [TestCase(new []{2, 3, 4}, 0, 1)]
        [TestCase(new []{1, 2, 3, 4}, 1, 1)]
        [TestCase(new []{1, 1, 2, 3, 4}, 2, 1)]
        public void FoundAllTest(int[] nodeValues, int expectedNodesCount, int expectedNodesValue)
        {
            var testList = CreateLinkedList(nodeValues);

            var foundNodes = testList.FindAll(expectedNodesValue);

            foreach (var node in foundNodes)
            {
                Assert.True(node.value == expectedNodesValue);
            }
            
            Assert.True(foundNodes.Count == expectedNodesCount);
        }
        
        [TestCase(null, 0)]
        [TestCase(new []{1}, 1)]
        [TestCase(new []{1, 1, 1}, 3)]
        [TestCase(new []{2, 3, 4}, 3)]
        [TestCase(new []{1, 2, 3, 4}, 4)]
        [TestCase(new []{1, 1, 2, 3, 4}, 5)]
        public void CountTest(int[] nodeValues, int expectedCount)
        {
            var testList = CreateLinkedList(nodeValues);

            Assert.True(testList.Count() == expectedCount);
        }
        
        
        [TestCase(null, 2, "", null, null)]
        [TestCase(new []{1}, 1, "", null, null)]
        [TestCase(new []{1}, 2, "1", 1, 1)]
        [TestCase(new []{1, 1}, 1, "", null, null)]
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
        public void RemoveAllTest(int[] nodeValues, int valToRemove, string listAfterOperation, int? head, int? tail)
        {
            var testList = CreateLinkedList(nodeValues);

            testList.RemoveAll(valToRemove);
            
            Assert.True(testList.ToString().Equals(listAfterOperation));
            Assert.True(CheckHeadAndTail(testList.head, head));
            Assert.True(CheckHeadAndTail(testList.tail, tail));
        }
        
        [TestCase(new []{2, 3, 4}, null, 1, "1 2 3 4", 1, 4)]
        [TestCase(new []{2, 3, 4}, 0, 1, "2 1 3 4", 2, 4)]
        [TestCase(new []{2, 3, 4}, 1, 1, "2 3 1 4", 2, 4)]
        [TestCase(new []{2, 3, 4}, 2, 1, "2 3 4 1", 2, 1)]
        [TestCase(new []{2, 4}, null, 1, "1 2 4", 1, 4)]
        [TestCase(new []{2, 4}, 1, 1, "2 4 1", 2, 1)]
        [TestCase(new []{2}, 0, 1, "2 1", 2, 1)]
        [TestCase(new []{2}, null, 1, "1 2", 1, 2)]
        [TestCase(null, null, 1, "1", 1, 1)]
        public void InsertAfterTest(int[] nodeValues, int? insertAfterPosition, int insertNodeValue, string resultList, int? head, int? tail)
        {
            var testList = CreateLinkedList(nodeValues);
            Node positionNode = GetNodeAtPosition(testList, insertAfterPosition);
            
            testList.InsertAfter(positionNode, new Node(insertNodeValue));

            Assert.True(testList.ToString().Equals(resultList));
            Assert.True(CheckHeadAndTail(testList.head, head));
            Assert.True(CheckHeadAndTail(testList.tail, tail));
        }

        private Node GetNodeAtPosition(LinkedList testList, int? insertAfterPosition)
        {
            var curNode = testList.head;

            if (insertAfterPosition == null)
                return null;

            if (insertAfterPosition.Value > testList.Count())
                return testList.tail;
            
            var counter = 0;
            while (curNode != null && counter < insertAfterPosition)
            {
                curNode = curNode.next;
                counter++;
            }

            return curNode;
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