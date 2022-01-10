//var strs = new string[] { "10", "0", "1" }.OrderBy(x => x.Length).ToArray();

var m = 9;
var n = 3;
var strs = new string[] { "0001", "0101", "1000", "1000" }.OrderBy(x => x.Length).OrderBy(y => m < n ? y.Count(z => z == '0') : y.Count(z => z == '1')).ToArray();

var total = new List<int>();
for (int i = 0; i < strs.Length; i++)
{
    var res = Foo(i, m, n);
    total.Add(res);
}

Console.WriteLine(total.Max());

int Foo(int i, int m, int n)
{
    if(i == strs.Length)
        return 0;

    var str = strs[i];

    var zeros = str.Count(x => x == '0');
    var ones = str.Count(x => x == '1');

    var zerosLeft = m - zeros;
    var onesLeft = n - ones;
    
    if(zerosLeft == 0 && onesLeft == 0)
        return 1;

    var res = 1;
    if (zerosLeft < 0 || onesLeft < 0)
    {
        res = 0;
        zerosLeft = m;
        onesLeft = n;
    }

    res += Foo(i + 1, zerosLeft, onesLeft);

    return res;
}