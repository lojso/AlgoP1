using System;
using System.Collections.Generic;

// https://skillsmart.ru/algo/15-121-cm/d5a98a594d.html
namespace AlgorithmsDataStructures
{
    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;
        public bool IsDummy { get; private set; }

        public Node(T _value)
        {
            value = _value;
            IsDummy = false;
            next = null;
            prev = null;
        }

        public Node(T _value, bool isDummy) : this(_value)
        {
            IsDummy = isDummy;
        }
    }

    public class OrderedList<T>
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
        
        private bool _ascending;

        public OrderedList(bool asc)
        {
            Node<T> dummyFirst = new Node<T>(default(T), true);
            Node<T> dummyLast = new Node<T>(default(T), true);
            
            _dummyHead = dummyFirst;
            _dummyTail = dummyLast;

            Clear(asc);
            _ascending = asc;
        }

        public int Compare(T v1, T v2)
        {
            int result = 0;
            if(typeof(T) == typeof(String))
            {
                result = string.Compare(v1 as string, v2 as string);
            }
            else
            {
                result = Comparer<T>.Default.Compare(v1, v2);
            }
      
            return result;
        }

        private bool IsBigger(T v1, T v2)
        {
            return Compare(v1, v2) > 0;
        }
        
        private bool IsLower(T v1, T v2)
        {
            return Compare(v1, v2) < 0;
        }

        public void Add(T value)
        {
            if (Count() == 0)
            {
                InsertBefore(head, new Node<T>(value));
                return;
            }
            
            var curNode = head;
            while (!curNode.IsDummy)
            {
                if (IsBigger(curNode.value, value) && _ascending ||
                    IsLower(curNode.value, value) && !_ascending)
                {
                    InsertBefore(curNode, new Node<T>(value));
                    return;
                }
                curNode = curNode.next;
            }
            InsertAfter(tail, new Node<T>(value));
        }

        public Node<T> Find(T val)
        {
            var curNode = head;
            while (!curNode.IsDummy)
            {
                if (curNode.value.Equals(val))
                    return curNode;
                curNode = curNode.next;
            }
            
            return null; // здесь будет ваш код
        }

        public void Delete(T val)
        {
            RemoveNode(Find(val));
        }

        public void Clear(bool asc)
        {
            _ascending = asc;
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

        List<Node<T>> GetAll() // выдать все элементы упорядоченного 
            // списка в виде стандартного списка
        {
            List<Node<T>> r = new List<Node<T>>();
            Node<T> node = head;
            while(node != null)
            {
                r.Add(node);
                node = node.next;
            }
            return r;
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
        
        private void InsertAfter(Node<T> _nodeAfter, Node<T> _nodeToInsert)
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

        private void InsertBefore(Node<T> _nodeBefore, Node<T> _nodeToInsert)
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
        
        private void RemoveNode(Node<T> node)
        {
            if(node == null)
                return;
            
            node.prev.next = node.next;
            node.next.prev = node.prev;
        }
    }
 
}