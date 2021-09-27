using homework_10.Task7;
using System;
using System.Collections.ObjectModel;

namespace homework_10.Task7
{
    public class Node<T>
    {
        // Private member-variables
        private T data;
        private NodeList<T> neighbors = null;

        public Node() { }
        public Node(T data) : this(data, null) { }
        public Node(T data, NodeList<T> neighbors)
        {
            this.data = data;
            this.neighbors = neighbors;
        }

        public T Value
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        protected NodeList<T> Neighbors
        {
            get
            {
                return neighbors;
            }
            set
            {
                neighbors = value;
            }
        }
    }

    public class NodeList<T> : Collection<Node<T>>
    {
        public NodeList() : base() { }

        public NodeList(int initialSize)
        {
            // Add the specified number of items
            for (int i = 0; i < initialSize; i++)
                base.Items.Add(default(Node<T>));
        }

        public Node<T> FindByValue(T value)
        {
            // search the list for the value
            foreach (Node<T> node in Items)
                if (node.Value.Equals(value))
                    return node;

            // if we reached here, we didn't find a matching node
            return null;
        }
    }

    public class BinaryTreeNode<T> : Node<T>
    {
        public BinaryTreeNode() : base() { }
        public BinaryTreeNode(T data) : base(data, null) { }
        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            base.Value = data;
            NodeList<T> children = new NodeList<T>(2);
            children[0] = left;
            children[1] = right;

            base.Neighbors = children;
        }

        public BinaryTreeNode<T> Left
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                else
                    return (BinaryTreeNode<T>)base.Neighbors[0];
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);

                base.Neighbors[0] = value;
            }
        }

        public BinaryTreeNode<T> Right
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                else
                    return (BinaryTreeNode<T>)base.Neighbors[1];
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);

                base.Neighbors[1] = value;
            }
        }

    }

    public class BinaryTree<T>
    {
        private BinaryTreeNode<T> root;

        public BinaryTree()
        {
            root = null;
        }

        public virtual void Clear()
        {
            root = null;
        }

        public BinaryTreeNode<T> Root
        {
            get
            {
                return root;
            }
            set
            {
                root = value;
            }
        }

        public void PreorderTraversal(BinaryTreeNode<T> current)
        {
            if (current != null)
            {
                // Output the value of the current node
                Console.WriteLine(current.Value);

                // Recursively print the left and right children
                PreorderTraversal(current.Left);
                PreorderTraversal(current.Right);
            }
        }

        public void InorderTraversal(BinaryTreeNode<T> current)
        {
            if (current != null)
            {
                // Visit the left child...
                InorderTraversal(current.Left);

                // Output the value of the current node
                Console.WriteLine(current.Value);

                // Visit the right child...
                InorderTraversal(current.Right);
            }
        }

        public virtual void Add(T data)
        {
            // create a new Node instance
            BinaryTreeNode<T> n = new BinaryTreeNode<T>(data);
            int result;

            // now, insert n into the tree
            // trace down the tree until we hit a NULL
            BinaryTreeNode<T> current = root, parent = null;
            while (current != null)
            {
                result = Compare(current.Value, data);
                if (result == 0)
                    // they are equal - attempting to enter a duplicate - do nothing
                    return;
                else if (result > 0)
                {
                    // current.Value > data, must add n to current's left subtree
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    // current.Value < data, must add n to current's right subtree
                    parent = current;
                    current = current.Right;
                }
            }

            // We're ready to add the node!
            if (parent == null)
                // the tree was empty, make n the root
                root = n;
            else
            {
                result = Compare(parent.Value, data);
                if (result > 0)
                    // parent.Value > data, therefore n must be added to the left subtree
                    parent.Left = n;
                else
                    // parent.Value < data, therefore n must be added to the right subtree
                    parent.Right = n;
            }
        }

        private int Compare(T value, T data)
        {
            throw new NotImplementedException();
        }
    }
}

