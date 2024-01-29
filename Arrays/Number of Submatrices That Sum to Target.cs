// https://leetcode.com/problems/number-of-submatrices-that-sum-to-target

// 1. Brute Force 
//T.C : O(m^3 * n^3)
//S.C : O(1)

public class Solution {
    public int NumSubmatrixSumTarget(int[][] matrix, int target) 
    {
        int m = matrix.Length;
        int n = matrix[0].Length;

        int result = 0;

        for(int sRow = 0;sRow<m;sRow++)
        {
            for(int sCol=0;sCol<n;sCol++)
            {
                for(int eRow = sRow;eRow<m;eRow++)
                {
                    for(int eCol = sCol;eCol<n;eCol++)
                    {
                        int sum = 0;
                        for(int i = sRow;i<=eRow;i++)
                        {
                            for(int j = sCol;j<=eCol;j++)
                            {
                                sum+=matrix[i][j];
                            }
                        }

                        if(sum==target)
                            result++;
                    }
                }
            }
        }
        return result;
    }
}


// Using Prefix Sum
//T.C : O(n^2 * m)
//S.C : O(m)
public class Solution {
    public int NumSubmatrixSumTarget(int[][] matrix, int target) 
    {
        int m = matrix.Length;
        int n = matrix[0].Length;

        int result = 0;

        // Fill cumulative sum row-wise
        for(int i =0;i<m;i++)
        {
            for(int j =1;j<n;j++)
            {
                matrix[i][j] += matrix[i][j-1];
            }
        }

        // Add cells of a single column 
        for(int sCol=0;sCol<n;sCol++)
        {
            for(int currCol=sCol;currCol<n;currCol++)
            {
                Dictionary<int,int> map = new Dictionary<int,int>();
                map.Add(0,1);
                int cSum=0;
                for(int row=0;row<m;row++)
                {
                  //Get Cumulative Sum from starting COlumn to currColumn, if starting Col>0 then subtract the Cumulative SUm present in column before the start Column
                    cSum += matrix[row][currCol] - (sCol==0 ? 0 : matrix[row][sCol-1]);

                    if(map.ContainsKey(cSum-target))
                    {
                        result +=map[cSum-target];
                    }
                    if(map.ContainsKey(cSum))
                    {
                        map[cSum]++;
                    } 
                    else
                    {
                        map.Add(cSum,1);
                    }
                }
            }
        }
        return result;
    }
}
