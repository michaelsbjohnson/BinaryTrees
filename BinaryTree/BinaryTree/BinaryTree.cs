using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class BinaryTree<T> where T : IComparable
    {
        public BinaryTree<T> Left = null;
        public BinaryTree<T> Right = null;
        public T Data;

        public BinaryTree(T newData)
        {
            Data = newData;
        }

        /// <summary>
        /// Use recursive pre-order traversal to display each binary tree node and its children.
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}", this.Data);
            if (this.Left != null)
            {
                sb.AppendFormat(", L: {0}", this.Left);
            }
            if (this.Right != null)
            {
                sb.AppendFormat(", R: {0}", this.Right);
            }
            string output = String.Format("{0}{1}{2}", "{", sb.ToString(), "}");
            return output;
        }

        /// <summary>
        /// Returns the height of the tree, defined as the count of nodes
        /// from the root to the deepest leaf node.
        /// </summary>
        /// <returns>The count of nodes from the given root to the deepest leaf node</returns>
        public int Height
        {
            get
            {
                return BinaryTree<T>.Height_Helper(this);
            }
        }

        /// <summary>
        /// This helper method carries out the height measurement recursively.
        /// </summary>
        /// <param name="root">The root of the (sub)tree to measure the height of</param>
        /// <returns>The count of nodes from the given root to the deepest leaf node</returns>
        private static int Height_Helper(BinaryTree<T> root)
        {
            if (root == null) return 0;
            // The height of this node is one greater than the height of 
            // its tallest child.
            int height = 1 + Math.Max(
                Height_Helper(root.Left),
                Height_Helper(root.Right));
            return height;
        }

        /// <summary>
        /// A binary tree is defined as balanced if the height of its left 
        /// and right children differ by no more than one.
        /// </summary>
        /// <returns>True if balanced, false otherwise</returns>
        public bool IsBalanced
        {
            get
            {
                int heightLeft = (this.Left == null) ? 0 : this.Left.Height;
                int heightRight = (this.Right == null) ? 0 : this.Right.Height;
                bool isBalanced = Math.Abs(heightLeft - heightRight) <= 1;
                return isBalanced;
            }
        }

        /// <summary>
        /// Inserts a node into the binary (search) tree in sorted order.
        /// No attempt is made to balance the tree.
        /// </summary>
        /// <param name="newData">The data to store in the binary search tree; must not be null</param>
        /// <returns>The new tree node that was created</returns>
        public BinaryTree<T> Insert(T newData)
        {
            if (null == newData || newData.CompareTo(this.Data) < 0)
            {
                if (this.Left == null)
                {
                    BinaryTree<T> newNode = new BinaryTree<T>(newData);
                    this.Left = newNode;
                    return newNode;
                }
                else
                {
                    return this.Left.Insert(newData);
                }
            }
            else
            {
                if (this.Right == null)
                {
                    BinaryTree<T> newNode = new BinaryTree<T>(newData);
                    this.Right = newNode;
                    return newNode;
                }
                else
                {
                    return this.Right.Insert(newData);
                }
            }
        }

        public delegate void ProcessData(T data);

        public void InOrderRecursive(ProcessData processData)
        {
            if (this.Left != null) this.Left.InOrderRecursive(processData);
            processData(this.Data);
            if (this.Right != null) this.Right.InOrderRecursive(processData);
        }

        public void InOrderIterative(ProcessData processData)
        {
            Stack<BinaryTree<T>> stack = new Stack<BinaryTree<T>>();
            BinaryTree<T> root = this;
            while (stack.Count > 0 || root != null)
            {
                if (root != null)
                {
                    stack.Push(root);
                    root = root.Left;
                }
                else
                {
                    root = stack.Pop();
                    processData(root.Data);
                    root = root.Right;
                }
            }
        }
    }
}
