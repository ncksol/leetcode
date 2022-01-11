
var nums = new int[] {2,2,3,4};
Array.Sort(nums);
var output = 0;

for (var i = 0; i < nums.Length; i++)
{
    for (var j = i+1; j < nums.Length; j++)
    {
        var k = nums.Length - 1;

        while (k > j)
        {
            if (nums[i] + nums[j] > nums[k]) break;
            output++;
            k--;
        }
    }
}
