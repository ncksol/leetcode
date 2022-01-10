var num = 9288;

var max = Max(num.ToString());
var min = Min(num.ToString());

Console.WriteLine(max-min);

int Max(string a)
{
    var maxDigit = a.FirstOrDefault(x => x != '9');
    return maxDigit != default ? int.Parse(a.Replace(maxDigit, '9')) : int.Parse(a);
}

int Min(string a)
{
    if(a[0] != '1')
    {
        a = a.Replace(a[0], '1');
    }
    else
    {
        var min = a.FirstOrDefault(x => x != '0' && x != '1');
        if(min != default)
            a = a.Replace(min, '0');
    }

    return int.Parse(a);
}