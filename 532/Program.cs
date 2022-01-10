int[] nums = new int[] { 1, 2, 4, 4, 3, 3, 0, 9, 2, 3 };
int k = 3;

FindPairs(nums, k);


int FindPairs(int[] nums, int k)
{
    var result = new List<(int, int)>();

    for (var i = 0; i < nums.Length; i++)
    {
        for (var j = i + 1; j < nums.Length; j++)
        {
            var diff = Math.Abs(nums[i] - nums[j]);
            if (diff == k && 
                    (result.Contains((nums[i], nums[j])) == false &&
                    result.Contains((nums[j], nums[i])) == false ))
                result.Add((nums[i], nums[j]));
        }
    }

    return result.Count;
}