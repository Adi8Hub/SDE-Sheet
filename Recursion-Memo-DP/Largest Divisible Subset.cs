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


// 2. Bottom -UP DP
// TC/SC n^2 and n
public class Solution {
    public IList<int> LargestDivisibleSubset(int[] nums) 
    {
        int n = nums.Length;
        // LIS - Longest Increasing Subsequence
        Array.Sort(nums);

        int[] LIS = new int[n];// gives lIS length
        int[] prev = new int[n];//tracks prev Index < currindex at curr location
        int maxLength=1;
        int lastIndex=-0
        Array.Fill(LIS,1);
        Array.Fill(prev,-1);

        for(int i=0;i<n;i++)
        {
            for(int j=0;j<i;j++)
            {
                if(nums[i]%nums[j]==0)//in LIS problems, we check for greater no,here as per Q,we check divisibility
                {
                    if(LIS[i]<LIS[j]+1)//Update LIS and prev
                    {
                        LIS[i] = LIS[j]+1;
                        prev[i] = j;
                    }

                    //Track maxLength
                    if(LIS[i]>maxLength)
                    {
                        maxLength = LIS[i];
                        lastIndex = i;
                    }
                }
            }
        }

        List<int> ans = new List<int>();
        while(lastIndex>=0)
        {
            ans.Add(nums[lastIndex]);
            lastIndex = prev[lastIndex];
        }
        return ans;
    }
}
