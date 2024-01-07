/*
https://leetcode.com/problems/3sum-closest/

Steps:
1. Sort the array
2. Loop from start , consider it as forst, 
then take the next as second and the last element as 3rd
3. Check abs diff between the 3-sum and target.
4. if above is min then previously found diff then assign the above sum as closestSum
5. Check if above sum < target, then left++ else right--
*/

public class Solution {
    public int ThreeSumClosest(int[] nums, int target) 
    {
        int n = nums.Length;

        int closest = int.MaxValue;
        Array.Sort(nums);
        for(int i=0;i<n-2;i++)
        {
            int j =i+1;
            int k =n-1;

            while(j<k)
            {
                int sum = nums[i]+nums[j]+nums[k];

                if(Math.Abs(target-sum)<Math.Abs(target-closest))
                    closest = sum;

                if(sum<target) 
                    j++;
                else 
                    k--;
            }

        }
        return closest;
    }
}
