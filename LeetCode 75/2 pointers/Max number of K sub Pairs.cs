// https://leetcode.com/problems/max-number-of-k-sum-pairs

// 2 pointers
public class Solution {
    public int MaxOperations(int[] nums, int k) {
        
        Array.Sort(nums);

        int left=0,right=nums.Length-1;
        int ans=0;
        while(left<right)
        {
            int sum = nums[left]+nums[right];

            if(sum==k)
            {
                ans++;
                left++;right--;
            }
            else if(sum<k)
                left++;
            else
                right--;

        }
        return ans;
    }
}


// Using dictionary
public class Solution {
    public int MaxOperations(int[] nums, int k) {
        int n = nums.Length;

        var map = new Dictionary<int,int>();

        //Fill the frequency
        for(int i=0;i<n;i++)
        {
            if(map.ContainsKey(nums[i]))
            {
                map[nums[i]]++;
            }
            else
            {
                map.Add(nums[i],1);
            }
        }
        int ans=0;
        // Traverse over map and check the count of it's complement
        foreach(var kv in map)
        {
            int complement = k-kv.Key;

            if(map.ContainsKey(complement))
            {
              // Take the min of the no's frequency and its complement's frequency
                ans+=Math.Min(map[complement],map[kv.Key]);
            }
        }
        return ans/2;// As result contains a to b operation and b to a operation, and we require only ato b operation
    }
}
