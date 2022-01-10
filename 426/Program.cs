var root = new Node(4, new Node(2, new Node(1), new Node(3)), new Node(5));

Node first = null;
Node last = null;

TreeToDoublyList(root);

void Work(Node node)
{
    if (node != null)
    {
        Work(node.left);

        if(first == null) first = node;
        
        if (last != null)
        {
            last.right = node;
            node.left = last;
        }

        last = node;
        
        Work(node.right);
    }
}

Node TreeToDoublyList(Node root)
{
    if (root == null) return null;

    Work(root);
    last.right = first;
    first.left = last;
    return first;
}

public class Node
{
    public int val;
    public Node left;
    public Node right;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
        left = null;
        right = null;
    }

    public Node(int _val, Node _left, Node _right)
    {
        val = _val;
        left = _left;
        right = _right;
    }
}