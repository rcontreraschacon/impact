using System;
using DataStructureLibrary.Lists.Abstractions;

namespace DataStructureLibrary.Lists
{
    public class LinkedList<T> : ILinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        private int _count;
        public int Count
        {
            get { return _count; }
        }

        public LinkedList()
        {
            Clear();
        }

        public void Push(T element)
        {
            InsertAt(_count, element);
        }

        public void Add(T element)
        {
            InsertAt(0, element);
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public bool Contains(T element)
        {
            var result = false;
            var node = _head;

            while (node != null)
            {
                if (node.Element.Equals(element))
                {
                    result = true;
                    break;
                }

                node = node.Next;
            }

            return result;
        }

        public int IndexOf(T element)
        {
            var result = -1;
            var node = _head;

            var iterationIndex = 0;
            while (node != null)
            {
                if (node.Element.Equals(element))
                {
                    result = iterationIndex;
                    break;
                }

                node = node.Next;
                iterationIndex++;
            }

            return result;
        }

        public void InsertAt(int index, T element)
        {
            if (index < 0 || index > _count)
            {
                // Index is out of bound
                throw new ArgumentException($"The argument '{index}' is must be greater than or equal to 0; and less than or equal to {_count}.");
            }

            var newNode = new Node<T>(element);
            if (_count == 0 && index == 0)
            {
                // LinkedList is empty
                _head = newNode;
                _tail = newNode;
                _count++;
                return;
            }

            // LinkedList not empty
            if (_count > 0 && index == 0)
            {
                // Insert at the beginning
                _head.Previous = newNode;
                newNode.Next = _head;
                _head = newNode;
                _count++;
                return;
            }

            if (_count > 0 && index == _count)
            {
                // Insert at the end
                _tail.Next = newNode;
                newNode.Previous = _tail;
                _tail = newNode;
                _count++;
                return;
            }

            // Insert in the middle
            var node = _head;
            var iterationIndex = 0;
            while (node != null)
            {
                if (iterationIndex == index)
                {
                    break;
                }

                node = node.Next;
                iterationIndex++;
            };
            newNode.Next = node;
            newNode.Previous = node.Previous;
            node.Previous = newNode;
            newNode.Previous.Next = newNode;
            _count++;
        }

        public void Remove(T element)
        {
            var index = IndexOf(element);
            if (index != -1)
                RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                // Index is out of bound
                throw new ArgumentException($"The argument '{index}' is must be greater than or equal to 0; and less than or equal to {_count}.");
            }

            if (_count == 0 && index == 0)
            {
                // LinkedList is empty
                return;
            }

            // LinkedList not empty
            if (_count == 1 && index == 0)
            {
                // Removes the last element of the whole LinkedList
                Clear();
                return;
            }


            if (_count > 1 && index == 0)
            {
                // Remove element at the beginning
                _head = _head.Next;
                _head.Previous = null;
                _count--;
                return;
            }

            if (_count > 1 && index == (_count - 1))
            {
                // Remove element at the end
                _tail = _tail.Previous;
                _tail.Next = null;
                _count--;
                return;
            }

            // Remove element in the middle
            var node = _head;
            var iterationIndex = 0;
            while (node != null)
            {
                if (iterationIndex == index)
                {
                    break;
                }

                node = node.Next;
                iterationIndex++;
            };

            var previousNode = node.Previous;
            previousNode.Next = node.Next;
            node.Next.Previous = previousNode;
            _count--;
        }

        private class Node<K>
        {
            public K Element { get; set; }

            public Node<K> Next { get; set; }

            public Node<K> Previous { get; set; }

            public Node(K element)
            {
                this.Element = element;
                this.Next = null;
                this.Previous = null;
            }
        }
    }
}