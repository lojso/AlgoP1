using System.Threading;
using AlgorithmsDataStructures.Task1;

namespace AlgoP1
{
    public static class Task1Ad1
    {
        public static LinkedList Add(LinkedList first, LinkedList second)
        {
            var result = new LinkedList();

            if (first.Count() != second.Count())
            {
                return null;
            }
            
            var firstListNode = first.head;
            var secondListNode = second.head;

            Node head = null; 
            Node tail = null; 

            while (firstListNode != null)
            {
                Node sumNode = new Node(firstListNode.value + secondListNode.value);
                
                result.AddInTail(sumNode);
                
                if (head == null)
                    head = sumNode;

                if (firstListNode.next == null)
                    tail = sumNode;
                
                firstListNode = firstListNode.next;
                secondListNode = secondListNode.next;
            }

            result.head = head;
            result.tail = tail;
            
            return result;
        }
    }
}