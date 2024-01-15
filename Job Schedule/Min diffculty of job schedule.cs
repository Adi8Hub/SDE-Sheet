/*
https://leetcode.com/problems/minimum-difficulty-of-a-job-schedule/
*/

// Recursion -TLE
public class Solution {
    public int MinDifficulty(int[] jd, int d) {
        int n = jd.Length;

        if(n<d) return -1;

        return solve(jd,d,n,0);
    }

    public int solve(int[] jd, int d, int n, int idx)
    {
        // Base condition:
        // if only 1 day to assign jobs, 
        // find max among the array of jobs
        if(d==1)
        {
            int maxiD = jd[idx];
            for(int i = idx; i<n;i++)
            {
                maxiD = Math.Max(maxiD, jd[i]);
            }
            return maxiD;
        }

        int maxD = jd[idx];
        int result = int.MaxValue;

        for(int i = idx; i<=n-d;i++)
        {
            maxD = Math.Max(maxD, jd[i]);
            int midResult = maxD + solve(jd,d-1,n,i+1);
            result = Math.Min(result,midResult);
        }
        return result;
    }
}


//************************************************************************************//


// Memoization - TOP DOWN

public class Solution {
    int[,] t = new int[301,11];

    public int MinDifficulty(int[] jd, int d) {
        int n = jd.Length;

        if(n<d) return -1;

        for(int i = 0; i < t.GetLength(0); i++)
        {
            for(int j = 0; j < t.GetLength(1); j++)
            {
                t[i,j]=-1;
            }
        }

        return solve(jd,d,n,0,t);
    }

    public int solve(int[] jd, int d, int n, int idx,int[,] t)
    {
        // Base condition:
        // if only 1 day to assign jobs, 
        // find max among the array of jobs
        if(d==1)
        {
            int maxiD = jd[idx];
            for(int i = idx; i<n;i++)
            {
                maxiD = Math.Max(maxiD, jd[i]);
            }
            return maxiD;
        }

        if(t[idx,d]!= -1) return t[idx,d];

        int maxD = jd[idx];
        int result = int.MaxValue;

        for(int i = idx; i<=n-d;i++)
        {
            maxD = Math.Max(maxD, jd[i]);
            int midResult = maxD + solve(jd,d-1,n,i+1,t);
            result = Math.Min(result,midResult);
        }
        return t[idx,d]=result;
    }
}








