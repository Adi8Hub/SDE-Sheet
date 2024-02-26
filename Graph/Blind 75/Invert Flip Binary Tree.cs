// https://leetcode.com/problems/invert-binary-tree

// DFS Traversal
public class Solution {
    public TreeNode InvertTree(TreeNode root) {
        if(root==null)
            return null;

        TreeNode left = root.left;
        TreeNode right = root.right;

        root.left = InvertTree(right);
        root.right = InvertTree(left);

        return root;
    }
}

//*****************************************************


//  Using stack
public class Solution {
    public TreeNode InvertTree(TreeNode root) {
        if(root==null)
            return null;

        Stack<TreeNode> st = new Stack<TreeNode>();
        st.Push(root);

        while(st.Count>0)
        {
            TreeNode curr = st.Pop();

            //swap left and right child
            TreeNode temp = curr.left;
            curr.left = curr.right;
            curr.right=temp;

            // Add left & right child in stack
            if(curr.left!=null)
                st.Push(curr.left);
            if(curr.right!=null)
                st.Push(curr.right);
        }
        return root;
    }
}


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// BFS

public class Solution {
    public TreeNode InvertTree(TreeNode root) {
        if(root==null)
            return null;

        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while(q.Count>0)
        {
            TreeNode curr = q.Dequeue();

            //swap left and right child
            TreeNode temp = curr.left;
            curr.left = curr.right;
            curr.right=temp;

            // Add left & right child in stack
            if(curr.left!=null)
                q.Enqueue(curr.left);
            if(curr.right!=null)
                q.Enqueue(curr.right);

        }
        return root;
    }
}
