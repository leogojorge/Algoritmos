namespace DataStructure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OperateOnSinlgyLinkedList();
            //OperateOnStackArray();
        }

        public static void OperateOnSinlgyLinkedList()
        {
            var sinlgyLinkedList = new SinglyLinkedList<int>();

            sinlgyLinkedList.Add(3);
            sinlgyLinkedList.Add(1);
            sinlgyLinkedList.Add(4);
            sinlgyLinkedList.Add(7);
            sinlgyLinkedList.Add(23);
            sinlgyLinkedList.Add(8);
            sinlgyLinkedList.Add(22);
            
            Console.WriteLine(sinlgyLinkedList.GetSize());

            sinlgyLinkedList.Print();

            sinlgyLinkedList.AddLast(44);

            sinlgyLinkedList.Print();

            sinlgyLinkedList.AddFirst(67);

            sinlgyLinkedList.Print();

            sinlgyLinkedList.Add(13, 2);

            sinlgyLinkedList.Print();

            sinlgyLinkedList.Remove(44);

            sinlgyLinkedList.Print();
                        
            sinlgyLinkedList.Remove(22);

            Console.WriteLine(sinlgyLinkedList.FindLast());

            sinlgyLinkedList.Remove(8);
            sinlgyLinkedList.Print();

            sinlgyLinkedList.Print();
            Console.WriteLine(sinlgyLinkedList.FindLast());

            sinlgyLinkedList.RemoveFirst();

            sinlgyLinkedList.Print();

            sinlgyLinkedList.RemoveLast();

            Console.WriteLine(sinlgyLinkedList.FindLast());
            sinlgyLinkedList.Print();

            sinlgyLinkedList.RemoveLast();
            
            sinlgyLinkedList.Print();
            
            Console.WriteLine(sinlgyLinkedList.GetSize());
            Console.WriteLine(sinlgyLinkedList.FindLast());
                        
            Console.WriteLine(sinlgyLinkedList.Contains(3));
            Console.WriteLine(sinlgyLinkedList.Contains(4));
            Console.WriteLine(sinlgyLinkedList.Contains(1));
            Console.WriteLine(sinlgyLinkedList.Contains(100));

        }

        public static void OperateOnStackArray()
        {
            var myStack = new StackArray<string>(10);

            myStack.Push("2");
            myStack.Push("5");
            myStack.Push("7");
            myStack.Push("12");
            myStack.Push("6");

            myStack.Print();

            Console.WriteLine(myStack.Search("6"));

            myStack.Pop();

            Console.WriteLine(myStack.Search("6"));

            myStack.Print();

            myStack.Clear();

            myStack.Print();
        }
    }
}
