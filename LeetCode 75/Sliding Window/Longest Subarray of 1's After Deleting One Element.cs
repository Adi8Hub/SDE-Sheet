// https://leetcode.com/problems/longest-subarray-of-1s-after-deleting-one-element/description/

// Brute Force- n^2
public class Solution {
    public int LongestSubarray(int[] nums) 
    {
        int n = nums.Length;
        int zero=0;
        int ans=0;

        for(int i =0;i<n;i++)
        {
            if(nums[i]==0)
            {
                zero++;
                ans = Math.Max(ans,findSubArr(nums,i));
            }
        }

        if(zero==0)
        {
            return n-1;
        }
        return ans;
    }

    int findSubArr(int[] nums, int idx)
    {
        int currLength=0;
        int maxLength=0;

        for(int i = 0;i<nums.Length;i++)
        {
            if(i==idx)
            {
                continue;
            }

            if(nums[i]==1)
            {
                currLength++;
                maxLength = Math.Max(maxLength, currLength);
            }
            else
            {
                currLength=0;
            }
        }
        return maxLength;
    }
}


// Sliding Window
public class Solution {
    public int LongestSubarray(int[] nums) 
    {
        int n = nums.Length;
        int maxLength=0;
        int zero=0;

        for(int start=0, end =0;end<n;end++)
        {
            if(nums[end]==0)
                zero++;

            while(zero>1)
            {
                if(nums[start]==0)
                    zero--;
                start++;
            }

            maxLength= Math.Max(maxLength,end-start);
        }
        return maxLength;
    }
}

// Using 2 pointers, sliding window
// set lastZeroindex to the left and move right 
// if currelement is 0,move left pointer to lastzeroindex+1 and lastzeroindex to curr pointer i.e. right pointer
// calculate max
public class Solution {
    public int LongestSubarray(int[] nums) 
    {
        int n = nums.Length;
        int maxLength=0;
        int i = 0,j = 0;
        int lastZero = -1;

        while(j<n)
        {
            if(nums[j]==0)
            {
                i=lastZero+1;
                lastZero=j;
            }
            maxLength=Math.Max(maxLength,j-i);
            j++;
        }
        return maxLength;
    }
}
