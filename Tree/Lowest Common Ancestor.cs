// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if(root==null)
            return null;

        if(root.val==p.val || root.val==q.val)
            return root;

        TreeNode left = LowestCommonAncestor(root.left,p,q);
        TreeNode right = LowestCommonAncestor(root.right,p,q);

        if(left!=null && right!=null)
            return root;

        if(left!=null)
            return left;
        
        return right;
    }
}
