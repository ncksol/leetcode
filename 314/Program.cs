
TreeNode root = new TreeNode(3, new TreeNode(9, new TreeNode(4), new TreeNode(0, null, new TreeNode(2))), new TreeNode(8, new TreeNode(1, new TreeNode(5)), new TreeNode(7)));
root = new TreeNode(1);
root = new TreeNode(1, new TreeNode(2));
root = new TreeNode(1,
    new TreeNode(2,
        new TreeNode(4,
            null,
            new TreeNode(7, null, new TreeNode(10))),
        new TreeNode(5,
            new TreeNode(8, null, new TreeNode(11)),
            null)),
    new TreeNode(3,
        new TreeNode(6,
            null,
            new TreeNode(9,
                new TreeNode(10), null)),
        null));

var a = VerticalOrder(root);

Console.Write("[");
foreach (var item in a)
{
    Console.Write($"[{string.Join(',', item)}]");
}
Console.Write("]");

IList<IList<int>> VerticalOrder(TreeNode root)
{
    IList<IList<int>> answer = new List<IList<int>>();
    if (root == null)
        return answer;

    var result = Work(root);

    foreach (var key in result.OrderBy(x => x.Key).Select(x => x.Key))
    {
        answer.Add(result[key]);
    }

    return answer;
}

Dictionary<int, List<int>> Work(TreeNode node)
{
    var container = new Dictionary<int, List<int>>();
    var queue = new Queue<(TreeNode Node, int Column)>();

    queue.Enqueue((node, 0));

    while (queue.Any())
    {
        var size = queue.Count;
        for (int i = 0; i < size; i++)
        {
            var cur = queue.Dequeue();

            var column = cur.Column;

            if (container.ContainsKey(column))
                container[column].Add(cur.Node.val);
            else
                container.Add(column, new List<int> { cur.Node.val });

            if(cur.Node.left != null)
                queue.Enqueue((cur.Node.left, column-1));

            if (cur.Node.right != null)
                queue.Enqueue((cur.Node.right, column+1));
        }
    }

    return container;
}

class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}