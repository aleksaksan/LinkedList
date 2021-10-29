using System;

namespace MyLinkedList
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };
            LinkedList li = new LinkedList(arr); 
            
            li.AddLast(77);
            li.AddLast(88);
            li.AddFirst(000);
            li.PrintList();

            LinkedList lis = new LinkedList(new int[] { 111,222,333,444});
            //li.AddLast(lis);
            li.AddAt(1, lis);
            li.Set(1, 5);
           // li.PrintList();
            li.RemoveFirst();
            li.RemoveLast();
            li.PrintList();

        }
    }
}
