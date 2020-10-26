using System;
using System.Collections.Generic;

// https://skillsmart.ru/algo/15-121-cm/e192yed1ab.html
namespace Task6
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


}