// See https://aka.ms/new-console-template for more information

using System;

namespace Nature {
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T>? Left { get; set; }
        public Node<T>? Right { get; set; }

        public Node(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }


    public class BinaryTree<T>
    {
        public Node<T>? Root { get; private set; }

        public BinaryTree()
        {
            Root = null;
        }

        public void Insert(T value)
        {
            Root = InsertRec(Root, value);
        }

        private Node<T> InsertRec(Node<T> node, T value)
        {
            if (node == null)
            {
                node = new Node<T>(value);
            }
            else if (Comparer<T>.Default.Compare(value, node.Value) < 0)
            {
                node.Left = InsertRec(node.Left, value);
            }
            else if (Comparer<T>.Default.Compare(value, node.Value) > 0)
            {
                node.Right = InsertRec(node.Right, value);
            }

            return node;
        }

        public void TraverseInOrder(Action<T> action)
        {
            TraverseInOrderRec(Root, action);
        }

        private void TraverseInOrderRec(Node<T> node, Action<T> action)
        {
            if (node != null)
            {
                TraverseInOrderRec(node.Left, action);
                action(node.Value);
                TraverseInOrderRec(node.Right, action);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(1);
            tree.Insert(9);

            Console.WriteLine("In-order traversal:");
            tree.TraverseInOrder(value => Console.WriteLine(value));
        }
    }
}