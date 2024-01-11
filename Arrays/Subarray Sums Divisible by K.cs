/*
https://leetcode.com/problems/subarray-sums-divisible-by-k
*/

public class Solution {
    public int SubarraysDivByK(int[] nums, int k) {
        int n = nums.Length;
        int sum =0;
        int result = 0;
        Dictionary<int, int> dict = new();
        dict[0] = 1;

        for(int i=0;i<n;i++)
        {
            sum += nums[i];
            int rem = sum%k;

            if(rem<0)   
            {
                rem += k;
            }

            if(dict.ContainsKey(rem))
            {
                result+=dict[rem];
                dict[rem]++;
            }
            else
            {
                dict[rem]=1;
            }
        }
        return result;
    }
}
