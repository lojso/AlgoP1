using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack<T>
    {
        public Stack()
        {
            // инициализация внутреннего хранилища стека
        } 

        public int Size() 
        {
            // размер текущего стека		  
            return 0;
        }

        public T Pop()
        {
            // ваш код
            return default(T); // null, если стек пустой
        }
	  
        public void Push(T val)
        {
            // ваш код
        }

        public T Peek()
        {
            // ваш код
            return default(T); // null, если стек пустой
        }
    }

}