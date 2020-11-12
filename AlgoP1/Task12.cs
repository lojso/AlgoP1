using System;

// https://skillsmart.ru/algo/15-121-cm/f1ed710084.html
namespace AlgoP1
{
    public class NativeCache<T>
    {
        public int size;
        public string [] slots;
        public T [] values;
        public int [] hits;
        private int[] _hashIndexes;

        private int step;

        public NativeCache(int sz)
        {
            size = sz;
            step =  3 % size;
            
            slots = new string[size];
            for(int i=0; i<size; i++)
                slots[i] = null;
            
            values = new T[size];
            hits = new int[size];
            
            _hashIndexes = new int[size];
            ClearHashIndexes();
        }

        public int HashFun(string key)
        {
            return Math.Abs(key.GetHashCode()) % size;
        }

        public bool IsKey(string key)
        {
            return SeekSlotForKey(key) >= 0;
        }

        public void Put(string key, T value)
        {
            var putIndex = SeekSlotForSave(key);
            if (putIndex == -1)
            {
                FillHashIndexesForKey(key);
                var minIndex = 0;
                for (var i = 1; i < _hashIndexes.Length && _hashIndexes[i] != -1 ; i++)
                {
                    if (hits[_hashIndexes[i]] < hits[_hashIndexes[minIndex]])
                        minIndex = i;
                }

                putIndex = _hashIndexes[minIndex];
            }

            values[putIndex] = value;
            slots[putIndex] = key;
        }

        public T Get(string key)
        {
            var index = SeekSlotForKey(key);
            if(index < 0)
                return default(T);
            hits[index] += 1;
            return values[index];
        }
        
        private int SeekSlotForSave(string value)
        {
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
        
        private int SeekSlotForKey(string Key)
        {
            var hashVal = HashFun(Key);
            var curIndex = hashVal;

            do
            {
                if (slots[curIndex] == Key)
                    return curIndex;

                curIndex += step;
                curIndex %= size;

            } while (curIndex != hashVal);
            
            return -1;
        }

        private void ClearHashIndexes()
        {
            for(int i=0; i<size; i++)
                _hashIndexes[i] = -1;
        }
        
        private void FillHashIndexesForKey(string key)
        {
            ClearHashIndexes();
            var hashVal = HashFun(key);
            var curIndex = hashVal;
            int i = 0;

            do
            {
                if(i >= _hashIndexes.Length)
                    throw new ArgumentOutOfRangeException("Smth gone wrong. You exceed hash indexes array.");

                _hashIndexes[i] = curIndex;

                i++;
                curIndex += step;
                curIndex %= size;

            } while (curIndex != hashVal);
        }
    } 
}