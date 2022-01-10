var s = "(((";

var c = MinAddToMakeValid(s);

Console.WriteLine(c);

int MinAddToMakeValid(string s)
{
    var counter = 0;
    var openCount = 0;

    for (int i = 0; i < s.Length; i++)
    {
        var cur = s[i];
        if(cur == '(')
            openCount++;
        else if(cur == ')')
        {
            if(openCount == 0)
                counter++;
            else
            {
                openCount--;
            }
        }
    }

    return counter + openCount;
}