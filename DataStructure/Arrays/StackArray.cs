namespace DataStructure.Arrays
{
    public class StackArray<T>
    {
        public T[]? Array { get; }

        public int Top = -1;

        public StackArray(int size)
        {
            Array = new T[size];
        }

        public int Search(T value)
        {
            for (int i = 0; i <= Top; i++)
            {
                if (Array[i].Equals(value))
                    return i;
            }

            return -1;
        }

        public void Push(T value)
        {
            Array[Top + 1] = value;
            Top++;
        }

        public T Pop()
        {
            var result = Array[Top];
            Top--;

            return result;
        }

        public T Peek()
        {
            return Array[Top];
        }

        public int Size()
        {
            return Top - 1;
        }

        public bool IsEmpty()
        {
            return Top == -1;
        }

        public void Clear()
        {
            Top = -1;
        }

        public void Print()
        {
            Console.Write("[");

            for (int i = 0; i <= Top; i++)
            {
                Console.Write(Array[i] + ",");
            }

            Console.WriteLine("]");

        }
    }
}
