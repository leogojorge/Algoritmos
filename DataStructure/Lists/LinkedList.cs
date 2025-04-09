using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructure.Lists
{
    public class SinglyLinkedList<T>
    {
        public LinkedNode<T>? Head;

        public LinkedNode<T>? Last;

        public int Size = 0;

        public void Add(T value)
        {
            var newNode = new LinkedNode<T>(value);

            if (Size == 0)
            {
                AddFirst(value);

                return;
            }

            var node = Head;

            do
            {
                if (node.Next is null)
                {
                    node.Next = newNode;
                    Last = newNode;
                    Size++;

                    return;
                }

                node = node.Next;

            } while (node is not null);
        }

        public bool Add(T value, int AtIndex)
        {
            var newNode = new LinkedNode<T>(value);
            var node = Head;

            for (int i = 0; i < AtIndex - 1; i++)
            {
                if (node is null)
                    return false;

                node = node.Next;
            }

            newNode.Next = node.Next;
            node.Next = newNode;
            Size++;

            return true;
        }

        public void AddFirstItem(T value)
        {
            Head = Last = new LinkedNode<T>(value);
            Size++;

            return;
        }

        public void AddFirst(T value)
        {
            Head = new LinkedNode<T>(value, Head);
            Size++;

            return;
        }

        public void AddLast(T value)
        {
            Last.Next = new LinkedNode<T>(value);
            Last = Last.Next;
            Size++;
        }

        private void SetLast(LinkedNode<T> lastNode)
        {
            Last = lastNode;
        }

        public bool Remove(T value)
        {
            var (previousNode, node, index) = Find(value);

            if (index == -1) return false;

            previousNode.Next = node.Next;

            if (node.Next is null)
                SetLast(previousNode);

            Size--;

            return false;
        }

        public bool RemoveFirst()
        {
            if (Head is null)
                return false;

            if (Head.Next is null)
            {
                Head = null;
            }
            else
            {
                Head = Head.Next;
            }

            Size--;
            return true;
        }

        public bool RemoveLast()
        {
            var node = Head;
            var previousNode = Head;

            do
            {
                if (node.Next is null)
                {
                    previousNode.Next = null;
                    Last = previousNode;

                    Size--;
                    return true;
                }

                previousNode = node;
                node = node.Next;

            } while (node is not null);

            return false;
        }

        public T FindLast()
        {
            return Last.Value;
        }

        public bool Contains(T value)
        {
            var (previousNode, node, index) = Find(value);

            if (index == -1) return false;

            return true;
        }

        public int GetSize()
        {
            return Size;
        }

        public (LinkedNode<T> previousNode, LinkedNode<T> result, int index) Find(T value, int endIndex = 0)
        {
            endIndex = endIndex == 0 ? Size : endIndex;

            var node = Head;
            var previousNode = Head;

            for (int i = 0; i < endIndex; i++)
            {
                if (node.Value.Equals(value))
                    return (previousNode, node, i);

                previousNode = node;
                node = node.Next;
            }

            return (null, null, -1);
        }

        public void Print()
        {
            var node = Head;

            var print = new StringBuilder();

            print.Append('[');

            do
            {
                print.Append(node.Value + ",");
                node = node.Next;

            } while (node is not null);

            print.Remove(print.Length - 1, 1);

            print.Append(']');

            Console.WriteLine(print);
        }
    }
}

public class LinkedNode<T>
{
    public T? Value { get; set; }

    public LinkedNode<T>? Next { get; set; }

    public LinkedNode(T value)
    {
        Value = value;
    }

    public LinkedNode(T value, LinkedNode<T> next)
    {
        Value = value;
        Next = next;
    }
}
