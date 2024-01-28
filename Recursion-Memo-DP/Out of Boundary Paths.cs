// https://leetcode.com/problems/out-of-boundary-paths/


// 1. Recursion
public class Solution {
    int[] dRow = {-1,0,0,1};
    int[] dCol = {0,1,-1,0};
    int M,N;
    public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn) {
        M=m;
        N=n;
        return solve(maxMove, startRow, startColumn);
        
    }

    public int solve(int maxMove, int startRow, int startColumn)
    {
        if(startRow<0 || startColumn<0 || startRow>=M || startColumn>=N)
            return 1;
            
        if(maxMove<=0)
            return 0;

        int result = 0;

        for(var dir=0;dir<4;dir++)
        {
            int nr = startRow+dRow[dir];
            int nc = startColumn+dCol[dir];

            result += solve(maxMove-1, nr, nc);
            
        }
        return result;
    }
}

// 2. Memoization
public class Solution {
    int[] dRow = {-1,0,0,1};
    int[] dCol = {0,1,-1,0};
    int M,N;
    int[,,] t = new int[50,50,51];
    public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn) {
        M=m;
        N=n;
        for(int i =0;i<m;i++)
        {
            for(int j =0;j<n;j++)
            {
                for(int k =0;k<=maxMove;k++)
                {
                    t[i,j,k]=-1;
                }
            }
        }
        return solve(maxMove, startRow, startColumn);
        
    }

    public int solve(int maxMove, int startRow, int startColumn)
    {
        if(startRow<0 || startColumn<0 || startRow>=M || startColumn>=N)
            return 1;
            
        if(maxMove<=0)
            return 0;

        if( t[startRow,startColumn,maxMove] != -1 )
            return t[startRow,startColumn,maxMove];

        int result = 0;

        for(var dir=0;dir<4;dir++)
        {
            int nr = startRow+dRow[dir];
            int nc = startColumn+dCol[dir];

            result = (result + solve(maxMove-1, nr, nc)) % 1000000007;
            
        }
        return t[startRow,startColumn,maxMove]=result;
    }
}

// DP
public class Solution {
    int[] dRow = {-1,0,0,1};
    int[] dCol = {0,1,-1,0};
    int M,N;
    int[,,] t = new int[50,50,51];
    public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn) {
        M=m;
        N=n;
        for(int k =1;k<=maxMove;k++)
        {
            for(int i =0;i<m;i++)
            {
                for(int j =0;j<n;j++)
                {
                    for(var dir=0;dir<4;dir++)
                    {
                        int nr = i+dRow[dir];
                        int nc = j+dCol[dir];

                        if(nr<0 || nc<0 || nr>=M || nc>=N)
                            t[ i, j,k] += 1;
                        else
                            t[i, j,k] =  (t[i, j,k] +  t[nr, nc,k-1]) % 1000000007;                        
                    }
                    
                }
            }
        }
        
        return t[startRow, startColumn,maxMove];        
    }
}
