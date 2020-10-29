using System;
using System.Collections.Generic;

// https://skillsmart.ru/algo/15-121-cm/d5a98a594d.html
namespace AlgorithmsDataStructures
{
    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }


    public class OrderedList<T>
    {
        public Node<T> head, tail;
        private bool _ascending;

        public OrderedList(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
        }

        public Node<T> Find(T val)
        {
            var curNode = head;
            while (curNode != null)
            {
                if (_ascending && IsBigger(curNode.value, val))
                    return null;
                
                if (!_ascending && IsBigger(val, curNode.value))
                    return null;
                
                if (curNode.value.Equals(val))
                    return curNode;
                
                curNode = curNode.next;
            }

            return null;
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
                InsertAfter(null, new Node<T>(value));
                return;
            }
            
            var curNode = head;
            while (curNode != null)
            {
                if (IsBigger(curNode.value, value) && _ascending ||
                    IsLower(curNode.value, value) && !_ascending)
                {
                    InsertAfter(curNode.prev, new Node<T>(value));
                    return;
                }
                curNode = curNode.next;
            }
            InsertAfter(tail, new Node<T>(value));
        }

        public void Delete(T val)
        {
            RemoveNode(Find(val));
        }

        public void Clear(bool asc)
        {
            _ascending = asc;
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

        List<Node<T>> GetAll() 
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
            while (curNode != null)
            {
                result += curNode.value + " ";
                curNode = curNode.next;
            }

            return result.TrimEnd();
        }
        
        public void InsertAfter(Node<T> _nodeAfter, Node<T> _nodeToInsert)
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
        }

        private void RemoveNode(Node<T> node)
        {
            if (head == tail)
            {
                Clear(_ascending);
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
    }
 
}