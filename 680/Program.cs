var s = "aba";
s = "abca";
s = "abc";
s = "abfcdeedcba";
s = "aguokepatgbnvfqmgmlcupuufxoohdfpgjdmysgvhmvffcnqxjjxqncffvmhvgsymdjgpfdhooxfuupuculmgmqfvnbgtapekouga";

Console.WriteLine(ValidPalindrome(s));


bool ValidPalindrome(string s)
{
    var i = 0;
    var j = s.Length - 1;

    while (i < j)
    {
        if(s[i] != s[j])
        {
            return IsValid(s, i+1, j) || IsValid(s, i, j-1);
        }
        i++;
        j--;
    }

    return true;
}

bool IsValid(string s, int i, int j)
{
    while (i < j)
    {
        if(s[i] != s[j]) return false;

        i++;
        j--;
    }

    return true;
}