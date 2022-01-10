int[][] grid = new int[][] 
{
 new int[] {0,0,1,1},
 new int[] {1,0,1,0},
 new int[] {1,1,0,0},
};

var n = grid.Length;
var m = grid[0].Length;

for(var i = 0; i < n; i++) 
{
    if(grid[i][0] == 0)
    {
        for (int j = 0; j < m; j++)
        {
            grid[i][j] = grid[i][j] == 0 ? 1 : 0;
        }
    }
}

int[] zeroes = new int[m];

for (int i = 0; i < m; i++)
{
    zeroes[i] = 0;
    for (int j = 0; j < n; j++)
    {
        if(grid[j][i] == 0)
            zeroes[i]++;
    }
}

for (int i = 0; i < m; i++)
{
    if(zeroes[i] > n-zeroes[i])
    {
        for (int j = 0; j < n; j++)
        {
            grid[j][i] = grid[j][i] == 0 ? 1 : 0;
        }
    }
}

int sum = 0;
for (int i = 0; i < n; i++)
{
    var number = "";
    for (int j = 0; j < m; j++)
    {
        number += grid[i][j];
    }

    sum += Convert.ToInt32(number, 2);
}

return sum;