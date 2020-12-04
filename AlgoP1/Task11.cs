using System;

namespace Task11
{
    public class BloomFilter
    {
        public int filter_len;
        private Int32 _intMask;

        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            _intMask = 0;
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
            _intMask = SetRegister(_intMask, Hash1(str1));
            _intMask = SetRegister(_intMask, Hash2(str1));
        }

        public Int32 SetRegister(Int32 num, int index)
        {
            return (1 << index) | num;
        }
        
        public bool GetRegister(Int32 num, int index)
        {
            return (num & (1 << index)) != 0;;
        }

        public bool IsValue(string str1)
        {
            if (GetRegister(_intMask, Hash1(str1)) != true)
                return false;
            
            if (GetRegister(_intMask, Hash2(str1)) != true)
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