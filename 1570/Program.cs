var nums1 = new int[] { 1, 0, 0, 2, 3 };
var nums2 = new int[] { 0, 3, 0, 4, 0 };


SparseVector v1 = new SparseVector(nums1);
SparseVector v2 = new SparseVector(nums2);
int ans = v1.DotProduct(v2);

Console.WriteLine(ans);

class SparseVector
{
    private Dictionary<int, int> _data = new Dictionary<int, int>();

    public SparseVector(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if(nums[i] != 0)
                _data.Add(i, nums[i]);
        }
    }

    // Return the dotProduct of two sparse vectors
    public int DotProduct(SparseVector vec)
    {
        var result = 0;

        foreach (var key in vec._data.Keys)
        {
            if(_data.TryGetValue(key, out var value))
                result += value * vec._data[key];
        }

        return result;
    }
}
