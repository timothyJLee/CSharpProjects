





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment100FINALTimothyLee
{
    public class CustomHashTable<K, V>
    {
        private int size;
        private LinkedList<KeyValue<K, V>>[] Objects;

        public CustomHashTable(int size)
        {
            this.size = size;
            Objects = new LinkedList<KeyValue<K, V>>[size];
        }

        private int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        public V Find(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> findLinkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in findLinkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }

        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> addLinkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
            addLinkedList.AddLast(item);
        }

        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> removeLinkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in removeLinkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }

            if (itemFound)
            {
                removeLinkedList.Remove(foundItem);
            }
        }

        

        private LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = Objects[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                Objects[position] = linkedList;
            }

            return linkedList;
        }
    }
}