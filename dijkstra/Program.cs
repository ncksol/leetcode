
var grid = new int[][]
{
new int[] {1,0,0,0,0},
new int[] {0,0,0,0,0},
new int[] {0,0,0,0,0},
new int[] {0,0,0,0,0},
new int[] {0,0,0,0,9},

};

Print(grid);
var dest = FindDestination(grid);

var start = new Node { X = 0, Y = 0 };
var finish = new Node { X = dest.X, Y = dest.Y };

var visited = new List<Node>();
var available = new PriorityQueue<Node, int>();
available.Enqueue(start, 0);

var map = grid;
var shortestPath = 0;




while (available.TryDequeue(out var currentNode, out _))
{
    if(visited.Contains(currentNode)) continue;
    var newNodes = GetWalkableNodes(map, currentNode, finish);
    foreach (var newNode in newNodes)
    {
        if (visited.Contains(newNode)) continue;
        available.Enqueue(newNode, newNode.CostDistance);
    }

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

    
}

Console.WriteLine($"Shortest path: {shortestPath}");

void Print(int[][] grid)
{
    for (int i = 0; i < grid.Length; i++)
    {
        Console.WriteLine(String.Join(null, grid[i]));
    }
}

List<Node> GetWalkableNodes(int[][] map, Node currentNode, Node targetNode)
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

(int X, int Y) FindDestination(int[][] map)
{
    for (int i = 0; i < map.Length; i++)
    {
        var index = Array.IndexOf(map[i], 9);
        if (index != -1)
            return (index, i);
    }

    return (-1, -1);
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