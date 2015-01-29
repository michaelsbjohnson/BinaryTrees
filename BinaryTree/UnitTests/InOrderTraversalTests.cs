using BinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class InOrderTraversalTests
    {
        public StringBuilder _stringBuilder = new StringBuilder();

        public void AppendToStringBuilder(int data)
        {
            this._stringBuilder.AppendFormat("{0}, ", data.ToString());
        }

        [TestMethod]
        public void TestInOrderRecursive()
        {
            // Create a balanced binary tree: 2, 1, 3.
            BinaryTree<int> intTree = new BinaryTree<int>(2);
            intTree.Insert(1);
            intTree.Insert(3);

            // Traverse the tree in order.
            this._stringBuilder.Clear();
            intTree.InOrderRecursive(AppendToStringBuilder);

            // Check the resulting string.
            string expected = "1, 2, 3, ";
            string actual = this._stringBuilder.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInOrderRecursive_MinimumTree()
        {
            // Create the minimum binary tree: root only.
            BinaryTree<int> intTree = new BinaryTree<int>(2);

            // Traverse the tree in order.
            this._stringBuilder.Clear();
            intTree.InOrderRecursive(AppendToStringBuilder);

            // Check the resulting string.
            string expected = "2, ";
            string actual = this._stringBuilder.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInOrderRecursive_DeepTree()
        {
            // Create a lop-sided binary tree: 1, 2, 3, ...
            BinaryTree<int> intTree = new BinaryTree<int>(1);
            string expected = "1, ";
            for (int i = 2; i < 512;  ++i)
            {
                intTree.Insert(i);
                expected += string.Format("{0}, ", i);
            }

            // Traverse the tree in order.
            this._stringBuilder.Clear();
            intTree.InOrderRecursive(AppendToStringBuilder);

            // Check the resulting string.
            string actual = this._stringBuilder.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInOrderIterative()
        {
            // Create an imbalanced binary tree: 1, 2, 3.
            BinaryTree<int> intTree = new BinaryTree<int>(1);
            intTree.Insert(2);
            intTree.Insert(3);

            // Traverse the tree in order.
            this._stringBuilder.Clear();
            intTree.InOrderIterative(AppendToStringBuilder);

            // Check the resulting string.
            string expected = "1, 2, 3, ";
            string actual = this._stringBuilder.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInOrderIterative_MinimumTree()
        {
            // Create an imbalanced binary tree: root only.
            BinaryTree<int> intTree = new BinaryTree<int>(1);

            // Traverse the tree in order.
            this._stringBuilder.Clear();
            intTree.InOrderIterative(AppendToStringBuilder);

            // Check the resulting string.
            string expected = "1, ";
            string actual = this._stringBuilder.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInOrderIterative_DeepTree()
        {
            // Create a lop-sided binary tree: 1, 2, 3, ...
            BinaryTree<int> intTree = new BinaryTree<int>(1);
            string expected = "1, ";
            for (int i = 2; i < 512; ++i)
            {
                intTree.Insert(i);
                expected += string.Format("{0}, ", i);
            }

            // Traverse the tree in order.
            this._stringBuilder.Clear();
            intTree.InOrderIterative(AppendToStringBuilder);

            // Check the resulting string.
            string actual = this._stringBuilder.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInOrderRecursiveAndIterativeAreTheSame()
        {
            // Create an imbalanced binary tree: 2, 1, 6, 5, 3, 4.
            BinaryTree<int> intTree = new BinaryTree<int>(2);
            intTree.Insert(1);
            intTree.Insert(6);
            intTree.Insert(5);
            intTree.Insert(3);
            intTree.Insert(4);

            // Traverse the tree in order iteratively.
            this._stringBuilder.Clear();
            intTree.InOrderIterative(AppendToStringBuilder);
            string iterative = this._stringBuilder.ToString();

            // Traverse the tree in order recursively.
            this._stringBuilder.Clear();
            intTree.InOrderRecursive(AppendToStringBuilder);
            string recursive = this._stringBuilder.ToString();

            // Check that both algorithms produce the same result.
            Assert.AreEqual(iterative, recursive);
        }
    }
}
