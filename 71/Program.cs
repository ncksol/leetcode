using System.Text;

var path = "/home//foo/";

//path = "/a/./b/../../c/";
path = "/../";

Console.WriteLine(SimplifyPath(path));

string SimplifyPath(string path)
{
    var split = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
    var stack = new Stack<string>();

    foreach (var item in split)
    {
        if(item == "..")
        {
            if(stack.Count > 0)
                stack.Pop();
        }
        else if(item == ".")
            continue;
        else
            stack.Push(item);
    }

    var sb = new StringBuilder();
    while(stack.TryPop(out var item))
    {
        sb.Insert(0, $"{item}/");
    }

    return "/" + sb.ToString().TrimEnd('/');

    //return "/" + string.Join('/', stack.Reverse());
}