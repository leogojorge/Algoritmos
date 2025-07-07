using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.LeetCode
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
    public static class BinaryTreeLevelOrderTraversal102
    {
        public static void Call()
        {
            var node = new TreeNode(1);
            node.left = new TreeNode(2);
            node.right = new TreeNode(3);
            node.left.left = new TreeNode(4);
            node.left.right = null;

            node.right.left = null;
            node.right.right = new TreeNode(5);

            var result = LevelOrder(node);
        }

        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            if (root is null) return new List<IList<int>>();

            var result = new List<IList<int>> { new List<int> { root.val } };

            var queue = new Queue<TreeNode>();

            queue.Enqueue(root); //coloca o raiz na fila para conseguir começar o while

            while (queue.Count > 0)
            {
                int levelSize = queue.Count; //na primeira iteração, só terá o root, então o tamanho do level é . Count == 1, na segunda iteração, terá o root e os dois filhos, então o tamanho do level é .Count == 3, e assim por diante.
                var nodesOnSameLevel = new List<int>(); //salva os nós no mesmo nível, para depois adicionar na lista de resultados.

                for (int i = 0; i < levelSize; i++) //esvazio a fila até chegar no ultimo nó desse nível, por isso salvamos o levelSize, para não ficar pegando o Count da fila dentro do for, que iria mudar a cada iteração.
                {
                    var currentNode = queue.Dequeue();
                    nodesOnSameLevel.Add(currentNode.val);

                    if (currentNode.left is not null)
                        queue.Enqueue(currentNode.left);

                    if (currentNode.right is not null)
                        queue.Enqueue(currentNode.right);
                }

                result.Add(nodesOnSameLevel);
            }

            return result;
        }
    }
}
