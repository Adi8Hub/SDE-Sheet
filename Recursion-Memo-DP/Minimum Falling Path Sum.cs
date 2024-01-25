// https://leetcode.com/problems/minimum-falling-path-sum/description

// 1. Recursion
/*
- Start with 0th row and loop over col from 0 to n and find the minimum
- Check for minsum by comparing currsum with curr direction i.e. d,dl,dr
*/

public class Solution 
{
    public int MinFallingPathSum(int[][] matrix) 
    {
        int row= 0;
        int minSum = int.MaxValue;
        
        for(int col=0;col<matrix.Length;col++)
        {
            minSum = Math.Min(minSum,solve(matrix,row,col));
        }
        return minSum;
    }

    public int solve(int[][] matrix, int row, int col)
    {
        if(row==matrix.Length-1) 
        {            
            return matrix[row][col];
        }
        
        int mSum = int.MaxValue;
        int sum = matrix[row][col];

        if(row+1<matrix.Length && col-1>=0)
            mSum = Math.Min(mSum,sum+solve(matrix,row+1,col-1));

        if(row+1<matrix.Length)
            mSum = Math.Min(mSum,sum+solve(matrix,row+1,col));

        if(row+1<matrix.Length && col+1<matrix.Length)
            mSum = Math.Min(mSum,sum+solve(matrix,row+1,col+1));

        return mSum;
    }    
}



// 2. Memoization
public class Solution 
{   
    int[,] t = new int[101,101];
    public int MinFallingPathSum(int[][] matrix) 
    {
        int n =matrix.Length;
        int row= 0;
        int minSum = int.MaxValue;

        for(int i =0;i<n;i++)
        {
            for(int j =0;j<n;j++)
            {
                t[i,j]=1000;
            }            
        }

        for(int col=0;col<n;col++)
        {
            minSum = Math.Min(minSum,solve(matrix,row,col));
        }
        return minSum;
    }

    public int solve(int[][] matrix, int row, int col)
    {
        if(row==matrix.Length-1) 
        {            
            return matrix[row][col];
        }
        if(t[row,col]!=1000) return t[row,col];
        int mSum = int.MaxValue;
        int sum = matrix[row][col];

        if(row+1<matrix.Length && col-1>=0)
            mSum = Math.Min(mSum,sum+solve(matrix,row+1,col-1));

        if(row+1<matrix.Length)
            mSum = Math.Min(mSum,sum+solve(matrix,row+1,col));

        if(row+1<matrix.Length && col+1<matrix.Length)
            mSum = Math.Min(mSum,sum+solve(matrix,row+1,col+1));

        return t[row,col]=mSum;
    }   
}




// 3. DP - Bottom Up
public class Solution 
{   int[,] t = new int[101,101];
    public int MinFallingPathSum(int[][] matrix) 
    {
        int n =matrix.Length;
        
        int minSum = int.MaxValue;

        // Fill 1st row same as original array
        for(int j =0;j<n;j++)
        {
            t[0,j]=matrix[0][j];
        }            
        
        // Calculate from row1
        for(int i =1;i<n;i++)
        {
            for(int j =0;j<n;j++)
            {
                int a = int.MaxValue;// Diagonal left
                int b = int.MaxValue;// diagonal right

                if(j-1 >= 0)
                    a = t[i-1,j-1];

                if( j+1 < n)
                    b = t[i-1,j+1];

                t[i,j] = matrix[i][j] + Math.Min(t[i-1,j],Math.Min(a,b));
            }  
        }
        //3. Find min sum from the last row as it contains all the accumulated minSums at that cell
        for(int col=0;col<n;col++)
        {
            minSum = Math.Min(minSum,t[n-1,col]);
        }
        return minSum;
    }    
}
