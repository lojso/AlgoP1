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
            const int m = 1000000000 + 9;
            int hash_value = 0;
            int p_pow = 1;
            
            for(int i=0; i < val.Length; i++)
            {
                hash_value = (hash_value + (val[i] + 1) * p_pow) % m;
                p_pow = (p_pow * randomVal) % m;
            }
            
            return hash_value % filter_len;
        }

        public void Add(string str1)
        {
            var boolVal1 = ConvertToBool(Hash1(str1));
            var boolVal2 = ConvertToBool(Hash2(str1));
            for (int i = 0; i < filter_len; i++)
            {
                _mask[i] = _mask[i] || boolVal1[i] || boolVal2[i];
            }
        }

        public bool IsValue(string str1)
        {
            var boolVal1 = ConvertToBool(Hash1(str1));
            var boolVal2 = ConvertToBool(Hash2(str1));
            for (int i = 0; i < filter_len; i++)
            {
                if (boolVal1[i] == true && _mask[i] != true)
                    return false;
                
                if (boolVal2[i] == true && _mask[i] != true)
                    return false;
            }
            
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