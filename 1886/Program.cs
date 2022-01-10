var mat = new int[3][];
mat[0] = new int[3] { 0, 0, 0 };
mat[1] = new int[3] { 0, 1, 0 };
mat[2] = new int[3] { 1, 1, 1 };

var target = new int[3][];
target[0] = new int[3] { 1, 1, 1 };
target[1] = new int[3] { 0, 1, 0 };
target[2] = new int[3] { 0, 0, 0 };

var eq = FindRotation(mat, target);

Console.WriteLine("");



int[][] Transpose(int[][] mat)
{
    var tran = new int[mat.Length][];

    for (int i = 0; i < mat.Length; i++)
    {
        tran[i] = new int[mat.Length];
        for (int j = 0; j < mat[i].Length; j++)
        {
            tran[i][j] = mat[j][i];
        }
    }

    return tran;
}

int[][] Reverse(int[][] mat)
{
    var rev = new int[mat.Length][];

    for (int i = 0; i < mat.Length; i++)
    {
        rev[i] = mat[i].Reverse().ToArray();       
    }

    return rev;
}

bool Compare(int[][] a, int[][] b)
{
    for (int i = 0; i < a.Length; i++)
    {
        if(Enumerable.SequenceEqual(a[i], b[i]) == false)
            return false;
    }

    return true;
}

bool FindRotation(int[][] mat, int[][] target)
{
    var rotate = mat;
    for (int i = 0; i < 4; i++)
    {
        rotate = Reverse(Transpose(rotate));
        if(Compare(target, rotate) == true)
            return true;
    }

    return false;
}