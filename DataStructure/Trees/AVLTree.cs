using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Trees
{
    public class AVLTree<T>
    {
        public BinaryNode<T> Root { get; private set; }

        public AVLTree<T> Add(T data)
        {
            if (Root is null)
                this.Root = new BinaryNode<T>(data);
            
            return this;
        }

        public void Remove(T data) { }

        public void Traverse() { }

        public bool IsEmpty()
        {
            return false;
        }
    }
}
