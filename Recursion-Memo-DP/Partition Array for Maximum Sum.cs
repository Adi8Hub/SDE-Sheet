// https://leetcode.com/problems/partition-array-for-maximum-sum/

// 1. Recursion
// O(K^n)
public class Solution {
    public int MaxSumAfterPartitioning(int[] arr, int k) {
     return solve(arr,k,0);   
    }


    public int solve(int[] arr, int k, int start)
    {
        if(start>=arr.Length) return 0;

        int result = 0;
        int currMax = -1;
        for(int i =start;i<arr.Length && (i-start+1)<=k;i++)
        {
            currMax = Math.Max(currMax,arr[i]);
            result = Math.Max(result, currMax*(i-start+1)+solve(arr,k,i+1));

        }

        return result;
    }
}
