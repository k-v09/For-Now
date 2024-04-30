using System;
using System.Collections.Generic;


public class TreeNode<T> {
    public T Value { get; set; }
    public TreeNode<T>? Left { get; set; }
    public TreeNode<T>? Right { get; set; }
    public TreeNode<T>? Parent { get; set; }

    public TreeNode(T value) {
        Value = value;
        Left = null;
        Right = null;
        Parent = null;
    }
}

public class BinaryTree<T> {
    public TreeNode<T>? Root { get; private set; }

    public BinaryTree() {
        Root = null;
    }

    public void Insert(T value) {
        Root = InsertRec(Root, value);
    }

    private TreeNode<T> InsertRec(TreeNode<T> node, T value) {
        if (node == null) {
            node = new TreeNode<T>(value);
        }
        else if (Comparer<T>.Default.Compare(value, node.Value) < 0) {
            node.Left = InsertRec(node.Left, value);
        }
        else if (Comparer<T>.Default.Compare(value, node.Value) > 0) {
            node.Right = InsertRec(node.Right, value);
        }

        return node;
    }

    public void Print() {
        PrintTree(Root, 0);
    }

    private void PrintTree(TreeNode<T> node, int depth) {
        if (node == null)
            return;

        PrintTree(node.Right, depth + 1);

        Console.WriteLine($"{new string(' ', depth * 3)}{node.Value}");

        PrintTree(node.Left, depth + 1);
    }
}


/*

11 12 13 14
   22 23 24
      33 34
         44

11 12 13 14 15 16
   22 23 24 25 26
      33 34 35 36
         44 45 46
            55 56
               66

f(x) = sum(1->x): x

*/

class Program {
    static void Main() {
        BinaryTree<int> tree = new BinaryTree<int>();

        tree.Insert(5);
        tree.Insert(3);
        tree.Insert(7);
        tree.Insert(1);
        tree.Insert(9);
        tree.Insert(6);
        tree.Insert(10);
        tree.Insert(5);
        tree.Insert(3);
        tree.Insert(7);
        tree.Insert(1);
        tree.Insert(9);
        tree.Insert(6);
        tree.Insert(10);
        
        Console.WriteLine("Binary Tree:");
        tree.Print();
    }
}



