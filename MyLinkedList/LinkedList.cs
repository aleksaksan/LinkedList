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
                if (counter == idx)
                {
                    current.Data = val;
                    break;
                }
                if (current.Next == null)
                    if (counter > idx)
                        throw new IndexOutOfRangeException("индекс больше количества элементов");
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
                    previous.Next = null;
                    break;
                }
                previous = current;
                current = current.Next;
            }
            _tail = previous;
        }
        //RemoveAt(int idx) - удаление по индексу
        public void RemoveAt(int idx)
        {
            if (idx == 0)
            {
                _head = _head.Next;
                return;
            }
            int counter = 0;
            Node current = _head;
            Node previous = current;
            while (current.Next != null)
            {
                if (counter == idx)
                {
                    previous.Next = current.Next;
                    break;
                }
                counter++;
                previous = current;
                current = current.Next;
            }
            if (counter == idx - 1)
                _tail = previous;

        }
        //RemoveFirstMultiple(int n) - удаление первых n элементов
        public void RemoveFirstMultiple(int n)
        {
            int counter = 0;
            Node current = _head;
            while (current.Next != null && counter < n)
            {
                current = current.Next;
                counter++;
            }
            _head = current;
        }
        //RemoveLastMultiple(int n) - удаление последних n элементов
        public void RemoveLastMultiple(int n)
        {
            int counter = GetLength();
            Node previous = null;
            Node current = _head;
            while (current != null && counter > n)
            {
                counter--;
                previous = current;
                current = current.Next;
            }
            previous.Next = null;
            _tail = previous;
        }
        //RemoveAtMultiple(int idx, int n) - удаление n элементов, начиная с указанного индекса
        public void RemoveAtMultiple(int idx, int n)
        {
            int counter = 0;
            Node current = _head;
            Node flagNode = null;
            while (counter < idx)
            {
                if (counter == idx)
                {
                    flagNode.Next = current;
                    break;
                }
                if (current.Next == null)
                {
                    _tail = current;
                    flagNode.Next = null;
                    return;
                }
                counter++;
                flagNode = current;
                current = current.Next;
            }
            while (counter < idx + n)
            {
                if (current.Next == null)
                {
                    flagNode.Next = null;
                    _tail = current;
                    return;
                }
                counter++;
                current = current.Next;
            }
            flagNode.Next = current.Next;
        }
        //RemoveFirst(int val) - удалить первый попавшийся элемент,
        //значение которого равно val (вернуть индекс удалённого элемента)
        public int RemoveFirst(int val)
        {
            int counter = 0;
            Node current = _head;
            Node previous = current;
            while (current.Next != null)
            {
                if (current.Data == val)
                {
                    previous.Next = current.Next;
                    break;
                }
                if (current.Next == null)
                    return -1;
                counter++;
                previous = current;
                current = current.Next;
            }
            return counter;
        }
        //RemoveAll(int val) - удалить все элементы, равные val (вернуть кол-во удалённых элементов)
        public int RemoveAll(int val)
        {
            int counter = 0;
            Node current = _head;
            Node previous = current;
            while (current.Next != null)
            {
                if (current.Data == val)
                {
                    previous.Next = current.Next;
                }
                if (current.Next == null)
                    _tail = previous.Next;
                counter++;
                previous = current;
                current = current.Next;
            }
            return counter;
        }
        //Contains(int val) - проверка, есть ли элемент в списке
        public bool Contains(int val)
        {
            Node current = _head;
            while (current.Next != null)
            {
                if (current.Data == val)
                    return true;
                current = current.Next;
            }
            return false;
        }
        //IndexOf(int val) - вернёт индекс первого найденного элемента,
        //равного val (или -1, если элементов с таким значением в списке нет)
        public int IndexOf(int val)
        {
            int counter = 0;
            Node current = _head;
            while (current.Next != null)
            {
                if (current.Data == val)
                    return counter;
                if (current.Next == null)
                    return -1;
                current = current.Next;
                counter++;
            }
            return counter;
        }
        //GetFirst() - вернёт значение первого элемента списка
        public int GetFirst()
        {
            return _head.Data;
        }
        //GetLast() - вернёт значение последнего элемента списка
        public int GetLast()
        {
            Node current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            return current.Data;
        }
        //Get(int idx) - вернёт значение элемента списка c указанным индексом
        public int Get(int idx)
        {
            Node current = _head;
            int counter = 0;
            while (current.Next != null)
            {
                if (counter == idx)
                    break;
                if (current.Next == null)
                    throw new IndexOutOfRangeException("индекс больше количества элементов");
                counter++;
                current = current.Next;
            }
            return current.Data;
        }
        //Reverse() - изменение порядка элементов списка на обратный
        public void Revers()
        {
            Node previous = null;
            Node current = _head;
            Node temp;
            while (current != null)
            {
                temp = current.Next;
                current.Next = previous;
                previous = current;
                current = temp;
            }
            _head = previous;
        }
        //Max() - поиск значения максимального элемента
        public int Max()
        {
            if (_head == null)
                return int.MinValue;
            int max = _head.Data;
            Node current = _head;
            while (current.Next != null)
            {
                if (max < current.Data)
                    max = current.Data;
                current = current.Next;
            }
            return max;
        }
        public int Min()
        {
            if (_head == null)
                return int.MaxValue;
            int min = _head.Data;
            Node current = _head;
            while (current.Next != null)
            {
                if (min > current.Data)
                    min = current.Data;
                current = current.Next;
            }
            return min;
        }
        //IndexOfMax() - поиск индекс максимального элемента
        public int IndexOfMax()
        {
            if (_head == null)
                return -1;
            int max = _head.Data;
            int counter = 0;
            int idxOfMax = 0;
            Node current = _head;
            while (current.Next != null)
            {
                if (max < current.Data)
                {
                    max = current.Data;
                    idxOfMax = counter;
                }
                counter++;
                current = current.Next;
            }
            return idxOfMax;
        }
        //IndexOfMin() - поиск индекс минимального элемента
        public int IndexOfMin()
        {
            if (_head == null)
                return -1;
            int min = _head.Data;
            int counter = 0;
            int idxOfMin = 0;
            Node current = _head;
            while (current.Next != null)
            {
                if (min > current.Data)
                {
                    min = current.Data;
                    idxOfMin = counter;
                }
                counter++;
                current = current.Next;
            }
            return idxOfMin;
        }
        //Sort() - сортировка по возрастанию

        public void Sort()
        {
            Node tempPrev, prev, tempCurrent, current, temp;

            tempPrev = prev = _head;
            while (prev.Next != null)
            {
                tempCurrent = current = prev.Next;
                while (current != null)
                {
                    if (prev.Data > current.Data)
                    {
                        if (prev.Next == current)
                        {
                            if (prev == _head)
                            {
                                prev.Next = current.Next;
                                current.Next = prev;
                                //swap:
                                temp = prev;    
                                prev = current;
                                current = temp;

                                tempCurrent = current;

                                _head = prev;

                                current = current.Next;
                            }

                            else
                            {
                                prev.Next = current.Next;
                                current.Next = prev;
                                tempPrev.Next = current;
                                // Swap
                                temp = prev;
                                prev = current;
                                current = temp;

                                tempCurrent = current;

                                current = current.Next;
                            }
                        }
                        else
                        {
                            if (prev == _head)
                            {
                                temp = prev.Next;
                                prev.Next = current.Next;
                                current.Next = temp;
                                tempCurrent.Next = prev;

                                temp = prev;
                                prev = current;
                                current = temp;

                                tempCurrent = current;

                                current = current.Next;

                                _head = prev;
                            }

                            // prev != _head
                            else
                            {
                                temp = prev.Next;
                                prev.Next = current.Next;
                                current.Next = temp;
                                tempCurrent.Next = prev;
                                tempPrev.Next = current;

                                temp = prev;
                                prev = current;
                                current = temp;

                                tempCurrent = current;

                                current = current.Next;
                            }
                        }
                    }
                    else
                    {
                        tempCurrent = current;
                        current = current.Next;
                    }
                }
                tempPrev = prev;
                prev = prev.Next;
            }
        }
        //SortDesc() - сортировка по убыванию
        public void SortDesc()
        {
            Node tempPrev, prev, tempCurrent, current, temp;

            tempPrev = prev = _head;
            while (prev.Next != null)
            {
                tempCurrent = current = prev.Next;
                while (current != null)
                {
                    if (prev.Data < current.Data)
                    {
                        if (prev.Next == current)
                        {
                            if (prev == _head)
                            {
                                prev.Next = current.Next;
                                current.Next = prev;
                                //swap:
                                temp = prev;
                                prev = current;
                                current = temp;

                                tempCurrent = current;

                                _head = prev;

                                current = current.Next;
                            }

                            else
                            {
                                prev.Next = current.Next;
                                current.Next = prev;
                                tempPrev.Next = current;
                                // Swap
                                temp = prev;
                                prev = current;
                                current = temp;

                                tempCurrent = current;

                                current = current.Next;
                            }
                        }
                        else
                        {
                            if (prev == _head)
                            {
                                temp = prev.Next;
                                prev.Next = current.Next;
                                current.Next = temp;
                                tempCurrent.Next = prev;

                                temp = prev;
                                prev = current;
                                current = temp;

                                tempCurrent = current;

                                current = current.Next;

                                _head = prev;
                            }

                            // prev != _head
                            else
                            {
                                temp = prev.Next;
                                prev.Next = current.Next;
                                current.Next = temp;
                                tempCurrent.Next = prev;
                                tempPrev.Next = current;

                                temp = prev;
                                prev = current;
                                current = temp;

                                tempCurrent = current;

                                current = current.Next;
                            }
                        }
                    }
                    else
                    {
                        tempCurrent = current;
                        current = current.Next;
                    }
                }
                tempPrev = prev;
                prev = prev.Next;
            }
        }
    }
}
