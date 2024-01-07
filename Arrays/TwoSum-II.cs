/*
https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/description/
Using Dictionary
TC- O(n)
SC- O(n)
*/

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int,int> map = new Dictionary<int,int>();
        for(int i =0;i<nums.Length;i++)
        {
            int rem = target-nums[i];
            if(map.ContainsKey(rem))
            {
                return new int[]{ map[rem]+1,i+1};
            }

            if(!map.ContainsKey(nums[i]))
                map.Add(nums[i],i);
        }
        return null;
    }
}


/*
Using 2 pointers from left and right, as array is sorted, 
  we can compare their sum with target
TC- O(n)
SC- constant
*/

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        int left = 0, right = nums.Length-1;
        while(left<right)
        {
            if(nums[left]+nums[right]<target)
            {
                left++;
            }
            else if(nums[left]+nums[right]>target)
                right--;
            
            else
                return new int[]{left+1,right+1};
        }
        return null;
    }
}
