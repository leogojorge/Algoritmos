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
            return this.FindByDeepthFirstSearch(data, this.Root);
        }

        public BinarySearchNode FindByDeepthFirstSearch(int data, BinarySearchNode? node)// Depth First Search
        {
            Console.WriteLine("Visited: " + node?.Data);

            if (node is null) return null;

            if (node.Data == data) return node;

            BinarySearchNode leftResult = FindByDeepthFirstSearch(data, node?.Left);

            if (leftResult is not null) return leftResult;

            BinarySearchNode rightResult = FindByDeepthFirstSearch(data, node?.Right);

            return rightResult;
        }

        public BinarySearchNode FindByBreadthFirstSearch(int data)
        {
            return FindByBreadthFirstSearch(this.Root, data);
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
        public BinarySearchNode FindByBreadthFirstSearch(BinarySearchNode node, int data)
        {
            if (node == null) return null;

            Queue<BinarySearchNode> nodesToBeVisited = new Queue<BinarySearchNode>(); //tried to use my own StackImplamantation here, but stacks on BFS wont work as expected, because we need to access the first node added to the list of nodes of the same level, queues provide that for us, stacks will always retrieve the last node added, and that will jump a level further before visiting all the other nodes on the same level.
            nodesToBeVisited.Enqueue(this.Root);
            bool[] nodeWasVisited = new bool[100];
            nodeWasVisited[this.Root.Data] = true;

            while (nodesToBeVisited.Count > 0)
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

        public List<BinarySearchNode> GetChilds()
        {
            var childs = new List<BinarySearchNode>();

            if (Left != null)
                childs.Add(Left);

            if (Right != null)
                childs.Add(Right);

            return childs;
        }
    }
}
