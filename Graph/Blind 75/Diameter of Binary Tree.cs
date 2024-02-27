//  https://leetcode.com/problems/diameter-of-binary-tree


public class Solution {
    public int DiameterOfBinaryTree(TreeNode root) {
        if(root==null) return 0;
        int result = int.MinValue;
        depth(root,ref result);
        return result;
    }
    
    public int depth(TreeNode node, ref int res) {
        if(node==null)  return 0;

        int left = depth(node.left,ref res);
        int right = depth(node.right,ref res);

        res = Math.Max(res,left+right);

        return Math.Max(left,right)+1;

    }
}
