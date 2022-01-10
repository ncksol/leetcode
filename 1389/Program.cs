int[] nums = {0,1,2,3,4};
int[] index = {0,1,2,2,1};
var target = new List<int>();

for(int i = 0; i < nums.Length; i++)
{
    target.Insert(index[i], nums[i]);    
}