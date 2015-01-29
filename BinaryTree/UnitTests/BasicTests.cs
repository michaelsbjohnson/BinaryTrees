using BinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void TestInstantiation_NonNullable()
        {
            BinaryTree<int> intTree = new BinaryTree<int>(0);

            // The binary tree should have instantiated successfully.
            Assert.IsNotNull(intTree);

            // ToString() outputs the content of each node using pre-order traversal.
            // The tree cannot be created without a root node, so it should have been inserted.
            string expected = "{0}";
            string actual = intTree.ToString();

            // The order of the nodes in the tree should match the expected order.
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInstantiation_Nullable()
        {
            BinaryTree<string> stringTree = new BinaryTree<string>("root");

            // The binary tree should have instantiated successfully.
            Assert.IsNotNull(stringTree);

            // ToString() outputs the content of each node using pre-order traversal.
            // The tree cannot be created without a root node, so it should have been inserted.
            string expected = "{root}";
            string actual = stringTree.ToString();

            // The order of the nodes in the tree should match the expected order.
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInsert_ReturnsNewNode_NonNullable()
        {
            BinaryTree<int> intTree = new BinaryTree<int>(5);

            // Inserting a value into the tree should succeed.
            object newNode = intTree.Insert(4);

            // A successful insert should not return null.
            Assert.IsNotNull(newNode);

            // Insert should return a BinaryTree<T> object.
            Assert.AreEqual(newNode.GetType(), typeof(BinaryTree<int>));

            // Insert should return an object of the same type as the tree itself.
            Assert.AreEqual(newNode.GetType(), intTree.GetType());
        }

        [TestMethod]
        public void TestInsert_ReturnsNewNode_Nullable()
        {
            BinaryTree<string> stringTree = new BinaryTree<string>("root");

            // Inserting a null value into a tree with nullable data should succeed.
            object newNode = stringTree.Insert(null);

            // A successful insert should not return null.
            Assert.IsNotNull(newNode);

            // Insert should return a BinaryTree<string> object.
            Assert.AreEqual(newNode.GetType(), typeof(BinaryTree<string>));

            // Insert should return an object of the same type as the tree itself.
            Assert.AreEqual(newNode.GetType(), stringTree.GetType());
        }

        [TestMethod]
        public void TestInsert_NewDataLessThanRoot()
        {
            string root = "m";
            BinaryTree<string> stringTree = new BinaryTree<string>(root);

            // Inserting a value less than the root should create a left child of the root.
            stringTree.Insert("a");

            // ToString() outputs the content of each node using pre-order traversal.
            // The null node "{}" should appear as the left-most leaf node in the tree.
            string expected = "{m, L: {a}}";
            string actual = stringTree.ToString();

            // The order of the nodes in the tree should match the expected order.
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInsert_NewDataEqualToRoot()
        {
            string root = "m";
            BinaryTree<string> stringTree = new BinaryTree<string>(root);

            // Inserting a value equal to the root should create a right child of the root.
            stringTree.Insert(root);

            // ToString() outputs the content of each node using pre-order traversal.
            // The null node "{}" should appear as the left-most leaf node in the tree.
            string expected = "{m, R: {m}}";
            string actual = stringTree.ToString();

            // The order of the nodes in the tree should match the expected order.
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInsert_NewDataGreaterThanRoot()
        {
            string root = "m";
            BinaryTree<string> stringTree = new BinaryTree<string>(root);

            // Inserting a value less than the root should create a left child of the root.
            stringTree.Insert("z");

            // ToString() outputs the content of each node using pre-order traversal.
            // The null node "{}" should appear as the left-most leaf node in the tree.
            string expected = "{m, R: {z}}";
            string actual = stringTree.ToString();

            // The order of the nodes in the tree should match the expected order.
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInsert_NewDataIsNull()
        {
            string root = "m";
            BinaryTree<string> stringTree = new BinaryTree<string>(root);

            stringTree.Insert("a");
            stringTree.Insert("z");

            // Inserting a null string into a tree of strings should succeed.
            stringTree.Insert(null);

            // ToString() outputs the content of each node using pre-order traversal.
            // Because null is less than any non-null value, the null node "{}" 
            // should appear as the left-most leaf node in the tree.
            string expected = "{m, L: {a, L: {}}, R: {z}}";
            string actual = stringTree.ToString();

            // The order of the nodes in the tree should match the expected order.
            Assert.AreEqual(expected, actual);
        }
    }
}
