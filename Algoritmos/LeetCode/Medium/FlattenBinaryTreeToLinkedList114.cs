using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algoritmos.LeetCode.Easy;

namespace Algoritmos.LeetCode.Medium
{
    public static class FlattenBinaryTreeToLinkedList114
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public static void Call()
        {
            var root = 
                new TreeNode(1, 
                    new TreeNode(2, new TreeNode(3),
                new TreeNode(4)),
                new TreeNode(5,
                    null, new TreeNode(6)));

            Flatten(root);
        }

        public static void Flatten(TreeNode root)
        {
            if(root is null) return;

            var queue = new Queue<TreeNode>();
            
            DFS(root, queue);

            var firstNode = queue.Dequeue();
            var tempNode = firstNode;

            while (queue.Count > 0)
            {
                tempNode.left = null;
                tempNode.right = queue.Dequeue();
                tempNode = tempNode.right;
            }

            root = firstNode;
        }

        public static void DFS(TreeNode node, Queue<TreeNode> queue)
        {
            if (node is null) return;

            queue.Enqueue(node);

            DFS(node.left, queue);
            DFS(node.right, queue);
        }
    }
}
