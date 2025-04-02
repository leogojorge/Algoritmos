using System.Text;

namespace DataStructure
{
    public class DoublyLinkedList<T>
    {
        public DoublyLinkedNode<T> Head;

        public void Add(T value)
        {
            var newNode = new DoublyLinkedNode<T>(value);

            if (this.Head == null)
            {
                this.Head = newNode;
                return;
            }

            var node = this.Head;

            do
            {
                if (node.Next is null)
                {
                    node.Next = newNode;
                    return;
                }

                node = node.Next;

            } while (node is not null);
        }

        public void AddFirst(T value)
        {
            var newNode = new DoublyLinkedNode<T>(value);
            newNode.Next = this.Head;

            this.Head.Previous = newNode;
            this.Head = newNode;
        }

        public void AddLast(T value)
        {
            var newNode = new DoublyLinkedNode<T>(value);
            if (this.Head == null) 
            {
                this.Head = newNode;
                return;
            };

            var node = this.Head;

            do
            {
                if(node.Next is null)
                {
                    node.Next = newNode;
                    return;
                }

                node = node.Next;
            }while(node is not null);
        }

        public void AddAfter(T value, DoublyLinkedNode<T> afterNode)
        {
            var newNode = new DoublyLinkedNode<T>(value);

            AddAfter(newNode, afterNode);
        }

        public void AddAfter(DoublyLinkedNode<T> newNode, DoublyLinkedNode<T> afterNode)
        {
            if (this.Head == null || afterNode is null) return;

            var node = this.Head;
            do
            {
                if (node == afterNode)
                {
                    newNode.Next = node.Next;
                    node.Next = newNode;
                    return;
                }

                node = node.Next;

            } while (node is not null);
        }

        public (DoublyLinkedNode<T> node, int index) Find(T value)
        {
            var node = this.Head;
            int count = 0;
            do
            {
                if (node.Value.Equals(value))
                {
                    return (node, count);
                }
                node = node.Next;

                count++;
            } while (node is not null);

            return (null, -1);
        }

        public bool Remove(T value)
        {
            if (this.Head is null) return false;

            var node = this.Head;

            do
            {
                if (node.Value.Equals(value))
                {
                    bool isFirstNode = node.Previous is null;
                    bool isLastNode = node.Next is null;

                    if (isFirstNode)
                    {
                        this.Head = node.Next;
                    }
                    else
                    {
                        node.Previous.Next = node.Next;
                    }

                    return true;
                }

                node = node.Next;
            } while (node is not null);

            return false;
        }

        public void CopyTo(T[] array, int arrayStartIndex)
        {
            var node = this.Head;
            int count = arrayStartIndex;
            while(node is not null)
            {
                array[count] = node.Value;
                count++;
                node = node.Next;
            }
        }

        public int Size()
        {
            if (this.Head is null) return 0;

            var node = this.Head;
            int count = 0;

            while (node is not null)
            {
                count++;
                node = node.Next;
            }

            return count;
        }

        public void Print()
        {
            var node = this.Head;

            var print = new StringBuilder();

            print.Append('[');

            while (node is not null)
            {
                print.Append(node.Value + ",");
                node = node.Next;
            }

            string result = print.ToString().Trim(',') + "]";

            Console.WriteLine(result);
        }
    }

    public class DoublyLinkedNode<T>
    {
        public T Value;

        public DoublyLinkedNode<T> Next;

        public DoublyLinkedNode<T> Previous;

        public DoublyLinkedNode(T value)
        {
            this.Value = value;
        }
    }
}