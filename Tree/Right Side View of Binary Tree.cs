// https://leetcode.com/problems/binary-tree-right-side-view

// DFS traversal
// Modified preorder-Root, Right, Left
public class Solution {
    public IList<int> RightSideView(TreeNode root) {
        if(root==null)
            return new List<int>();
        
        var result = new List<int>();
        int lvl = 1;
        dfs(root,lvl, result);
        return result;
    }

    void dfs(TreeNode root, int lvl, IList<int> result)
    {
        if(root==null)
            return;
        if(result.Count < lvl)
            result.Add(root.val);

        dfs(root.right,lvl+1,result);
        dfs(root.left,lvl+1,result);

    }
}


// Level Order Traversal
public class Solution {
    public IList<int> RightSideView(TreeNode root) {
        if(root==null)
            return new List<int>();
        
        var result = new List<int>();
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while(q.Count>0)
        {
            int n = q.Count;
            TreeNode node = null;
            while(n-->0)
            {
                node = q.Dequeue();

                if(node.left!=null)
                {
                    q.Enqueue(node.left);
                }

                if(node.right!=null)
                {
                    q.Enqueue(node.right);
                }
            }
            result.Add(node.val);
        }
        return result;
    }    
}
