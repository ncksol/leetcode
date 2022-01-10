var nums = new int[] {1,-1,0};
var k = 0;

Console.WriteLine(SubarraySum(nums, k));

int SubarraySum(int[] nums, int k)
{
    var counter = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        var sum = nums[i];

        if (sum == k)
            counter++;

        for (int j = i + 1; j < nums.Length; j++)
        {
            sum += nums[j];
            if (sum == k)
            {
                counter++;
            }
        }
    }

    return counter;
}
