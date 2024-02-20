// https://leetcode.com/problems/path-sum-iii

// O(n^2)
public class Solution {
    public int PathSum(TreeNode root, int targetSum) 
    {
        if(root == null) return 0;
        
        return CalculateSumFromThisNode(root, targetSum) 
            + PathSum(root.left, targetSum)//Move to next node
            + PathSum(root.right, targetSum);//Move to next node

    }
        int CalculateSumFromThisNode(TreeNode node, long sum)
        {
            var s = node.val == sum ? 1 : 0;

            if(node.left != null)
                s += CalculateSumFromThisNode(node.left, sum-node.val);

            if(node.right != null)
                s += CalculateSumFromThisNode(node.right, sum-node.val);

            return s;
        }
}

// Using Map - O(n)
public class Solution {
    
    int path=0;
    public int PathSum(TreeNode root, int targetSum) {
        if(root==null) return 0;

        Dictionary<long,int> map = new Dictionary<long,int>();
        map[0]=1;
        FindPath(root,targetSum,(long)0,map); 
        return path;
    }

    void FindPath(TreeNode root, int targetSum, long currSum, Dictionary<long,int> map)
    {
        if(root==null) return;

        currSum+=(long)root.val;
        if(map.ContainsKey(currSum-targetSum))
            path+=map[currSum-targetSum];

        if(map.ContainsKey(currSum))
           map[currSum]++;
        else
            map[currSum]=1;
    
        FindPath(root.left,targetSum,currSum,map); 
        FindPath(root.right,targetSum,currSum,map); 
        map[currSum]--;
    }
}
