var p = new Node(5, new Node(3));
var q = new Node(4, new Node(2, new Node(5, new Node(3))));

var result = LowestCommonAncestor(p, q);

Console.WriteLine(result?.val);



Node LowestCommonAncestor(Node p, Node q)
{
    var pList = new List<int>() { p.val };
    var qList = new List<int>() { q.val };

    while (p != null || q != null)
    {
        if(p == q) return p;

        if(p != null)
            pList.Add(p.val);
        if(q != null)
            qList.Add(q.val);

        if(pList.Any(x => x == q?.val))
            return q;

        if (qList.Any(x => x == p?.val))
            return p;

        p = p?.parent;
        q = q?.parent;
    }

    return null;
}

// Definition for a Node.
public class Node
{
    public int val;
    public Node left;
    public Node right;
    public Node parent;

    public Node(int val, Node parent = null)
    {
        this.val = val;
        this.parent = parent;
    }
}
