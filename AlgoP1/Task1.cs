using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
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
            // здесь будет ваш код поиска всех узлов по заданному значению
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
            return 0; // здесь будет ваш код подсчёта количества элементов в списке
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            // здесь будет ваш код вставки узла после заданного

            // если _nodeAfter = null , 
            // добавьте новый элемент первым в списке 
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