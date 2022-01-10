var heights = new int[] { 4,2,3,1};
heights = new int[] { 4,3, 2,1};
heights = new int[] { 1,3,2,4};

var valid = FindBuildings(heights);

Console.WriteLine(string.Join(' ', valid));


int[] FindBuildings(int[] heights)
{
    var validHeights = new Stack<int>();
    validHeights.Push(0);

    for (int i = 1; i < heights.Length; i++)
    {
        var h = heights[i];

        while (validHeights.Count > 0 && h >= heights[validHeights.Peek()])
        {
            validHeights.Pop();
        }

        validHeights.Push(i);
    }

    return validHeights.Reverse().ToArray();
}
