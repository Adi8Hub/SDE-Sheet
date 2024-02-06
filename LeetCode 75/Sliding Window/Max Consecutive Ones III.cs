// https://leetcode.com/problems/max-consecutive-ones-iii/


// if currElement is 0 increase zero count
// if count > k, shrink the window from left by doing left++
// calculate max count of zero
public class Solution {
    public int LongestOnes(int[] nums, int k) {
        int n = nums.Length;

        int l=0,r=0;
        int zero=0;
        int ans = 0;
        while(r<n)
        {
            if(nums[r]==0)
                zero++;

            while(zero>k)
            {
                if(nums[l]==0)
                    zero--;

                l++;
            }
            ans = Math.Max(ans,r-l+1);
            r++;
        }
        return ans;
    }
}
