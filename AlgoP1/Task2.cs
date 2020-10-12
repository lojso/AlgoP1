using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures.Task2
{
    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }

    // https://skillsmart.ru/algo/15-121-cm/bafa83f3b9.html
    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
                head.next = null;
                head.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
            }

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
            var curNode = head;

            while (curNode != null)
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

            while (curNode != null)
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
            if (head == tail)
            {
                Clear();
                return;
            }
            
            if (node.prev == null)
            {
                head = node.next;
                head.prev = null;
            }
            else if (node.next == null)
            {
                tail = tail.prev;
                tail.next = null;
            }
            else
            {
                node.next.prev = node.prev;
                node.prev.next = node.next;
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
            if (_nodeAfter != null)
            {
                _nodeToInsert.prev = _nodeAfter;
                _nodeToInsert.next = _nodeAfter.next;
                _nodeToInsert.prev.next = _nodeToInsert;

                if (_nodeToInsert.next != null)
                {
                    _nodeToInsert.next.prev = _nodeToInsert;
                }
                else
                {
                    tail = _nodeToInsert;
                }
            }
            else if (head != null)
            {
                _nodeToInsert.next = head;
                head.prev = _nodeToInsert;
                head = _nodeToInsert;
            }
            else
            {
                _nodeToInsert.next = null;
                _nodeToInsert.prev = null;
                head = _nodeToInsert;
                tail = _nodeToInsert;
            }

                // if (_nodeAfter == null)
            // {
            //     if (head == null)
            //     {
            //         head = _nodeToInsert;
            //         tail = _nodeToInsert;
            //         _nodeToInsert.next = null;
            //     }
            //     else
            //     {
            //         _nodeToInsert.next = head;
            //         head = _nodeToInsert;
            //     }
            // }
            // else
            // {
            //     _nodeToInsert.next = _nodeAfter.next;
            //     _nodeAfter.next = _nodeToInsert;
            //     if (_nodeToInsert.next == null)
            //         tail = _nodeToInsert;
            // }
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