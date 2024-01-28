Pending DP and DP optimized

// https://leetcode.com/problems/k-inverse-pairs-array

// 1. Recursion
public class Solution {
    int mod = 1000000007;
    public int KInversePairs(int n, int k) {
        return solve(n,k);
    }

    public int solve(int n, int k)
    {
        if(n==0) return 0;

        if(k==0) return 1;

        int result = 0;
        int maxInversions = Math.Min(k,n-1);//max inversions = n-1 or k whichever is less
        for(int inv =0;inv<=maxInversions;inv++)
        {
           result = (result+ solve(n-1,k-inv))%mod;
        }

        return result;
    }
}

// 2. Memo
public class Solution {
    int mod = 1000000007;
    int[,] t =new int[1001,1001];
    public int KInversePairs(int n, int k) {
        for(int i =0;i<1001;i++)
        {
            for(int j =0;j<1001;j++)
            {
                t[i,j]=-1;
            }
        }
        return solve(n,k);
    }

    public int solve(int n, int k)
    {
        if(n==0) return 0;

        if(k==0) return 1;
        
        if(t[n,k]!=-1)
            return t[n,k];
        int result = 0;
        int maxInversions = Math.Min(k,n-1);//max inversions = n-1 or k whichever is less
        for(int inv =0;inv<=maxInversions;inv++)
        {
           result = (result+ solve(n-1,k-inv))%mod;
        }

        return t[n,k]=result;
    }
}
