Pending DP optimized: 
Optimal DP approach:
//Approach-3 - DP with cumulative sum approach
//Time : O(n*k)
//S.C : O(n*k)
- No need of inv loop
- use cumulativeSum, where cumSum += prevRow,i.e.,t[i-1][j] 
if(j>=i) then cumSum -= t[i-1][j-i]

// https://leetcode.com/problems/k-inverse-pairs-array

//Approach-1 (Recursion+Memo)
//T.C  : O(k^n)  --> for every n,we are operating on k combinations
//S.C  : tree depth or recursion stack
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
//T.C  : O(n*k*n)
//S.C  : O(n*k) -> memo + Recursion call stack
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


// 3. DP
//T.C  : O(n*k*n)
//S.C  : O(n*k) for memo + Recursion call stack
public class Solution {
    public int KInversePairs(int n, int k) 
    {
        int mod = 1000000007;
        // t[i,j] indicates total number of arrays consisting from 1 to i and exactly j inverse pairs
        int[,] t =new int[n+1,k+1];

        // if 0 inversions, then 1 . i.e.,for j=0;t[i,0]=1 
        for(int i =0;i<=n;i++)
        {
            t[i,0] = 1;
        }

        // 1st row i.e.0th row, 0 elements= 0 arrays
        // 1st column i.e.0th col, 0 inversions= 1 arrays present
        // start from row1,col1
        for(int i =1;i<=n;i++)
        {
            for(int j =1;j<=k;j++)
            {
                for(int inv =0;inv<=Math.Min(j,i-1);inv++)
                {
                    t[i,j] = (t[i,j]+ t[i-1,j-inv]%mod)%mod;
                }
            }
        }
        return t[n,k];
    }        
}


