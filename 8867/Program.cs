var s = "aaaaaaaa";
var wordDict = new List<string>(){ "aaaa","aaa", "aa"};

var success = WordBreak(s, wordDict, new HashSet<int>(), 0);

Console.WriteLine(success ? "YES" : "NO");


bool WordBreak(string s, IList<string> wordDict, HashSet<int> seen, int index)
{
    if (!seen.Add(index))
        return false;

    if (index == s.Length)
        return true;

    var sub = s.Substring(index);
    foreach (var word in wordDict)
    {
        if(sub.StartsWith(word) && WordBreak(s, wordDict, seen, index + word.Length))
            return true;
    }
    return false;
}

