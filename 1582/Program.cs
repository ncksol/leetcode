int[][] mat = new int[3][];
mat[0] = new int[3] { 1, 0, 0 };
mat[1] = new int[3] { 0, 0, 1 };
mat[2] = new int[3] { 1, 0, 0 };


var ones = new List<(int i, int j)>();

for (var i = 0; i < mat.Length; i++)
{
    for (var j = 0; j < mat[0].Length; j++)
    {
        if (mat[i][j] != 1) continue;

        ones.Add((i, j));
        Console.WriteLine($"{i} {j}");
    }
}
var counter = 0;

foreach (var one in ones)
{



    if(ones.Any(x => x.i == one.i && x.j != one.j)) continue;

    if(ones.Any(x => x.j == one.j && x.i != one.i)) continue;

    counter++;
}

return counter;