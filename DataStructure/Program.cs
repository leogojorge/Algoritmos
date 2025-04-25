using DataStructure.Arrays;
using DataStructure.Lists;
using DataStructure.Trees;

namespace DataStructure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OperateOnQueueArray();
            //OperateOnBinaryTree();
            //OperateOnHashTable();
            //OperateOnDoublyLinkedList();
            //OperateOnSinlgyLinkedList();
            //OperateOnStackArray();
        }

        private static void OperateOnQueueArray()
        {
            var queue = new QueueArray<int>(10);
            queue.Enqueue(1); queue.Dequeue();
            queue.Enqueue(2); queue.Dequeue();
            queue.Enqueue(3); queue.Dequeue();
            queue.Enqueue(4); queue.Dequeue();
            queue.Enqueue(5); queue.Dequeue();
            queue.Enqueue(6);
            queue.Enqueue(7);
            queue.Enqueue(8);
            queue.Enqueue(9);
            queue.Enqueue(10);
            queue.Enqueue(11);
            var contais2 = queue.Contains(2);
            var contais6 = queue.Contains(6);
            var dq1 = queue.Dequeue();
            var stillContais6 = queue.Contains(6);
            queue.Enqueue(1);
            var dq2 = queue.Dequeue();
            var count = queue.Count();
            var isEmpty = queue.IsEmpty();
            var peek = queue.Peek();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
        }

        private static void OperateOnBinaryTree()
        {
            BinarySearchTree tree = new BinarySearchTree();

            tree.Add(1);
            tree.Add(5);
            tree.Add(10);
            tree.Add(3);
            tree.Add(4);

            var result = tree.SumTree();
            Console.WriteLine(result);

            var searchedNode = tree.FindByDFSPreOrder(4);

            var searchedNodeWithBFS = tree.FindByBreadthFirstSearch(4);

            Console.WriteLine("Node searched with DFS: " + searchedNode?.Data);
            Console.WriteLine("Node searched with BFS: " + searchedNodeWithBFS?.Data);

            var removedNode = tree.Remove(3);

            Console.WriteLine("Node removed: " + removedNode.Data);

            var removedNode2 = tree.Remove(1);

        }

        private static void OperateOnHashTable()
        {
            int hashTableCapacity = 100;
            var hashTable = new HashTable(hashTableCapacity);

            for (int i = 0; i < hashTableCapacity; i++)
            {
                string word = WordFinder2(i);
                hashTable.Add(word);
            }

            hashTable.Add("ana");
            hashTable.Add("leo");
            hashTable.Add("fat");
            hashTable.Add("cel");
            hashTable.Add("ade");
            hashTable.Add("car");
            hashTable.Add("nic");
            hashTable.Add("bre");
            hashTable.Add("zzz");

            hashTable.Print();

            Console.WriteLine("Buckets Filled: " + hashTable.BucketsFilled);
            Console.WriteLine("Collision Count: " + hashTable.CollisionCount);
        }

        private static void OperateOnDoublyLinkedList()
        {
            var doublyLinkedList = new DoublyLinkedList<int>();

            doublyLinkedList.Add(3);
            doublyLinkedList.Add(1);
            doublyLinkedList.Add(4);
            doublyLinkedList.Add(8);

            doublyLinkedList.Print();

            Console.WriteLine(doublyLinkedList.Find(3));
            Console.WriteLine(doublyLinkedList.Find(1));
            Console.WriteLine(doublyLinkedList.Find(4));
            Console.WriteLine(doublyLinkedList.Find(8));
            Console.WriteLine(doublyLinkedList.Find(0));

            Console.WriteLine(doublyLinkedList.Remove(3));
            Console.WriteLine(doublyLinkedList.Remove(1));
            Console.WriteLine(doublyLinkedList.Remove(4));
            Console.WriteLine(doublyLinkedList.Remove(8));
            Console.WriteLine(doublyLinkedList.Remove(0));

            doublyLinkedList.Print();

            Console.WriteLine(doublyLinkedList.Size());

            doublyLinkedList.Add(44);
            doublyLinkedList.Add(12);
            doublyLinkedList.Add(52);
            doublyLinkedList.Add(6);
            doublyLinkedList.Add(91);

            doublyLinkedList.Print();

            Console.WriteLine(doublyLinkedList.Size());

            var (node44, index) = doublyLinkedList.Find(44);

            var newNode43 = new DoublyLinkedNode<int>(43);

            doublyLinkedList.AddAfter(newNode43, node44);

            doublyLinkedList.Print();

            doublyLinkedList.AddAfter(42, newNode43);

            doublyLinkedList.Print();

            doublyLinkedList.AddFirst(45);

            doublyLinkedList.Print();

            doublyLinkedList.AddFirst(46);

            doublyLinkedList.Print();

            doublyLinkedList.AddLast(92);

            doublyLinkedList.Print();

            doublyLinkedList.AddLast(93);

            doublyLinkedList.Print();
            Console.WriteLine(doublyLinkedList.Size());

            var intArray = new int[50];
            doublyLinkedList.CopyTo(intArray, 10);

            Console.WriteLine("New array");

            for (int i = 0; i < intArray.Length; i++)
            {
                Console.Write(intArray[i] + ",");
            }

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

        public static string WordFinder2(int requestedLength)
        {
            Random rnd = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z" };
            string[] vowels = { "a", "e", "i", "o", "u" };

            string word = "";

            if (requestedLength == 1)
            {
                word = GetRandomLetter(rnd, vowels);
            }
            else
            {
                for (int i = 0; i < requestedLength; i += 2)
                {
                    word += GetRandomLetter(rnd, consonants) + GetRandomLetter(rnd, vowels);
                }

                word = word.Replace("q", "qu").Substring(0, requestedLength); // We may generate a string longer than requested length, but it doesn't matter if cut off the excess.
            }

            return word;
        }

        private static string GetRandomLetter(Random rnd, string[] letters)
        {
            return letters[rnd.Next(0, letters.Length - 1)];
        }
    }
}
