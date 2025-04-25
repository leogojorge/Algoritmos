using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Trees
{
    public class AVLTree
    {
        public BinaryNode<int> Root { get; private set; }

        public void Add(int data)
        {
            if (this.Root is null)
            {
                this.Root = new BinaryNode<int>(data);
            }

            this.Add(Root, data);
        }
        private BinaryNode<int> Add(BinaryNode<int> node, int data)
        {
            if (node is null)
                return new BinaryNode<int>(data);

            if (data > this.Root.Data)
            {
                node.Right = this.Add(this.Root.Right, data);
            }
            if (data < this.Root.Data)
            {
                node.Left = this.Add(this.Root.Left, data);
            }
            else
            {
                return node;
            }

            return null;
            this.UpdateHeigth(node);
            //return this.ApplyRotation(node);
        }

        //private BinaryNode<int> ApplyRotation(BinaryNode<int> node)
        //{
        //    int balanceOfNode = this.GetNodeBalance(node);

        //    if (balanceOfNode > 1) //left heavy
        //    {
        //        if (this.GetNodeBalance(node.Left) < 0)//left rigth rotations are needed
        //        {
        //            node.Left = RotateLeft(node.Left);
        //        }
        //        return RotateRigth(node);
        //    }
        //    if (balanceOfNode < -1) //rigth heavy
        //    {
        //        if (this.GetNodeBalance(node.Right) > 0)//rigth left rotations are needed
        //        {
        //            node.Right = RotateRigth(node.Right);
        //        }

        //        return RotateLeft(node);
        //    }
        //}

        private BinaryNode<int> RotateLeft(BinaryNode<int> left)
        {
            throw new NotImplementedException();
        }

        private BinaryNode<int> RotateRigth(BinaryNode<int> node)
        {
            throw new NotImplementedException();
        }

        private int GetNodeBalance(BinaryNode<int> node)
        {
            var (leftHeigth, rigthHeigth) = this.GetLeftAndRightHeigth(node);

            int balanceOfNode = leftHeigth - rigthHeigth;
            return balanceOfNode;
        }

        private void UpdateHeigth(BinaryNode<int> node)
        {
            var (leftHeigth, rigthHeigth) = this.GetLeftAndRightHeigth(node);

            int maxHeigth = Math.Max(leftHeigth, rigthHeigth);

            node.Heigth += maxHeigth;
        }

        private (int leftHeigth, int rigthHeigth) GetLeftAndRightHeigth(BinaryNode<int> node)
        {
            int leftHeigth = node?.Left?.Heigth ?? 0;
            int rigthHeigth = node?.Right?.Heigth ?? 0;

            return (leftHeigth, rigthHeigth);
        }

        public void Remove(int data) { }

        public void Traverse() { }

        public bool IsEmpty()
        {
            return false;
        }
    }
}
