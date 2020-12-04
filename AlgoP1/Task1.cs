using System;
using System.Collections.Generic;

namespace Task6.Task1
{
    public class Node
    {
        public int value;
        public Node next;

        public Node(int _value)
        {
            value = _value;
        }

        public override string ToString()

        {
            return value.ToString();
        }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)
                head = _item;
            else
                tail.next = _item;

            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
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
            while (curNode != null)
            {
                if (curNode.value == _value)
                    nodes.Add(curNode);

                curNode = curNode.next;
            }

            return nodes;
        }

        public bool Remove(int _value)
        {
            Node prevNode = null;
            var curNode = head;

            while (curNode != null)
            {
                if (curNode.value == _value)
                {
                    RemoveNode(curNode, prevNode);
                    return true;
                }

                prevNode = curNode.value == _value ? prevNode : curNode;
                curNode = curNode.next;
            }

            return false;
        }

        public void RemoveAll(int _value)
        {
            Node prevNode = null;
            var curNode = head;

            while (curNode != null)
            {
                if (curNode.value == _value)
                {
                    RemoveNode(curNode, prevNode);
                }

                prevNode = curNode.value == _value ? prevNode : curNode;
                curNode = curNode.next;
            }
        }

        private void RemoveNode(Node curNode, Node prevNode)
        {
            if (prevNode == null)
            {
                curNode = curNode.next;
                head = curNode;
                if (curNode == null)
                    tail = null;
            }
            else
            {
                prevNode.next = curNode.next;
                if (prevNode.next == null)
                    tail = prevNode;
            }
        }

        public void Clear()
        {
            head = null;
            tail = null;
        }

        public int Count()
        {
            int count = 0;
            var curNode = head;
            while (curNode != null)
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
                if (head == null)
                {
                    head = _nodeToInsert;
                    tail = _nodeToInsert;
                    _nodeToInsert.next = null;
                }
                else
                {
                    _nodeToInsert.next = head;
                    head = _nodeToInsert;
                }
            }
            else
            {
                _nodeToInsert.next = _nodeAfter.next;
                _nodeAfter.next = _nodeToInsert;
                if (_nodeToInsert.next == null)
                    tail = _nodeToInsert;
            }
        }

        public override string ToString()
        {
            string result = "";
            var curNode = head;
            while (curNode != null)
            {
                result += curNode.value + " ";
                curNode = curNode.next;
            }

            return result.TrimEnd();
        }
    }
}