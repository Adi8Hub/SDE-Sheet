/*
https://leetcode.com/problems/where-will-the-ball-fall/


Direction 
1: top left to bottom right  \
2: top right to bottom left  /

Intuition:
1. iterate over balls
2. start with row=0 and col= ball, ie, 0th ball from 0 col, 1st ball from 1st col and so on
3. within boundary loop and check:
  if(dir=1) then check if  its in left boundary or its right col has dir=-1. if yes then stuck and break and iterate for another ball. increment col
  if(dir=-1) then check if  its in right boundary or its left col has dir=1. if yes then stuck and break and iterate for another ball. decrement col
4. add to the result. if stuck add -1 to the list.
*/

public class Solution {
    public int[] FindBall(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;

        int[] result = new int[n];
        
        for(int ball = 0;ball<n;ball++)
        {
            bool stuck = false;
            int row=0, col=ball;
            while(row<m && col<n)
            {
                if(grid[row][col]==1)
                {
                    if((col==n-1) || (grid[row][col+1]==-1))
                    {
                        stuck = true;
                        break;
                    }
                    col++;
                }
                else//-1
                {
                    if((col==0) || (grid[row][col-1]==1))
                    {
                        stuck = true;
                        break;
                    }
                    col--;
                }
                row++;
            }
            if(stuck) 
                result[ball]=-1;
            else
                result[ball]=col;
            
        }
        return result;
    }
}
