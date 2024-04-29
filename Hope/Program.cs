// See https://aka.ms/new-console-template for more information

using System;

class Node {
    public int id;
    private string name;
    public string Name {
        get {return name;}
        set {name = value;}
    }

    public Node() {
        name = "";
    }
}
