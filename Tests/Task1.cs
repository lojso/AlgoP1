using System;
using System.Collections.Generic;
using AlgorithmsDataStructures;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [TestCase(null, 2, "", false)]
        [TestCase(new []{1}, 1, "", true)]
        [TestCase(new []{1}, 2, "1", false)]
        [TestCase(new []{1, 2}, 3, "1 2", false)]
        [TestCase(new []{1, 2, 3, 4}, 1, "2 3 4", true)]
        [TestCase(new []{1, 2, 3, 4}, 2, "1 3 4", true)]
        [TestCase(new []{1, 2, 3, 4}, 4, "1 2 3", true)]
        public void RemoveTest(int[] nodeValues, int valToRemove, string listAfterOperation, bool operationValue)
        {
            var testList = CreateLinkedList(nodeValues);

            var removeOperationResult = testList.Remove(valToRemove);
            
            Assert.True(removeOperationResult == operationValue);
            Assert.True(testList.ToString().Equals(listAfterOperation));
        }
        
        [TestCase(null, 2, "")]
        [TestCase(new []{1}, 1, "")]
        [TestCase(new []{1}, 2, "1")]
        [TestCase(new []{1, 2}, 3, "1 2")]
        [TestCase(new []{1, 2, 3, 4}, 1, "2 3 4")]
        [TestCase(new []{1, 2, 3, 4}, 2, "1 3 4")]
        [TestCase(new []{1, 2, 3, 4}, 4, "1 2 3")]
        [TestCase(new []{1, 1}, 1, "")]
        [TestCase(new []{1, 1, 2, 3, 4}, 1, "2 3 4")]
        [TestCase(new []{1, 1, 2, 3, 4, 1}, 1, "2 3 4")]
        [TestCase(new []{1, 1, 2, 1, 3, 4, 1}, 1, "2 3 4")]
        [TestCase(new []{2, 3, 4}, 1, "2 3 4")]
        [TestCase(new []{2, 3, 4}, 3, "2 4")]
        public void RemoveAllest(int[] nodeValues, int valToRemove, string listAfterOperation)
        {
            var testList = CreateLinkedList(nodeValues);

            testList.RemoveAll(valToRemove);
            
            Assert.True(testList.ToString().Equals(listAfterOperation));
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