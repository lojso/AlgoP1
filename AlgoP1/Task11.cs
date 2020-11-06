using System.Collections.Generic;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        private bool[] _mask;

        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            _mask = new bool[filter_len];
        }
        
        public int Hash1(string str1)
        {
            return Hash(str1, 17);
        }
        public int Hash2(string str1)
        {
            return Hash(str1, 223);
        }

        private int Hash(string val, int randomVal)
        {
            int hash_value = 0;

            for(int i=0; i < val.Length; i++)
            {
                int code = (int)val[i];
                hash_value = (hash_value * randomVal + code) % filter_len;
            }
            
            return hash_value;
        }

        public void Add(string str1)
        {
            _mask[Hash1(str1)] = true;
            _mask[Hash2(str1)] = true;
        }

        public bool IsValue(string str1)
        {
            if (_mask[Hash1(str1)] != true)
                return false;

            if (_mask[Hash2(str1)] != true)
                return false;
            
            return true;
        }

        public bool[] ConvertToBool(int val)
        {
            var b = new bool[filter_len];
            for (int i = 0; i < filter_len; i++)
            {
                b[i] = ((val >> i) & 1) == 1;
            }
            return b;
        }
    }
}