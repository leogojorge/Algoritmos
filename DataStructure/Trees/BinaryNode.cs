using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Trees
{
    public class BinaryNode<T>
    {
        public T Data { get; set; }
        public int Heigth { get; set; } = 1;
        public BinaryNode<T>? Left { get; set; }
        public BinaryNode<T>? Right { get; set; }

        public BinaryNode(T data, BinaryNode<T> left = null, BinaryNode<T> rigth = null)
        {
            Data = data;
            Left = left;
            Right = rigth;
        }

        public List<BinaryNode<T>> GetChilds()
        {
            var childs = new List<BinaryNode<T>>();

            if (Left != null)
                childs.Add(Left);

            if (Right != null)
                childs.Add(Right);

            return childs;
        }
    }
}
