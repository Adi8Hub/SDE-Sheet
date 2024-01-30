// https://leetcode.com/problems/pseudo-palindromic-paths-in-a-binary-tree/

//Approach-1 (Simple and straight forward)
//T.C : O(n)
//S.C : O(1) (Ignoring stack recursive space, else S.C  will be O(Tree height))

class Solution {
    int path=0;
    public int pseudoPalindromicPaths (TreeNode root) {        
        int[] count = new int[10];
        solve(root, count);
        return path;        
    }

    public void solve(TreeNode root, int[] count)
    {        
        // Process node
        if(root==null)
            return;

        count[root.val]++;

        // last node of the path, check if at most 1 element has odd freq
        if(root.left==null && root.right==null)
        {   
            int oddfreq=0;
            for(int i =1;i<=9;i++)
            {                
                if(count[i]%2!=0)
                    oddfreq++;
            }
            if(oddfreq<=1)
                path++;
        }

        //Traverse left & right
        solve(root.left,count);
        solve(root.right,count);

        count[root.val]--;
    }
}


// 2. Bit Manipulation
//T.C : O(n)
//S.C : O(1) (I am ignoring stack recursive space, else S.C  will be O(height of tree))

class Solution {
    int path=0;
    public int pseudoPalindromicPaths (TreeNode root) {        
        int count=0;
        solve(root, count);
        return path;        
    }

    public void solve(TreeNode root, int count)
    {        
        // Process node
        if(root==null)
            return;

        count ^= (1<<root.val);//set the bit = root's val

        // last node of the path, check if at most 1 element has odd set bit
        // if 1 set bit, then its -1 will have all the bits reverse
        if(root.left==null && root.right==null)
        {   
            if((count & (count-1))==0)//e.g (count = 1 0 0 0)  and (count-1 = 0 1 1 1).. & operation will always be 0 
                path++;
        }

        //Traverse left & right
        solve(root.left,count);
        solve(root.right,count);
    }
}














