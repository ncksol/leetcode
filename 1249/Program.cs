using System.Text;

var s = "lee(t(c)o)de)";
s = "l(e)et((co)d(e";
//s = "a)b(c)d";
//s = "))((";

Console.WriteLine(MinRemoveToMakeValid(s));


string MinRemoveToMakeValid(string s)
{
    var forward = new StringBuilder();
    var balance = 0;
    var openSeen = 0;

    for (int i = 0; i < s.Length; i++)
    {
        var cur = s[i];
        if (cur == '(')
        {
            balance++;
            openSeen++;
        }
        else if (cur == ')')
            balance--;

        if (balance >= 0)
            forward.Append(cur);
        else
            balance = 0;
    }
    
    var result = new StringBuilder();
    var openToKeep = openSeen-balance;

    for (int i = 0; i < forward.Length; i++)
    {
        var cur = forward[i];
        if (cur == '(')
        {
            openToKeep--;
            if(openToKeep < 0) continue;
        }        

        result.Append(cur);
    }

    return result.ToString();
}
/*
string MinRemoveToMakeValid2(string s)
{
    var forward = new StringBuilder();
    var balance = 0;

    for (int i = 0; i < s.Length; i++)
    {
        var cur = s[i];
        if(cur == '(')
            balance++;
        else if(cur == ')')
            balance--;

        if(balance >= 0)
            forward.Append(cur);
        else
            balance = 0;
    }

    s = new string(forward.ToString().Reverse().ToArray());
    
    var backward = new StringBuilder();
    balance = 0;

    for (int i = 0; i < s.Length; i++)
    {
        var cur = s[i];
        if (cur == ')')
            balance++;
        else if (cur == '(')
        { 
            if(balance == 0)
                continue;
            balance--;
        }

        backward.Append(cur);
    }

    return new string(backward.ToString().Reverse().ToArray());
}*/
/*string MinRemoveToMakeValid1(string s)
{
    var stack = new Stack<int>();
    var toRemove = new HashSet<int>();
    for (int i = 0; i < s.Length; i++)
    {
        var cur = s[i];

        if (cur == '(')
        {
            stack.Push(i);
        }
        else if (cur == ')')
        {
            if (stack.TryPop(out var _) == false)
            {
                toRemove.Add(i);
            }
        }
    }

    toRemove.UnionWith(stack);

    var sb = new StringBuilder();
    for (int i = 0; i < s.Length; i++)
    {
        if(toRemove.Contains(i)) continue;

        sb.Append(s[i]);
    }

    return sb.ToString();
}*/