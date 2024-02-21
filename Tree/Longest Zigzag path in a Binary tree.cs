// https://leetcode.com/problems/longest-zigzag-path-in-a-binary-tree/


//Approach-1 (Basic Code - Trying left and right direction and call them)
public class Solution {
    int path = 0;
    public int LongestZigZag(TreeNode root) 
    {
        int steps=0;
        bool dir = true;// true->left, false->right
        dfs(root,dir,steps);    
        // dfs(root,!dir,steps);  
        return path;  
    }
    // (go to this node,change the direction or move to different direction for next iteration,increase the step if moving to opposite direction)
    void dfs(TreeNode root, bool dir, int steps)
    {
        if(root==null)
            return;

        path = Math.Max(path, steps);
        if(dir)// left direction
        {
            dfs(root.left,!dir,steps+1);
            dfs(root.right,dir,1);
        }
        else// right direction
        {
            dfs(root.right,!dir,steps+1);
            dfs(root.left,dir,1);
        }
    }
}
