namespace DataStructure
{
    public class StackArray<T>
    {
        public T[]? Array { get; }

        public int Top = -1;

        public StackArray(int size)
        {
            this.Array = new T[size];
        }

        public int Search(T value)
        {
            for (int i = 0; i <= Top; i++)
            {
                if (this.Array[i].Equals(value))
                    return i;
            }

            return -1;
        }

        public void Push(T value)
        {
            this.Array[Top + 1] = value;
            Top++;
        }

        public T Pop()
        {
            var result = this.Array[Top];
            Top--;

            return result;
        }

        public T Peek()
        {
            return this.Array[Top];
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
                Console.Write(this.Array[i] + ",");
            }

            Console.WriteLine("]");

        }
    }
}
