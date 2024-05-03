using System;
using System.Collections.Generic;

public class stupid{
    public static string GetInp(bool position, string intern) {
        string value;
        if (position) {
            value = "first";
        }
        else {
            value = "second";
        }
        Console.WriteLine($"What is the {value} component of {intern}?");
        string? v = Console.ReadLine();
        while (v == null) {
            Console.WriteLine("Invalid Input\nCannot be type null");
            v = Console.ReadLine();
        }
        return v;
    }
}
public class TreeNode {
    public string Value {get; set;}
    public TreeNode? Left {get; set;}
    public TreeNode? Right {get; set;}
    public TreeNode? Parent {get; set;}

    public TreeNode(string value) {
        Value = value;
        Left = null;
        Right = null;
        Parent = null;
    }
}

public class BinaryTree {

    private string[] basics = {"fire", "water", "earth", "wind"};
    public TreeNode? Root {get; private set;}

    public BinaryTree() {
        Root = null;
    }

    public void Insert(string value) {
        Root = InsertRoot(value);
    }

    private TreeNode InsertRoot(string value) {
        TreeNode r = new TreeNode(value);
        string val = stupid.GetInp(true, value);
        r.Left = InsertRecL(r.Left, val);
        string sval = stupid.GetInp(false, value);
        r.Right = InsertRecR(r.Right, sval);
        return r;
    }


    private TreeNode InsertRecL(TreeNode node, string value) {
        node ??= new TreeNode(value);
        bool valIn = false;
        foreach (string el in basics) {
            if (el == value) {
                valIn = true;
            }
        }
        if (valIn) {
            string t = stupid.GetInp(true, value);
            InsertRecL(node.Left, t);
            string y = stupid.GetInp(false, value);
            InsertRecR(node.Right, y);
        }

        return node;
    }

    private TreeNode InsertRecR(TreeNode node, string value) {
        node ??= new TreeNode(value);
        bool valIn = false;
        foreach (string el in basics) {
            if (el == value) {
                valIn = true;
            }
        }
        if (valIn) {
            string t = stupid.GetInp(true, value);
            InsertRecL(node.Left, t);
            string y = stupid.GetInp(false, value);
            InsertRecR(node.Right, y);
        }

        return node;
    }

    public void Print() {
        PrintTree(Root, 0);
    }

    private void PrintTree(TreeNode node, int depth) {
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
        BinaryTree tree = new BinaryTree();

        tree.Insert("");
        
        Console.WriteLine("Binary Tree:");
        tree.Print();
    }
}



