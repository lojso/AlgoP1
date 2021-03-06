﻿using System;
using System.Collections.Generic;

namespace Task8
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
            return Math.Abs(value.GetHashCode()) % size;
        }

        public int SeekSlot(string value)
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
                curIndex %= size;

            } while (curIndex != hashVal);
            
            return -1;
        }
    }
}