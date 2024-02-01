// https://leetcode.com/problems/divide-array-into-arrays-with-max-difference

public class Solution {
    public int[][] DivideArray(int[] nums, int k) {
        
        int n = nums.Length;
        // Sort the array to easily compare elements within the subarray
        Array.Sort(nums);
        int[][] result = new int[n/3][];
        int row=0;
        for(int i =0;i<n;i+=3)
        {
            if(nums[i+2]-nums[i] > k)
                return new int[][]{};
            
            result[row] = new int[3];
            result[row][0] = nums[i];
            result[row][1] = nums[i+1];
            result[row++][2] = nums[i+2];
            
        }
        return result;
    }
}
