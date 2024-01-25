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


// 2.  Memoization
public class Solution {
    int[][] t;
    public int LongestCommonSubsequence(string text1, string text2) {
        int t1 = text1.Length;
        int t2 = text2.Length;
         t = new int[t1+1][];
        for(int i =0;i<t.Length;i++)
        {
            t[i]= new int[t2+1];
            Array.Fill(t[i],-1);
        }

        return LCS(text1,text2,0,0,t1,t2);
    }

    public int LCS(string text1, string text2, int m,int n,int t1, int t2)
    {

        if(m>=t1 || n>=t2) return 0;

        if(t[m][n]!=-1)
            return t[m][n];

        if(text1[m]==text2[n])
            return t[m][n] = 1+ LCS(text1,text2,m+1,n+1,t1,t2);

        return t[m][n] = Math.Max(LCS(text1,text2,m,n+1,t1,t2),LCS(text1,text2,m+1,n,t1,t2));
    }
}


// 3. DP
public class Solution {
    
    public int LongestCommonSubsequence(string text1, string text2) {
        int m = text1.Length;
        int n = text2.Length;
        int[][] t = new int[m+1][];
        for(int i =0;i<t.Length;i++)
        {
            t[i]= new int[n+1];
            
        }

        // 1st col would be 0, as str2 is empty
        for(int row = 0;row<=m;row++)
        {
            t[row][0]=0;
        }

        // 1st row is 0, as str1 is empty
        for(int col = 0;col<=n;col++)
        {
            t[0][col]=0;
        }

        
        for(int i =1;i<=m;i++)
        {
            for(int j =1;j<=n;j++)
            {
                if(text1[i-1] == text2[j-1])// length of 1 means index 0 in str ie.e 1 less
                    t[i][j] = 1 + t[i-1][j-1];

                else
                    t[i][j] = Math.Max(t[i-1][j],t[i][j-1]) ;

            }
        }
        return t[m][n];
    }
}
