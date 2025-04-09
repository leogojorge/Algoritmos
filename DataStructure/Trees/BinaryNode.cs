using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Trees
{
    public class BinaryNode
    {
        public int Data { get; set; }
        public BinaryNode? Left { get; set; }
        public BinaryNode? Right { get; set; }

        public BinaryNode(int data, BinaryNode left = null, BinaryNode rigth = null)
        {
            Data = data;
            Left = left;
            Right = rigth;
        }

        public List<BinaryNode> GetChilds()
        {
            var childs = new List<BinaryNode>();

            if (Left != null)
                childs.Add(Left);

            if (Right != null)
                childs.Add(Right);

            return childs;
        }
    }
}
