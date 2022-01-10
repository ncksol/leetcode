var p = new TreeNode(5);
var q = new TreeNode(4);
var root = new TreeNode(3) { left = new TreeNode(5) { left = new TreeNode(6), right = new TreeNode(2) { left = new TreeNode(7), right = new TreeNode(4) } }, right = new TreeNode(1) { left = new TreeNode(0), right = new TreeNode(8) } };


var result = LowestCommonAncestor(root, p, q);

Console.WriteLine(result?.val);



TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
{
    var pathToP = new List<TreeNode>();
    DFS(root, p.val, pathToP);

    var pathToQ = new List<TreeNode>();
    DFS(root, q.val, pathToQ);

    for (int i = pathToQ.Count-1; i >= 0; i--)
    {
        var node = pathToQ[i];
        if(pathToP.Any(x => x.val == node.val))
            return node;
    }

    return null;
}

bool DFS(TreeNode root, int target, List<TreeNode> path)
{
    if (root == null) return false;

    path.Add(root);

    if (root.val == target)
        return true;

    if(DFS(root.left, target, path) || DFS(root.right, target, path))
        return true;

    path.Remove(path.Last());
    return false;
}


public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}
