/*
https://leetcode.com/problems/continuous-subarray-sum/

Subarray sum is multiple of k, if exists return true

*/

public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        int n = nums.Length;
        var dict = new Dictionary<int,int>();
        dict[0]=-1;
        int sum = 0;
        for(int i =0;i<n;i++)
        {
            sum += nums[i];

            if(dict.ContainsKey(sum%k))
            {
                if(i-dict[sum%k]>=2)
                    return true;
            }
            else
            {
                dict.Add(sum%k,i);
            }
        }
        return false;
    }
}
