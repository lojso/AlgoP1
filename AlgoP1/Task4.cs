using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Stack<T>
    {
        private LinkedList2<T> _list;
        
        public Stack()
        {
            _list = new LinkedList2<T>();
        }

        public int Size()
        {
            return _list.Count();
        }

        public T Pop()
        {
            if (Size() == 0)
                return default(T);

            var resultNode = _list.tail;
            
            _list.RemoveNode(resultNode);
            
            return resultNode.value;
        }

        public void Push(T val)
        {
            _list.AddInTail(new Node<T>(val));
        }

        public T Peek()
        {
            if (Size() == 0)
                return default(T);
            return _list.tail.value;
        }
    }


    public class Node<T>
    {
        public bool IsDummy { get; private set; }
        public T value;
        public Node<T> next, prev;

        public Node(T _value, bool isDummy = false)
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

    public class LinkedList2<T>
    {
        public Node<T> head
        {
            get { return _dummyHead.next; }
        }

        public Node<T> tail
        {
            get { return _dummyTail.prev; }
        }

        private Node<T> _dummyHead;
        private Node<T> _dummyTail;

        public LinkedList2()
        {
            Node<T> dummyFirst = new Node<T>(default(T), true);
            Node<T> dummyLast = new Node<T>(default(T), true);

            _dummyHead = dummyFirst;
            _dummyTail = dummyLast;

            Clear();
        }

        public void AddInTail(Node<T> _item)
        {
            InsertAfter(tail, _item);
        }


        public Node<T> Find(T _value)
        {
            Node<T> node = head;
            while (!node.IsDummy)
            {
                if (node.value.Equals(_value))
                    return node;
                node = node.next;
            }

            return null;
        }

        public List<Node<T>> FindAll(T _value)
        {
            List<Node<T>> nodes = new List<Node<T>>();
            var curNode = head;
            while (!curNode.IsDummy)
            {
                if (curNode.value.Equals(_value))
                    nodes.Add(curNode);

                curNode = curNode.next;
            }

            return nodes;
        }

        public bool Remove(T _value)
        {
            var curNode = head;

            while (!curNode.IsDummy)
            {
                if (curNode.value.Equals(_value))
                {
                    RemoveNode(curNode);
                    return true;
                }

                curNode = curNode.next;
            }

            return false;
        }

        public void RemoveAll(T _value)
        {
            var curNode = head;

            while (!curNode.IsDummy)
            {
                if (curNode.value.Equals(_value))
                {
                    RemoveNode(curNode);
                }

                curNode = curNode.next;
            }
        }

        public void RemoveNode(Node<T> node)
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

        public void InsertAfter(Node<T> _nodeAfter, Node<T> _nodeToInsert)
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

        public void InsertBefore(Node<T> _nodeBefore, Node<T> _nodeToInsert)
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