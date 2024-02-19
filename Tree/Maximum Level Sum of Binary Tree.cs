// https://leetcode.com/problems/maximum-level-sum-of-a-binary-tree


// BFS
public class Solution {
    public int MaxLevelSum(TreeNode root) {
        int maxSum = int.MinValue;
        int maxSumLevel = 0;
        int currLevel = 1;

        //BFS
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while(q.Count>0)
        {
            int n = q.Count;
            int currSum = 0;
            while(n-- > 0)
            {
                var node = q.Dequeue();
                currSum+=node.val;
                if(node.left!=null)
                {
                    q.Enqueue(node.left);
                }

                if(node.right!=null)
                {
                    q.Enqueue(node.right);
                }
            }
            if(currSum>maxSum)
            {
                maxSum = currSum;
                maxSumLevel = currLevel;
            }
            currLevel++;
        }
        return maxSumLevel;
    }
}


// DFS
public class Solution {
    public int MaxLevelSum(TreeNode root) {
        var map = new Dictionary<int,int>();
        int currLevel=1;
        int maxSum = int.MinValue;
        int maxSumLevel=0;

        dfs(root,currLevel,map);
        foreach(var items in map)
        {
            int level = items.Key;
            int sum = items.Value;

            if(sum>maxSum)
            {
                maxSum = sum;
                maxSumLevel = level;
            }
        }
        return maxSumLevel;
        
    }

    // Use dfs to fill map with sum level-wise
    void dfs(TreeNode root, int currLevel, Dictionary<int,int> map)
    {
        if(root==null)
            return;
        
        if(!map.ContainsKey(currLevel))
            map[currLevel]=0;

        map[currLevel] += root.val;
        dfs(root.left,currLevel+1,map);
        dfs(root.right,currLevel+1,map);

    }
}
