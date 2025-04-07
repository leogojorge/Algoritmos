using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace DataStructure
{
    public class BinarySearchTree //is not the same as a AVL tree. BST are not self balancing trees as AVLs.
    {
        public BinarySearchNode Root { get; set; }

        public int SumTree()
        {
            return SumTree(this.Root);
        }

        public int SumTree(BinarySearchNode node)
        {
            if (node is null) return 0;

            return node.Data + SumTree(node.Left) + SumTree(node.Right);
        }

        public BinarySearchNode Add(int data)
        {
            return Add(this.Root, data);
        }

        public BinarySearchNode Add(BinarySearchNode node, int data)
        {
            if (this.Root is null)
            {
                this.Root = new BinarySearchNode(data);
                Console.WriteLine("Adding Root" + data);
                return this.Root;
            }

            if (node is null)
            {
                return new BinarySearchNode(data);
            }

            if (node.Data > data)
            {
                node.Left = this.Add(node.Left, data);
            }
            else
            {
                node.Right = this.Add(node.Right, data);
            }

            return node;
        }

        public BinarySearchNode Remove(int data)
        {
            if (FindByDFSPreOrder(data) is null)
                return null;

            return Remove(this.Root, data);
        }

        public BinarySearchNode Remove(BinarySearchNode node, int data)
        {
            if (node is null) return null;

            if (node.Data > data)
                node.Left = Remove(node.Left, data);
            else if (node.Data < data)
            {
                node.Right = Remove(node.Right, data);
            }
            else //node found
            {
                bool isALeaf = node.Right is null && node.Left is null;
                if (isALeaf)
                {
                    node = null;
                }
                else if (node.Right is not null) //we need to find a number to take place of the removed node
                {
                    node.Data = FindClosestNumberBiggerThan(node);
                    node.Right = Remove(node.Right, node.Data);
                }
                else
                {
                    node.Data = FindClosestNumberSmallerThan(node);
                    node.Left = Remove(node.Left, node.Data);
                }
            }

            return node;
        }

        private int FindClosestNumberBiggerThan(BinarySearchNode node)
        {
            node = node.Right;
            while (node.Left is not null)
            {
                node = node.Left;
            }
            return node.Data;
        }

        private int FindClosestNumberSmallerThan(BinarySearchNode node)
        {
            node = node.Left;
            while (node is not null)
            {
                node = node.Right;
            }
            return node.Data;
        }

        public BinarySearchNode FindByDFSPreOrder(int data)
        {
            return this.FindByDFSPreOrder(data, this.Root);
        }

        public BinarySearchNode FindByDFSPreOrder(int data, BinarySearchNode? node)// Depth First Search
        {
            Console.WriteLine("Visited: " + node?.Data);

            if (node is null) return null;

            if (node.Data == data) return node;

            BinarySearchNode leftResult = FindByDFSPreOrder(data, node?.Left);

            if (leftResult is not null) return leftResult;

            BinarySearchNode rightResult = FindByDFSPreOrder(data, node?.Right);

            return rightResult;
        }

    }

    public class BinarySearchNode
    {
        public int Data { get; set; }
        public BinarySearchNode? Left { get; set; }
        public BinarySearchNode? Right { get; set; }

        public BinarySearchNode(int data, BinarySearchNode left = null, BinarySearchNode rigth = null)
        {
            this.Data = data;
            this.Left = left;
            this.Right = rigth;
        }
    }
}
