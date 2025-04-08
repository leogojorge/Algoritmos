using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace DataStructure
{
    public class QueueArray<T>
    {
        public T[] Array {  get; private set; }
        public int Capacity {  get; private set; }
        private int EnqueuePointer { get; set; } = 0;
        public uint DequeuePointer { get; set; } = 0;

        public QueueArray() { }

        public void Enqueue(T data)
        {

        }

        public void Dequeue(T data)
        { }

        public T Peek()//This method allows you to view the element at the front of the queue without removing it.
        {
            return Array[EnqueuePointer];
        }

        public bool IsEmpty()
        {
            return false;
        }

        public int Count()
        {
            return 0; 
        }

        public int Contains(T data)
        {
            return 0;
        }
    }
}
