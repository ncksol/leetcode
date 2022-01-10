var w = new int[] {1,3,1};

var obj = new Solution(w);

for (int i = 0; i < 10; i++)
{
    var param1 = obj.PickIndex();
    Console.WriteLine(param1);
}



class Solution
{
    private Random _rnd;
    private int[] _p;

    public Solution(int[] w)
    {
        _rnd = new Random();
        _p = new int[w.Length];
        _p[0] = w[0];

        for (int i = 1; i < w.Length; i++)
        {
            _p[i] = w[i] + _p[i - 1];
        }
    }

    public int PickIndex()
    {
        double rndIndex = _rnd.NextDouble() * _p.Last();
        
        for (int i = 0; i < _p.Length; i++)
        {
            if(rndIndex < _p[i])
                return i;
        }

        return -1;
    }
}