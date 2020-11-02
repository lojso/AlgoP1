using System;
using System.Collections.Generic;

// https://skillsmart.ru/algo/15-121-cm/c9b6abc9e1.html
namespace AlgorithmsDataStructures
{

    // наследуйте этот класс от HashTable
    // или расширьте его методами из HashTable
    public class PowerSet<T>
    {
        private const int SET_SIZE = 20000;
        private const int HASH_STEP = 7;

        private T[] _values;
        private bool[] _isHaveValue;

        public PowerSet()
        {
            _values = new T[SET_SIZE];
            _isHaveValue = new bool[SET_SIZE];
        }

        public int Size()
        {
            int counter = 0;
            for (int i = 0; i < _values.Length; i++)
            {
                counter += 1;
            }
            return counter;
        }

        public void Put(T value)
        {
            var putIndex = SeekSlot(value);
            if(putIndex == -1)
                throw new OutOfMemoryException("Превышен размер множества");

            _isHaveValue[putIndex] = true;
            _values[putIndex] = value;
        }

        public bool Get(T value)
        {
            var hashVal = HashFun(value);
            var curIndex = hashVal;

            do
            {
                if (_values[curIndex].Equals(value))
                    return true;

                curIndex += HASH_STEP;
                curIndex %= SET_SIZE;

            } while (curIndex != hashVal);
            
            return false;
        }

        public bool Remove(T value)
        {
            var hashVal = HashFun(value);
            var curIndex = hashVal;

            do
            {
                if (_values[curIndex].Equals(value))
                {
                    _isHaveValue[curIndex] = false;
                    _values[curIndex] = default(T);
                    return true;
                }
                    
                curIndex += HASH_STEP;
                curIndex %= SET_SIZE;

            } while (curIndex != hashVal);
            
            return false;
        }

        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            // пересечение текущего множества и set2
            return null;
        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            // объединение текущего множества и set2
            return null;
        }

        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            // разница текущего множества и set2
            return null;
        }

        public bool IsSubset(PowerSet<T> set2)
        {
            // возвращает true, если set2 есть
            // подмножество текущего множества,
            // иначе false
            return false;
        }
        
        private int HashFun(T value)
        {
            return Math.Abs(value.GetHashCode()) % SET_SIZE;
        }

        public int SeekSlot(T value)
        {
            var hashVal = HashFun(value);
            var curIndex = hashVal;

            do
            {
                if (_isHaveValue[curIndex] == false || _values[curIndex].Equals(value))
                    return curIndex;

                curIndex += HASH_STEP;
                curIndex %= SET_SIZE;

            } while (curIndex != hashVal);
            
            return -1;
        }
    }
}