using System.Data;
using System.Diagnostics.CodeAnalysis;
using DataStructure.Arrays;

namespace DataStructure.Trees
{
    public class BinarySearchTree //is not the same as a AVL tree. BST are not self balancing trees as AVLs.
    {
        public BinaryNode<int> Root { get; set; }

        public int SumTree()
        {
            return SumTree(Root);
        }

        public int SumTree(BinaryNode<int> node)
        {
            if (node is null) return 0;

            return node.Data + SumTree(node.Left) + SumTree(node.Right);
        }

        public BinaryNode<int> Add(int data)
        {
            return Add(Root, data);
        }

        public BinaryNode<int> Add(BinaryNode<int> node, int data)
        {
            if (Root is null)
            {
                Root = new BinaryNode<int>(data);
                Console.WriteLine("Adding Root" + data);
                return Root;
            }

            if (node is null)
            {
                return new BinaryNode<int>(data);
            }

            if (node.Data > data)
            {
                node.Left = Add(node.Left, data);
            }
            else
            {
                node.Right = Add(node.Right, data);
            }

            return node;
        }

        public BinaryNode<int> Remove(int data)
        {
            if (FindByDFSPreOrder(data) is null)
                return null;

            return Remove(Root, data);
        }

        public BinaryNode<int> Remove(BinaryNode<int> node, int data)
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

        private int FindClosestNumberBiggerThan(BinaryNode<int> node)
        {
            node = node.Right;
            while (node.Left is not null)
            {
                node = node.Left;
            }
            return node.Data;
        }

        private int FindClosestNumberSmallerThan(BinaryNode<int> node)
        {
            node = node.Left;
            while (node is not null)
            {
                node = node.Right;
            }
            return node.Data;
        }

        public BinaryNode<int> FindByDFSPreOrder(int data)
        {
            return FindByDeepthFirstSearch(data, Root);
        }

        public BinaryNode<int> FindByDeepthFirstSearch(int data, BinaryNode<int>? node)// Depth First Search
        {
            Console.WriteLine("Visited: " + node?.Data);

            if (node is null) return null;

            if (node.Data == data) return node;

            BinaryNode<int> leftResult = FindByDeepthFirstSearch(data, node?.Left);

            if (leftResult is not null) return leftResult;

            BinaryNode<int> rightResult = FindByDeepthFirstSearch(data, node?.Right);

            return rightResult;
        }

        public BinaryNode<int> FindByBreadthFirstSearch(int data)
        {
            return FindByBreadthFirstSearch(Root, data);
        }

        /// <summary>
        /// Breadth First Search -> best way to find the shortest path to a node
        /// BFS are most used on graphs, where a node has bidirectional relation with other nodes,
        /// in this implamantations we are using over a Tree, where a node can only see its childs,
        /// but not its parent node. the difference on implementations is that, with graphs,
        /// we can have multiple nodes pointing to the same other node, with it when we are
        /// enqueuing the next nodes to be visited, we will find this same node multiple times
        /// (the amount of times == amount of nodes pointing to it)
        /// to prevent that, we create an array of boolean to keep track
        /// of nodes that were already visited, so we do not visit them again.
        /// On Tree implementations this is not a problem, because only one
        /// node can point to another.
        /// Because of that difference, only graphs can have the 
        /// shortest way calculated (?)
        /// </summary>
        /// <param name="node">The node we want to start the search from</param>
        /// <param name="data"></param>
        /// <returns></returns>
        public BinaryNode<int> FindByBreadthFirstSearch(BinaryNode<int> node, int data)
        {
            if (node == null) return null;

            QueueArray<BinaryNode<int>> nodesToBeVisited = new QueueArray<BinaryNode<int>>(100); //tried to use my own StackImplamantation here, but stacks on BFS wont work as expected, because we need to access the first node added to the list of nodes of the same level, queues provide that for us, stacks will always retrieve the last node added, and that will jump a level further before visiting all the other nodes on the same level.
            nodesToBeVisited.Enqueue(Root);
            bool[] nodeWasVisited = new bool[100];
            nodeWasVisited[Root.Data] = true;

            while (nodesToBeVisited.Count() > 0)
            {
                var currentNode = nodesToBeVisited.Dequeue();

                if (currentNode.Data == data)
                    return currentNode;

                foreach (var childNode in currentNode.GetChilds())
                {
                    if (!nodeWasVisited[childNode.Data])
                    {
                        nodesToBeVisited.Enqueue(childNode);
                        nodeWasVisited[childNode.Data] = true;
                    }
                }
            }

            return null;
        }
    }
}
