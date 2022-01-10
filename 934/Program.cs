/*var grid = new int[][]
{
new int[] {0,1, 0},
new int[] {0,0, 0},
new int[] {0,0, 1},
};*//*
var grid = new int[][]
{
new int[] {0,1},
new int[] {1,0},
};*/
/*
var grid = new int[][]
{
new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0},
new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0},
new int[] {0, 0, 0, 0, 0, 0, 0, 0, 1},
new int[] {0, 0, 0, 0, 0, 0, 0, 1, 1},
new int[] {0, 0, 0, 0, 0, 0, 0, 1, 1},
new int[] {0, 0, 0, 0, 0, 0, 0, 0, 1},
new int[] {0, 1, 0, 0, 0, 0, 0, 0, 0},
new int[] {1, 1, 1, 0, 0, 0, 0, 0, 0},
new int[] {1, 1, 0, 0, 0, 0, 0, 0, 0}
};*/

var grid = new int[][]
{
new int[] {1,1,0,0,0},
new int[] {1,0,0,0,0},
new int[] {1,0,0,0,0},
new int[] {0,0,0,1,1},
new int[] {0,0,0,1,1},
};
/*
var grid = new int[][]
{
new int[] {1,1,1,1,1},
new int[] {1,0,0,0,1},
new int[] {1,0,1,0,1},
new int[] {1,0,0,0,1},
new int[] {1,1,1,1,1},
};*/



var answer = Solution(grid);

Console.WriteLine(answer);


List<(int X, int Y)> GetIsland(int[][] grid)
{
    var islandOne = new List<(int X, int Y)>();

    var firstIslandStart = (-1, -1);

    for (int i = 0; i < grid.Length; i++)
    {
        var ix = Array.IndexOf(grid[i], 1);
        if (ix != -1)
        {
            firstIslandStart = (i, ix);
            break;
        }
    }

    var toVisit = new Queue<(int X, int Y)>();
    toVisit.Enqueue(firstIslandStart);

    while (toVisit.Count > 0)
    {
        var c = toVisit.Dequeue();
        var cvalue = grid[c.X][c.Y];

        if (cvalue == 1 && islandOne.Contains((c)) == false)
        {
            islandOne.Add(c);
        }

        var nearby = new List<(int X, int Y)>
    {
        (c.X-1, c.Y),
        (c.X+1, c.Y),
        (c.X, c.Y-1),
        (c.X, c.Y+1),
    };

        nearby = nearby.Where(c => c.X >= 0 && c.X < grid.Length && c.Y >= 0 && c.Y < grid.Length)
                       .Where(c => grid[c.X][c.Y] == 1)
                       .Where(c => toVisit.Contains(c) == false && islandOne.Contains(c) == false)
                       .ToList();

        nearby.ForEach(x => toVisit.Enqueue(x));
    }

    return islandOne;
}

Queue<(int X, int Y)> GetBorder(int[][] grid)
{
    var border = new Queue<(int X, int Y)>();
    var visited = new HashSet<(int X, int Y)>();

    var firstIslandStart = (-1, -1);

    for (int i = 0; i < grid.Length; i++)
    {
        var ix = Array.IndexOf(grid[i], 1);
        if (ix != -1)
        {
            firstIslandStart = (i, ix);
            break;
        }
    }

    var toVisit = new Queue<(int X, int Y)>();
    toVisit.Enqueue(firstIslandStart);

    while (toVisit.Count > 0)
    {
        var c = toVisit.Dequeue();
        var cvalue = grid[c.X][c.Y];

        if (cvalue == 1 && visited.Contains((c)) == false && border.Contains(c) == false)
        {
            visited.Add(c);
        }

        var nearby = new List<(int X, int Y)>
    {
        (c.X-1, c.Y),
        (c.X+1, c.Y),
        (c.X, c.Y-1),
        (c.X, c.Y+1),
    };

        nearby = nearby.Where(c => c.X >= 0 && c.X < grid.Length && c.Y >= 0 && c.Y < grid.Length)
                       //.Where(c => grid[c.X][c.Y] == 0)
                       //.Where(c => toVisit.Contains(c) == false && border.Contains(c) == false)
                       .ToList();

        var nearbyZeros = nearby.Where(c => grid[c.X][c.Y] == 0)
                                .Where(c => border.Contains(c) == false).ToList();

        nearbyZeros.ForEach(x => border.Enqueue(x));

        var nearbyOnes = nearby.Where(c => grid[c.X][c.Y] == 1)
                               .Where(c => toVisit.Contains(c) == false && visited.Contains(c) == false).ToList();

        nearbyOnes.ForEach(x => toVisit.Enqueue(x));
    }

    return border;
}

int Solution(int[][] grid)
{
    var queue = GetBorder(grid);
    var firstIsland = GetIsland(grid);

    var visited = new HashSet<(int X, int Y)>();

    var answer = 0;

    while (queue.Count > 0)
    {
        var count = queue.Count;

        while(count > 0)
        {
            var node = queue.Dequeue();
            if (visited.Contains(node) || firstIsland.Contains(node))
            {
                count--;
                continue;
            }

            if (grid[node.X][node.Y] == 1 && firstIsland.Contains(node) == false)
            {
               //answer++;
                return answer;
            }

            visited.Add(node);

            var nearby = new List<(int X, int Y)>
            {
                (node.X-1, node.Y),
                (node.X+1, node.Y),
                (node.X, node.Y-1),
                (node.X, node.Y+1),
            };

            nearby = nearby.Where(c => c.X >= 0 && c.X < grid.Length && c.Y >= 0 && c.Y < grid.Length)
                           .Where(c => visited.Contains(c) == false)
                           .ToList();

            nearby.ForEach(x => queue.Enqueue(x));
            count--;
        }

        answer++;
    }

    return answer;

}

int Bfs(Queue<(int, int)> q, HashSet<(int, int)> v, int[][] g)
{
    int d = 0;
    while (q.Count > 0)
    {
        var count = q.Count;

        for (int a = 0; a < count; a++)
        {
            var cell = q.Dequeue();
            int i = cell.Item1;
            int j = cell.Item2;

            if (v.Contains((i, j)))
                continue;

            // return if another island is found
            if (g[i][j] == 1)
                return d;

            v.Add((i, j));

            CheckBoundsAndAdd(i + 1, j, q, v, g);
            CheckBoundsAndAdd(i - 1, j, q, v, g);
            CheckBoundsAndAdd(i, j + 1, q, v, g);
            CheckBoundsAndAdd(i, j - 1, q, v, g);
        }

        d++;
    }

    return 0;
}

void CheckBoundsAndAdd(int i, int j, Queue<(int, int)> q, HashSet<(int, int)> vh, int[][] g)
{
    if (i < 0 || i >= g.Length || j < 0 || j >= g[0].Length)
        return;

    if (vh != null && vh.Contains((i, j)))
        return;

    q.Enqueue((i, j));
}

int[][] GetMap((int X, int Y) start, (int X, int Y) finish, int[][] grid)
{
    var map = new int[grid.Length][];
    for (int i = 0; i < grid.Length; i++)
    {
        map[i] = new int[grid[i].Length];
    }

    map[start.Y][start.X] = 1;
    map[finish.Y][finish.X] = 9;

    return map;
}

int[][] RemoveFromMap(int[][] grid, List<(int X, int Y)> island)
{
    var map = new int[grid.Length][];
    for (int i = 0; i < grid.Length; i++)
    {
        map[i] = grid[i];
    }

    foreach (var coord in island)
    {
        map[coord.X][coord.Y] = 0;
    }

    return map;
}

class APlus
{

    public static int FindShortestPath((int X, int Y) a, (int X, int Y) b, int[][] map)
    {
        var start = new Node { X = a.X, Y = a.Y };
        var finish = new Node { X = b.X, Y = b.Y };

        var visited = new List<Node>();
        var available = new List<(Node Node, int Priority)>();
        available.Add((start, 0));

        var shortestPath = -1;

        while (available.Count > 0)
        {
            var nodeWithPriority = available.OrderBy(x => x.Priority).First();
            available.Remove(nodeWithPriority);
            var currentNode = nodeWithPriority.Node;

            if (currentNode.Coords == finish.Coords)
            {
                while (currentNode.Parent != null)
                {
                    shortestPath++;
                    currentNode = currentNode.Parent;
                }
                break;
            }

            visited.Add(currentNode);

            var newNodes = GetWalkableNodes(map, currentNode, finish);

            foreach (var newNode in newNodes)
            {
                if (visited.Contains(newNode)) continue;
                available.Add((newNode, newNode.CostDistance));
            }
        }

        return shortestPath;
    }

    static List<Node> GetWalkableNodes(int[][] map, Node currentNode, Node targetNode)
    {
        var possibleNodes = new List<Node>
    {
        new Node { X = currentNode.X-1, Y = currentNode.Y, Parent = currentNode, Cost = currentNode.Cost + 1},
        new Node { X = currentNode.X+1, Y = currentNode.Y, Parent = currentNode, Cost = currentNode.Cost + 1},
        new Node { X = currentNode.X, Y = currentNode.Y-1, Parent = currentNode, Cost = currentNode.Cost + 1},
        new Node { X = currentNode.X, Y = currentNode.Y+1, Parent = currentNode, Cost = currentNode.Cost + 1},
    };

        possibleNodes.ForEach(node => node.SetDistance(targetNode.X, targetNode.Y));

        var maxX = map.Length;
        var maxY = map[0].Length;

        return possibleNodes.Where(node => node.X >= 0 && node.X < maxX)
                            .Where(node => node.Y >= 0 && node.Y < maxY)
                            .Where(node => map[node.Y][node.X] == 0 || map[node.Y][node.X] == 9)
                            .ToList();
    }

    class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public (int X, int Y) Coords => (X, Y);
        public int Cost { get; set; }
        public int Distance { get; private set; }
        public int CostDistance => Cost + Distance;
        public Node? Parent { get; set; }
        public void SetDistance(int targetX, int targetY)
        {
            Distance = Math.Abs(targetX - X) + Math.Abs(targetY - Y);
        }
    }
}