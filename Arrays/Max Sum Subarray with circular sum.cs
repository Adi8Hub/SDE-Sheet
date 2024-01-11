/*
https://leetcode.com/problems/maximum-sum-circular-subarray/description/
*/

/*
1. Find totalSum
2. MaxSum using Kadane
3. MinSum using kadane by replacing max with min from step 2
4. Circular Sum = TotalSum-MaxSum


*/

public class Solution {
    public int MaxSubarraySumCircular(int[] nums) {
        int n = nums.Length;

        int totalSum = 0;
        for(int i=0;i<n;i++)
        {
            totalSum+=nums[i];
        }

        int maxSum = kadaneMax(nums,n);
        int minSum = kadaneMin(nums,n);

        int circularSum = totalSum-minSum;//if circular sum gives maxSUm, then circularsum i.e. maxsum + min Sum equals totalSum

        if(maxSum>0) 
            return Math.Max(maxSum,circularSum);

        //if maxSum < 0, then circularSum could become a value which is not possible but which is not possible as in e.g [-1,-1,-1], 
        //maxSum=-1,circularSum=0, but no sum whether staright or circular goves value 0
        return maxSum;
    }

    public int kadaneMax(int[] nums,int n)
    {
        int currMax = nums[0];
        int maxi = nums[0];

        for(int i =1;i<n;i++)
        {
            currMax= Math.Max(currMax+nums[i],nums[i]);
            maxi = Math.Max(currMax,maxi);
        }

        return maxi;
    }

    public int kadaneMin(int[] nums,int n)
    {
        int currMin = nums[0];
        int mini = nums[0];

        for(int i =1;i<n;i++)
        {
            currMin= Math.Min(currMin+nums[i],nums[i]);
            mini = Math.Min(currMin,mini);
        }

        return mini;
    }
}
