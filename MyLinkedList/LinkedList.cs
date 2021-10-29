using System;

namespace MyLinkedList
{
    
    public class LinkedList
    {
        class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }

            public Node(int val)
            {
                Data = val;
                Next = null;
            }
        }
        Node _head;
        Node _tail;
        
        public LinkedList()
        {
            _head = null;
            _tail = _head;
        }
        public LinkedList(int val)
        {
            Node node = new Node(val);
            _head = node;
            _tail = _head;
        }
        public LinkedList(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++) 
            {
                AddLast(arr[i]);
            }
        }
        public void PrintList()
        {
            int[] arr = ToArray();

            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]}\t");
            Console.WriteLine();
        }
        //GetLength() - узнать кол-во элементов в списке
        public int GetLength()
        {
            int count = 0;
            Node currentNode = _head;
            while (currentNode != null)
            {
                count++;
                currentNode = currentNode.Next;
            }
            return count;
        }
        //ToArray() - вернёт хранимые данные в виде массива
        public int[] ToArray()
        {
            int[] arr = new int[GetLength()];
            Node currentNode = _head;
            //int iter = 0;
            //while (currentNode != null)
            //{
            //    arr[iter] = currentNode.Data;
            //    iter++;
            //    currentNode = currentNode.Next;
            //}
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = currentNode.Data;
                currentNode = currentNode.Next;
            }
            return arr;
        }
        //AddFirst(int val) - добавление в начало списка
        public void AddFirst(int val)
        {
            Node node = new Node(val);
            node.Next = _head;
            _head = node;
        }
        //AddFirst(LinkedList list) - то же самое, но с вашим самодельным классом (т.е. слияние двух списков)
        public void AddFirst(LinkedList list)
        {
            Node tempHead = _head;
            _head = list._head;
            Node current = list._tail;
            current.Next = tempHead;
        }
        //AddLast(int val) - добавление в конец списка
        public void AddLast(int val)
        {
            //if (_head == null)
            //    _head = new Node(val);

            //Node current = _head;
            //while (current != null)
            //    current = current.Next;
            //current = new Node(val);

            Node node = new Node(val);
            if (_head == null)
                _head = node;
            else
                _tail.Next = node;
            _tail = node;
        }
        //AddLast(LinkedList list) - то же самое, но с вашим самодельным классом
        public void AddLast(LinkedList list)
        {
            _tail.Next = list._head;
            _tail = list._tail;
        }
        //AddAt(int idx, int val) - вставка по указанному индексу
        public void AddAt(int idx, int val)
        {
            int counter = 0;
            Node insertionNode = new Node(val);
            if (_head == null || idx == 0)
                AddFirst(insertionNode.Data);
            Node current = _head;
            while (current != null)
            {
                if (counter > idx) 
                    throw new ArgumentException("индекс больше количества элементов");
                if (counter == idx-1)
                {
                    Node temp = current.Next;
                    current.Next = insertionNode;
                    insertionNode.Next = temp;
                    break;
                }
                current = current.Next;
                counter++;
            }
        }
        //AddAt(int idx, LinkedList list) - то же самое, но с вашим самодельным классом
        public void AddAt(int idx, LinkedList list)
        {
            int counter = 0;
            if (_head == null || idx == 0)
                AddFirst(list);
            Node current = _head;
            Node tempHead = _head;
            while (current != null)
            {
                if (counter > idx)
                    throw new ArgumentException("индекс больше количества элементов списка");
                if (counter == idx - 1)
                {
                    _head = current.Next;
                    current.Next = list._head;
                    list.AddLast(this);
                    _head = tempHead;
                    break;
                }
                current = current.Next;
                counter++;
            }
        }
        //Set(int idx, int val) - поменять значение элемента с указанным индексом
        public void Set(int idx, int val)
        {
            int counter = 0;
            if (_head == null || idx == 0)
            {
                Node insertionNode = new Node(val);
                AddFirst(insertionNode.Data);
            }
            Node current = _head;
            while (current != null)
            {
                if (counter > idx)
                    throw new ArgumentException("индекс больше количества элементов");
                if (counter == idx)
                {
                    current.Data = val;
                    break;
                }
                current = current.Next;
                counter++;
            }
        }
        //RemoveFirst() - удаление первого элемента
        public void RemoveFirst()
        {
            _head = _head.Next;
        }
        //RemoveLast() - удаление последнего элемента
        public void RemoveLast()
        {
            Node previous = null;
            Node current = _head;
            while (current != null)
            {
                if (current.Next == null)
                {
                    previous.Next = current.Next;
                    break;
                }
                previous = current;
                current = current.Next;
            }
            _tail = previous;
        }
    }
}
