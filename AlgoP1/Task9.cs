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

        public NativeDictionary(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
        }

        public int HashFun(string key)
        {
            // всегда возвращает корректный индекс слота
            return 0;
        }

        public bool IsKey(string key)
        {
            // возвращает true если ключ имеется,
            // иначе false
            return false;
        }

        public void Put(string key, T value)
        {
            // гарантированно записываем 
            // значение value по ключу key
        }

        public T Get(string key)
        {
            // возвращает value для key, 
            // или null если ключ не найден
            return default(T);
        }
    } 
}