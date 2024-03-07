// https://leetcode.com/problems/longest-increasing-subsequence/description/

// Recursion 
public class Solution {
    public int LengthOfLIS(int[] nums) {
        // Complete it using REc+Memo,DP-BU,Patience Sorting-Bucket

        // Recursion
        return solve(nums,0,-1);
    }

    int solve(int[] nums, int idx, int prev)
    {
        if(idx>=nums.Length)
            return 0;

        // Take
        int take = 0;
        if(prev==-1 || nums[idx]>nums[prev])
            take = 1+solve(nums,idx+1,idx);

        //Skip
        int skip = solve(nums,idx+1,prev);

        return Math.Max(take,skip);
    }
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Memo
public class Solution {
    public int LengthOfLIS(int[] nums) {
        // Complete it using REc+Memo,DP-BU,Patience Sorting-Bucket
        int n = nums.Length;
        // Recursion+Memo
        int[,] t = new int[n+1,n+1];
        for(int i =0;i<=n;i++)
        {
            for(int j =0;j<=n;j++)
            {
                t[i,j]=-1;
            }
            // tr = new int[nums.Length+1];
        }
        return solve(nums,0,-1,t);
    }

    int solve(int[] nums, int idx, int prev,int[,] t)
    {
        if(idx>=nums.Length)
            return 0;

        if(prev!=-1 && t[idx,prev]!=-1)
            return t[idx,prev];
        // Take
        int take = 0;
        if(prev==-1 || nums[idx]>nums[prev])
            take = 1+solve(nums,idx+1,idx,t);

        //Skip
        int skip = solve(nums,idx+1,prev,t);

        if(prev!=-1)
            t[idx,prev]= Math.Max(take,skip);

        return Math.Max(take,skip);
    }
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// DP- Bottom UP
public class Solution {
    public int LengthOfLIS(int[] nums) {
        // Complete it using REc+Memo,DP-BU,Patience Sorting-Bucket
        
        // O(n^2)
        int n = nums.Length;
        // DP- Bottom  UP
        int[] t = new int[n];

        Array.Fill(t,1);
        int maxLIS=1;
        for(int i =0;i<n;i++)
        {
            for(int j =0;j<i;j++)
            {
                if(nums[j]<nums[i])
                {
                    t[i]= Math.Max(t[i],t[j]+1);
                    maxLIS = Math.Max(maxLIS,t[i]);
                }
            }
        }
        return maxLIS;   
    }
}
