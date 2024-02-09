// https://leetcode.com/problems/largest-divisible-subset

// Recursion
public class Solution {
    public IList<int> LargestDivisibleSubset(int[] nums) {
        List<int> ans = new List<int>();
        List<int> temp = new List<int>();
        solve(nums,-1,0,ans,temp);
        return ans;
    }

    void solve(int[] nums,int prev,int curr,List<int> ans,List<int> temp)
    {
        if(curr>=nums.Length)
        {
            if(temp.Count>ans.Count)
            {
                ans.Clear();
                ans.AddRange(temp);
            }
            return;
        }

        if(prev==-1 || nums[curr]%nums[prev]==0)//Pick if first element of curr is divisible from prev
        {
            temp.Add(nums[curr]);
            solve(nums,curr,curr+1,ans,temp);
            temp.RemoveAt(temp.Count-1);//backtrack
        }

        //Not Pick
        solve(nums,prev,curr+1,ans,temp);
    }
}
