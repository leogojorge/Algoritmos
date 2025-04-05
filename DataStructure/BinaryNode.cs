using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace DataStructure
{
    public class BinarySearchTree
    {
        public BinaryNode Root { get; set; }

        public int SumTree()
        {
            return SumTree(this.Root);
        }

        public int SumTree(BinaryNode node)
        {
            if (node is null) return 0;

            return node.Data + SumTree(node.Left) + SumTree(node.Right);
        }

        public BinaryNode Add(int data)
        {
            return Add(this.Root, data);
        }

        public BinaryNode Add(BinaryNode node, int data)
        {
            if (this.Root is null)
            {
                this.Root = new BinaryNode(data);
                Console.WriteLine("Adding Root" + data);   
                return this.Root;
            }

            if (node.Data > data)
            {
                if(node.Left is null)
                {
                    node.Left = new BinaryNode(data);
                    Console.WriteLine("Adding Left" + data);   
                    return node.Left;
                }
                else
                    this.Add(node.Left, data);
            }

            if (node.Data < data)
            {
                if (node.Right is null)
                {
                    node.Right = new BinaryNode(data);
                    Console.WriteLine("Adding Right" + data);   
                    return node.Right;
                }
                else
                    this.Add(node.Right, data);
            }

            return node;
        }

        public BinaryNode FindByDFSPreOrder(int data, BinaryNode? node = null)// Depth First Search
        {
            if (node is null) return null;

            Console.WriteLine("Visited: " + node.Data);

            if (node.Data == data) return node;

            BinaryNode leftResult = FindByDFSPreOrder(data, node.Left);

            if (leftResult is not null) return leftResult;

            BinaryNode rightResult = FindByDFSPreOrder(data, node.Right);

            return rightResult;
        }

    }

    public class BinaryNode
    {
        public int Data { get; set; }
        public BinaryNode? Left { get; set; }
        public BinaryNode? Right { get; set; }

        public BinaryNode(int data, BinaryNode left = null, BinaryNode rigth = null)
        {
            this.Data = data;
            this.Left = left;
            this.Right = rigth;
        }
    }
}
