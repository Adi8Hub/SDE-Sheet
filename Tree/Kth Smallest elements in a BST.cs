// https://leetcode.com/problems/kth-smallest-element-in-a-bst/

// DFS
public class Solution {
        int kthNode=0;
        int count=0;
    public int KthSmallest(TreeNode root, int k) {
        dfs(root,k);
        return kthNode;
    }

    void dfs(TreeNode root, int k)
    {
        if(root==null) return ;

        // Inorder-left
        dfs(root.left,k);

        //Process root
        count++;
        if(count==k)
        {
            kthNode = root.val;
            return;
        }

        // Inorder-right
        dfs(root.right,k);
    }
}


// Iterative using Stack
public int KthSmallest(TreeNode root, int k) {
        int cur = 0;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        while (stack.Count > 0 || root != null) {
            if (root != null) {// move left 
                stack.Push(root);
                root = root.left;
            }
            else {//when null , pop from the stack ,and move to the right of popped node
                root = stack.Pop();
                if (++cur == k)
                    return root.val;
                root = root.right;
            }
        }
        return -1;
    }
