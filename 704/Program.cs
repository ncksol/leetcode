int[] nums = new int[] { -1, 0, 3, 5, 9, 12 };
int target = 9;
var i = 0;
var j = nums.Length - 1;

while (i <= j)
{
    var ix = i + (j - i) / 2;
    if (target == nums[ix])
    {
        Console.Write(ix);
        break;
    }
    else if (target > nums[ix])
    {
        i = ix + 1;
    }
    else
    {
        j = ix - 1;
    }
}