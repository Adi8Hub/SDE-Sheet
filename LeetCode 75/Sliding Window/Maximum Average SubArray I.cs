// https://leetcode.com/problems/maximum-average-subarray-i/

public class Solution {
    public double FindMaxAverage(int[] nums, int k) {
        double sum = 0;
        for (int i = 0; i < k; ++i)
        {
            sum += nums[i];
        }
        double ans = sum;

        for (int i = k; i < nums.Length; ++i) {
            sum += nums[i] - nums[i - k];
            ans = Math.Max(ans, sum);
        }

        return ans / k;
    }
}
