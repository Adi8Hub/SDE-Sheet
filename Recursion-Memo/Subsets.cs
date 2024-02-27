// https://leetcode.com/problems/subsets/description/

// Recur of all the indices and either pick or not pick at each index and traverse further for either of these 2 options
public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        IList<IList<int>> res = new List<IList<int>>();
        List<int> temp = new List<int>();
        solve(nums,0,res,temp);
        return res;
    }

    void solve(int[] nums, int idx,IList<IList<int>> res,List<int> temp )
    {
        // if idx traverses all the indices
        if(idx>=nums.Length)
        {
            res.Add(new List<int>(temp));
            return;
        }        
        //Pick
        temp.Add(nums[idx]);
        solve(nums,idx+1,res,temp);

        //Not Pick
        temp.RemoveAt(temp.Count-1);
        solve(nums,idx+1,res,temp);
    }
}
