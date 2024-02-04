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


// Memo
//T.C : With Memoization - O(n*k) -> We visit only n states in dp array and everytime run a for loop of size k
//      Without Memoization - We have 2 options at each index - O(k^n) - Since the recursion tree has a branching factor of k, and the depth of the recursion tree is at most n
//S.C : O(n)
public class Solution {
    public int MaxSumAfterPartitioning(int[] arr, int k) {
        int[] t = new int[arr.Length+1];
        Array.Fill(t,-1);
        return solve(arr,k,0,t);   
    }


    public int solve(int[] arr, int k, int start,int[] t)
    {
        if(start>=arr.Length) 
            return 0;

        if(t[start]!=-1)
            return t[start];

        int result = 0;
        int currMax = -1;

        for(int i =start;i<arr.Length && (i-start+1)<=k;i++)
        {
            currMax = Math.Max(currMax,arr[i]);
            result = Math.Max(result, currMax*(i-start+1)+solve(arr,k,i+1,t));
        }

        return t[start]=result;
    }
}



//Approach-2 (Botom Up)
//T.C : O(n*k)
//S.C : O(n)

public class Solution {
    public int MaxSumAfterPartitioning(int[] arr, int k) {
        int n = arr.Length;
        int[] t = new int[n + 1];
        
        //t[i] = Maximum sum for the partition arr of size i
        //we need to find max for whole array = t[n]
        
        for (int i = 1; i <= n; i++) { // 1. take full-array size first
            int currMax = -1;
            
            for (int j = 1; j <= k && i - j >= 0; j++) { // 2. Subarray of size j
                currMax = Math.Max(currMax, arr[i - j]);// find max of subarray upto k length from current index and moving left
                t[i] = Math.Max(t[i], t[i - j] + currMax * j);
            }
        }
        return t[n];  
    }
}
