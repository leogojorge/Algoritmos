namespace DataStructure
{
    /// <summary>
    /// FIFO
    /// A circular queue implementation with a circular search method
    /// Choose to maintain the size while enqueue or dequeuing elements,
    /// so we can have the amount of elements equal to the length of the array.
    /// Rather then having the IsEmpty implementations by checking if the
    /// pointes head and tail (EnqueuePointer and DequeuePoint) are the same.
    /// </summary>
    /// <typeparam name="T">The type of the data to be stored</typeparam>
    public class QueueArray<T>
    {
        public T[] Array { get; private set; }
        private int Capacity { get; set; }
        private int EnqueuePointer { get; set; } = 0;
        private int DequeuePointer { get; set; } = 0;
        private int Size { get; set; } = 0;

        public QueueArray()
        {
            this.Array = new T[100];
        }

        public QueueArray(int capacity)
        {
            this.Capacity = capacity;
            this.Array = new T[this.Capacity];
        }

        public void Enqueue(T data)
        {
            if (this.IsFull())
            {
                Console.WriteLine("Queue is full. Can not enqueue any more elements");
                return;
            }

            if (EnqueuePointer == this.Array.Length)
                EnqueuePointer = 0;

            this.Array[EnqueuePointer] = data;
            EnqueuePointer++;
            this.Size++;
        }

        public T Dequeue()
        {
            if (this.IsEmpty())
                return default(T);

            if (DequeuePointer == this.Array.Length)
                DequeuePointer = 0;

            var data = this.Array[DequeuePointer];
            DequeuePointer++;
            this.Size--;
            return data;
        }

        public T Peek()//This method allows you to view the element at the front of the queue without removing it.
        {
            return Array[DequeuePointer];
        }

        private bool IsFull()
        {
            return this.Size == this.Array.Length - 1;
        }


        public bool IsEmpty()
        {
            return this.Size == 0; //or this.EnqueuePointer == this.DequeuePointer
        }

        public int Count()
        {
            return this.Size;
        }

        public bool Contains(T data)
        {
            if (IsEmpty()) return false;

            int startIndex = this.DequeuePointer;
            int endIndex = this.EnqueuePointer;

            for (int elementsSearched = 0; elementsSearched < Size; elementsSearched++)
            {
                if (this.Array[startIndex].Equals(data)) return true;

                if (startIndex == endIndex) return false;

                if (startIndex == this.Array.Length - 1)
                    startIndex = 0;

                startIndex++;
            }

            return false;
        }
    }
}
