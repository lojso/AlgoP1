using System;
using System.Collections.Generic;

//    https://skillsmart.ru/algo/15-121-cm/c5f6d68jj7.html
namespace AlgorithmsDataStructures
{

    public class HashTable
    {
        public int size;
        public int step;
        public string [] slots; 

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for(int i=0; i<size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            return value.GetHashCode() % size;
        }

        public int SeekSlot(string value)
        {
            // находит индекс пустого слота для значения, или -1
            var hashVal = HashFun(value);
            var curIndex = hashVal;

            do
            {
                if (slots[curIndex] == null)
                    return curIndex;

                curIndex += step;

            } while (curIndex != hashVal);
            
            return -1;
        }

        public int Put(string value)
        {
            var index = SeekSlot(value);
            if (index == -1)
                return -1;

            slots[index] = value;

            return index;
        }

        public int Find(string value)
        {
            var hashVal = HashFun(value);
            var curIndex = hashVal;

            do
            {
                if (slots[curIndex] == value)
                    return curIndex;
                
                if (slots[curIndex] == null)
                    return -1;

                curIndex += step;

            } while (curIndex != hashVal);
            
            return -1;
        }
    }
}