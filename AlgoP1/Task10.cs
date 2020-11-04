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
            foreach (var valExists in _isHaveValue)
            {
                if (valExists)
                    counter++;
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
            return FindValueIndex(value) != -1;
        }

        public bool Remove(T value)
        {
            var valIndex = FindValueIndex(value);

            if (valIndex == -1)
                return false;
            
            _isHaveValue[valIndex] = false;
            _values[valIndex] = default(T);
            return true;
        }

        private int FindValueIndex(T value)
        {
            var hashVal = HashFun(value);
            var curIndex = hashVal;

            do
            {
                if (_isHaveValue[curIndex] && _values[curIndex].Equals(value))
                    return curIndex;

                curIndex += HASH_STEP;
                curIndex %= SET_SIZE;

            } while (curIndex != hashVal);
            
            return -1;
        }

        public PowerSet<T> Intersection(PowerSet<T> set2)
        { 
            var intersection = new PowerSet<T>();
            foreach (var val in set2.ToArray())
            {
                if(this.Get(val))
                    intersection.Put(val);
            }
            return intersection;
        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            var union = new PowerSet<T>();
            
            foreach (var val in set2.ToArray())
            {
                union.Put(val);
            }
            
            foreach (var val in this.ToArray())
            {
                union.Put(val);
            }
            
            return union;
        }

        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            var resultSet = this.Union(new PowerSet<T>());
            
            foreach (var val in this.Intersection(set2).ToArray())
            {
                resultSet.Remove(val);
            }

            return resultSet;
        }

        public bool IsSubset(PowerSet<T> set2)
        {
            var subSet = set2.ToArray();

            foreach (var element in subSet)
            {
                if (!this.Get(element))
                    return false;
            }
            
            return true;
        }

        public T[] ToArray()
        {
            var result = new T[Size()];
            for (int i = 0, j = 0; i < _isHaveValue.Length; i++)
            {
                if (_isHaveValue[i])
                {
                    result[j] = _values[i];
                    j++;
                }
            }

            return result;
        }
        
        private int HashFun(T value)
        {
            return Math.Abs(value.GetHashCode()) % SET_SIZE;
        }

        private int SeekSlot(T value)
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

        public override string ToString()
        {
            var result = "";
            foreach (var value in _values)
            {
                result += value;
                result += " ";
            }

            return result.TrimEnd(' ');
        }
    }
}