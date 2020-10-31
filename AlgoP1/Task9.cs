using System;
using System.Collections.Generic;

// https://skillsmart.ru/algo/15-121-cm/d318f1aeed.html
namespace AlgorithmsDataStructures
{
    public class NativeDictionary<T>
    {
        public int size;
        public string [] slots;
        public T [] values;

        private int step;

        public NativeDictionary(int sz)
        {
            size = sz;
            slots = new string[size];
            for(int i=0; i<size; i++)
                slots[i] = null;
            values = new T[size];
            step %= size;
        }

        public int HashFun(string key)
        {
            return Math.Abs(key.GetHashCode()) % size;
        }

        public bool IsKey(string key)
        {
            return FindKeyIndex(key) >= 0;
        }

        public void Put(string key, T value)
        {
            var putIndex = SeekSlot(key);
            if(putIndex == -1)
                throw new IndexOutOfRangeException("Dictionary overflow");
            values[putIndex] = value;
            slots[putIndex] = key;
        }

        public T Get(string key)
        {
            // возвращает value для key, 
            // или null если ключ не найден
            var index = FindKeyIndex(key);
            if(index < 0)
                return default(T);
            return values[index];
        }
        
        private int SeekSlot(string value)
        {
            // находит индекс пустого слота для значения, или -1
            var hashVal = HashFun(value);
            var curIndex = hashVal;

            do
            {
                if (slots[curIndex] == null || slots[curIndex] == value)
                    return curIndex;

                curIndex += step;
                curIndex %= size;

            } while (curIndex != hashVal);
            
            return -1;
        }
        
        private int FindKeyIndex(string Key)
        {
            var hashVal = HashFun(Key);
            var curIndex = hashVal;

            do
            {
                if (slots[curIndex] == Key)
                    return curIndex;
                
                if (slots[curIndex] == null)
                    return -1;

                curIndex += step;
                curIndex %= size;

            } while (curIndex != hashVal);
            
            return -1;
        }
    } 
}