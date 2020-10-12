using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace Task2Ad1
{
    public class Node
    {
        public bool IsDummy { get; private set; }
        public int value;
        public Node next, prev;

        public Node(int _value, bool isDummy = false)
        {
            IsDummy = isDummy;
            value = _value;
            next = null;
            prev = null;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }

    public class LinkedList2
    {
        public Node head
        {
            get { return _dummyHead.next; }
        }

        public Node tail
        {
            get { return _dummyTail.prev; }
        }

        private Node _dummyHead;
        private Node _dummyTail;

        public LinkedList2()
        {
            Node dummyFirst = new Node(0, true);
            Node dummyLast = new Node(0, true);

            _dummyHead = dummyFirst;
            _dummyTail = dummyLast;

            Clear();
        }

        public void AddInTail(Node _item)
        {
            InsertAfter(tail, _item);
        }


        public Node Find(int _value)
        {
            Node node = head;
            while (!node.IsDummy)
            {
                if (node.value == _value)
                    return node;
                node = node.next;
            }

            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            var curNode = head;
            while (!curNode.IsDummy)
            {
                if (curNode.value == _value)
                    nodes.Add(curNode);

                curNode = curNode.next;
            }

            return nodes;
        }

        public bool Remove(int _value)
        {
            var curNode = head;

            while (!curNode.IsDummy)
            {
                if (curNode.value == _value)
                {
                    RemoveNode(curNode);
                    return true;
                }

                curNode = curNode.next;
            }

            return false;
        }

        public void RemoveAll(int _value)
        {
            var curNode = head;

            while (!curNode.IsDummy)
            {
                if (curNode.value == _value)
                {
                    RemoveNode(curNode);
                }

                curNode = curNode.next;
            }
        }

        private void RemoveNode(Node node)
        {
            node.prev.next = node.next;
            node.next.prev = node.prev;
        }

        public void Clear()
        {
            _dummyHead.next = _dummyTail;
            _dummyTail.prev = _dummyHead;
        }

        public int Count()
        {
            int count = 0;
            var curNode = head;
            while (!curNode.IsDummy)
            {
                count += 1;
                curNode = curNode.next;
            }

            return count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            if (_nodeAfter == null)
            {
                InsertBefore(head, _nodeToInsert);
            }
            else
            {
                _nodeToInsert.prev = _nodeAfter;
                _nodeToInsert.next = _nodeAfter.next;

                _nodeToInsert.prev.next = _nodeToInsert;
                _nodeToInsert.next.prev = _nodeToInsert;
            }
        }

        public void InsertBefore(Node _nodeBefore, Node _nodeToInsert)
        {
            if (_nodeBefore == null)
            {
                InsertAfter(tail, _nodeToInsert);
            }
            else
            {
                _nodeToInsert.next = _nodeBefore;
                _nodeToInsert.prev = _nodeBefore.prev;

                _nodeToInsert.prev.next = _nodeToInsert;
                _nodeToInsert.next.prev = _nodeToInsert;
            }
        }

        public override string ToString()
        {
            string result = "";
            var curNode = head;
            while (!curNode.IsDummy)
            {
                result += curNode.value + " ";
                curNode = curNode.next;
            }

            return result.TrimEnd();
        }
    }
}