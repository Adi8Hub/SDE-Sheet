// https://leetcode.com/problems/longest-common-subsequence/description

// 1. Recursion
public class Solution {
    
    public int LongestCommonSubsequence(string text1, string text2) {
        int t1 = text1.Length;
        int t2 = text2.Length;

        return LCS(text1,text2,0,0,t1,t2);
    }

    public int LCS(string text1, string text2, int m,int n,int t1, int t2)
    {

        if(m>=t1 || n>=t2) return 0;

        if(text1[m]==text2[n])
            return 1+ LCS(text1,text2,m+1,n+1,t1,t2);

        return Math.Max(LCS(text1,text2,m,n+1,t1,t2),LCS(text1,text2,m+1,n,t1,t2));
    }
}
