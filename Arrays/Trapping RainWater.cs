/*
https://leetcode.com/problems/trapping-rain-water/

1. Using leftmax and rightmax array
*/

public class Solution {
    public int[] getLeftMaxArray(int[] height)
    {
        int[] leftMaxArray = new int[height.Length];
        leftMaxArray[0] = height[0];

        for(int i =1;i<height.Length;i++)
        {
            leftMaxArray[i] = Math.Max(leftMaxArray[i-1],height[i]);
        }
        return leftMaxArray;
    }

    public int[] getRightMaxArray(int[] height)
    {
        int[] rightMaxArray = new int[height.Length];
        rightMaxArray[height.Length-1] = height[height.Length-1];

        for(int i =height.Length-2;i>=0;i--)
        {
            rightMaxArray[i] = Math.Max(rightMaxArray[i+1],height[i]);
        }
        return rightMaxArray;
    }

    public int Trap(int[] height) {
        int n = height.Length;
        int ans=0;
        int[] leftMax = getLeftMaxArray(height);
        int[] rightMax = getRightMaxArray(height);

        for(int i =1;i<n-1;i++)
        {
            ans += (Math.Min(leftMax[i],rightMax[i])-height[i]);
        }
        return ans;
    }
}
