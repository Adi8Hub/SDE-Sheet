// https://leetcode.com/problems/subarray-sum-equals-k/description/

/*
- Create a map with cumulative sum as key and index as value
- if sum-k exists that means subarray exists, inc the count
- now inc the value of that sum in the dict
*/

public class Solution {
    public int SubarraySum(int[] nums, int k) {
        int count =0,sum=0;
        Dictionary<int,int> dict = new Dictionary<int,int>();
        dict[0]=1;
        for(int i =0;i<nums.Length;i++)
        {
            sum += nums[i];
            if(dict.ContainsKey(sum-k))
            {
                count += dict[sum-k];
            }

            if(!dict.ContainsKey(sum))
            {
                dict[sum]=1;
            }
            else
            {
                dict[sum]++;
            }
        }
        return count;
    }
}
