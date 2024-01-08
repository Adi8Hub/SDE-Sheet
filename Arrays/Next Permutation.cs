/*
https://leetcode.com/problems/next-permutation
https://www.geeksforgeeks.org/problems/next-permutation5226/1


Steps:
1. Find next lower no from right side. Mark it as X index
2. If X present. 
Find next bigger no from right to X+1. Mark it as Y
Swap X&Y.
3. reverse from X+1 to n-1
*/

public class Solution {
    public void NextPermutation(int[] nums) 
    {
        int n = nums.Length;
        int swappingIndex = -1;

        //1
        for(int i = n-1;i>0;i--)
        {
            if(nums[i-1] < nums[i])
            {
                swappingIndex = i-1;
                break;
            }
        }
        //

      //2
        if(swappingIndex!= -1)
        {
            int swapWith = swappingIndex;
            for(int i = n-1; i > swappingIndex; i--)
            {
                if(nums[i] > nums[swappingIndex])
                {
                    swapWith = i;
                    break;
                }
            }
            swap(nums,swappingIndex, swapWith);
        }
      //

      //3
        reverse(nums,swappingIndex+1,n-1);
      //
    }

    public void swap(int[] a, int i , int j)
    {
        int temp = a[i];
        a[i] = a[j];
        a[j] = temp;
    }

    public void reverse(int[] a, int i , int j)
    {
        while(i<j)
        {
            swap(a,i,j);
            i++;j--;
        }
    }
}
