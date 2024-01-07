/*
https://leetcode.com/problems/3sum/description/
TC- O(n^2)
Steps:
1. Sort the array,if unsorted
2. Fix one end and check if repeated , then take the last occurence of it. 
Consider it as target=-n1
3. Call TwoSum with original array,target,i+1,n-1
4. Within TwoSum-> if two sum found, check for repeated nos and go till last occurence
Add it to result, and then move to next indices.
5. return result
*/
public class Solution {
    IList<IList<int>> result = new List<IList<int>>();
    public IList<IList<int>> ThreeSum(int[] nums) {
        int n = nums.Length;        
        Array.Sort(nums);

        for(int i =0;i<n-2;i++)
        {
            //if same no. encountered again
            if(i>0 && nums[i]==nums[i-1])
                continue;

            int n1 = nums[i];
            int target = -n1;

            TwoSum(nums,target,i+1,n-1);
        }
        return result;
    }

    public void TwoSum(int[] nums, int target, int left,int right)
    {
        while(left<right)
        {        
            if(nums[left]+nums[right]<target)
                left++;
            else if(nums[left]+nums[right]>target)
                right--;
            else
            {
                //remove duplicates
                while(left<right && nums[left]==nums[left+1]) left++;
                while(left<right && nums[right]==nums[right-1]) right--;

                //add nos. after encountering over other duplicates
                result.Add(new List<int>(){
                    -target,nums[left],nums[right]
                });
                left++;
                right--;
            }
        }
    }
}


























// var res = new List<IList<int>>();
        // Array.Sort(nums);
        // for(int i=0; i<nums.Length-2;i++)
        // {
        //     if(i>0 && nums[i-1]==nums[i]) 
        //         continue;//If same no occurs, skip it.
            
        //     int low = i+1, high=nums.Length-1;
        //     int targetSum = -nums[i];
            
        //     while(low<high)
        //     {
        //         int twoSum = nums[low]+nums[high];
        //         if(twoSum==targetSum)
        //         {
        //             res.Add(new List<int>(){nums[i],nums[low],nums[high]});
        //             while (low < high && nums[low] == nums[low + 1]) low++;
        //             while (low < high && nums[high] == nums[high - 1]) high--;
        //              low++;
        //              high--;
        //         }
        //         else if(twoSum<targetSum)
        //         {
        //             low++;
        //         }
        //         else
        //             high--;
        //     }
            
        // }
        // return res;
