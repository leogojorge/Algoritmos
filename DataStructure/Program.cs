namespace DataStructure
{
    internal class Program
    {
        static void Main(string[] args)
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
