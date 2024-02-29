// https://leetcode.com/problems/even-odd-tree

//Approach-1 (When we deal with level, always first think of BFS)
//T.C : O(n)
//S.C : O(n)
public class Solution {
    public bool IsEvenOddTree(TreeNode root) {
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        bool evenlvl = true;

        while(q.Count>0)
        {
            int size = q.Count;
            int pre = evenlvl? int.MinValue:int.MaxValue;
            // Traversing level by level
            while(size-->0)
            {
                TreeNode curr = q.Dequeue();
                if(evenlvl)
                {
                    if(curr.val<=pre || curr.val%2==0) return false;
                } 
                else//oddlevel
                {
                    if(curr.val>=pre || curr.val%2==1) return false;
                }

                // set previous to curr value for next queued node
                pre = curr.val;

                if(curr.left!=null)
                    q.Enqueue(curr.left);
                if(curr.right!=null)
                    q.Enqueue(curr.right);
            }
            // as the level changes, it will switch to either odd or even
            evenlvl = !evenlvl;
        }
        return true;
    }
}
