using System;
using System.Collections.Generic;

//https://skillsmart.ru/algo/15-121-cm/c49a935fa9.html
namespace Task6
{
    public class DynArray<T>
    {
        public T [] array;
        public int count;
        public int capacity;
        
        private const int MIN_CAPACITY = 16;
        private float _decreaceSizeFillPercentage = 0.5f;

        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }

        public void MakeArray(int new_capacity)
        {
            new_capacity = Math.Max(new_capacity, MIN_CAPACITY);
            if (array == null)
            {
                CreateArray(new_capacity);
            }
            else
            {
                ResizeArray(new_capacity);
            }
            
        }

        public T GetItem(int index)
        {
            if (!IsCorectIndex(index, false))
                throw new IndexOutOfRangeException();
            
            return array[index];
        }

        public void Append(T itm)
        {
            TryIncreaseSize();
            
            array[count] = itm;
            count++;
        }

        public void Insert(T itm, int index)
        {
            if (!IsCorectIndex(index, true))
                throw new IndexOutOfRangeException();
            
            if (index == count)
            {
                Append(itm);
                return;
            }
            
            TryIncreaseSize();

            // TODO: чекнуть этот момент, что делать если вставляем на 0 позицию.
            T[] newArray = new T[capacity];
            Array.Copy(array, newArray, index);
            newArray[index] = itm;
            Array.Copy(array, index, newArray, index + 1, count - index);
            count++;

            array = newArray;
        }

        public void Remove(int index)
        {
            if (!IsCorectIndex(index, false))
                throw new IndexOutOfRangeException();
            
            T[] newArray = new T[capacity];
            Array.Copy(array, newArray, index);
            Array.Copy(array, index + 1, newArray, index, count - index - 1);
            array = newArray;
            count--;
            
            TryReduceSize();
        }

        
        private bool IsCorectIndex(int index, bool isInclusive)
        {
            if(isInclusive)
                return index >= 0 && index <= count;
            
            return index >= 0 && index < count;
        }

        
        private void ResizeArray(int newCapacity)
        {
            newCapacity = Math.Max(newCapacity, MIN_CAPACITY);
            T[] newArray = new T[newCapacity];
            capacity = newCapacity;
            
            Array.Copy(array, newArray, Math.Min(newArray.Length, array.Length));
            array = newArray;

        }

        private void CreateArray(int size)
        {
            size = Math.Max(MIN_CAPACITY, size);
            array = new T[size];
            capacity = size;
        }
        
        private void TryIncreaseSize()
        {
            if(count != capacity)
                return;
            
            ResizeArray(capacity * 2);
        }
        
        private void TryReduceSize()
        {
            if((float) count / capacity >= _decreaceSizeFillPercentage)
                return;
            
            ResizeArray((int)(capacity / 1.5f));
        }
        
    }
}