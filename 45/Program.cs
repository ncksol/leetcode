var nums = new int[] {5, 6, 4, 4, 6, 9, 4, 4, 7, 4, 4, 8, 2, 6, 8, 1, 5, 9, 6, 5, 2, 7, 9, 7, 9, 6, 9, 4, 1, 6, 8, 8, 4, 4, 2, 0, 3, 8, 5};
//var nums = new int[] { 1, 2, 3 };
//var nums = new int[] { 2, 3, 1, 1, 4 };
//var nums = new int[] { 2, 3, 5, 1, 4 };
//var nums = new int[] { 0 };
//var nums = new int[] { 3, 2, 1 };
//var nums = new int[] { 1, 2, 1, 1, 1 };
//var nums = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 1, 0 };
//var nums = new int[] { 2,1 };

var curIndex = 0;
var count = 0;

do
{
    var nextIndex = Work(curIndex, nums);
    if (nextIndex == -1)
        break;

    if (curIndex != nextIndex)
    {
        curIndex = nextIndex;
        count++;
    }
}
while (curIndex < nums.Length - 1);

Console.WriteLine($"{count}");

int Work(int curIndex, int[] nums)
{
    var jumps = nums[curIndex];
    var maxValueIndex = -1;
    while (jumps > 0)
    {
        if (curIndex + jumps < nums.Length)
        {
            var jumpIndex = curIndex + jumps;
            if (jumpIndex == nums.Length - 1)
                return curIndex + jumps;
            else if (jumpIndex >= nums.Length)
                continue;
            else
            {
                var jumpLocationValue = nums[jumpIndex];
                if (maxValueIndex == -1 || jumpLocationValue + jumpIndex > nums[maxValueIndex] + maxValueIndex)
                    maxValueIndex = jumpIndex;
            }
        }

        jumps--;
    }

    return maxValueIndex;
}