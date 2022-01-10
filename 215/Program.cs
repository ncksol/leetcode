//int[] nums = {3,2,3,1,2,4,5,5,6};
int[] nums = {3,2,1,5,6,4};
int k = 2;

//Array.Sort<int>(nums, delegate(int m, int n) {return n-m;});
//Array.Reverse(nums);

Array.Sort(nums);
        
return nums[nums.Length-k-1];