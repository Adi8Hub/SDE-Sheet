// https://leetcode.com/problems/palindromic-substrings

// Brute Force:
/*
- Find all the substrings
- Check for palindromic ones from the above

*/
public class Solution {
    public int CountSubstrings(string s) 
    {
        int n = s.Length;

        int count=0;

        for(int i =0;i<n;i++)
        {
            for(int j =i;j<n;j++)
            {
                if(isPalindrome(s,i,j))// Instead of generating substring and then checking for palindrome, we are directly passing the indexes to verify palindromic substring
                {
                    count++;
                }
            }
        }    
        return count;
    }

    bool isPalindrome(string s , int i, int j)
    {
        if(i>j)
        {
            return true;
        }

        if(s[i]==s[j])
        {    
            return isPalindrome(s,i+1,j-1);
        }
        
        return false;
    }
}



// Memo- TC: n^2 and SC: n^2

public class Solution {
    
    public int CountSubstrings(string s) 
    {
        int n = s.Length;

        int count=0;
        int[,] t = new int[n+1,n+1];
        for(int i=0;i<n+1;i++)
        {
            for(int j=0;j<n+1;j++)
            {
                t[i,j]=-1;
            }
        }

        for(int i =0;i<n;i++)
        {
            for(int j =i;j<n;j++)
            {
                if(isPalindrome(s,i,j,t))
                {
                    count++;
                }
            }
        }    
        return count;
    }

    bool isPalindrome(string s , int i, int j,int[,] t)
    {
        if(i>j)
        {
            return true;
        }

        if(t[i,j]!=-1)
        {
            // 0=false,1=true
            return (t[i,j]==1)? true:false;
        }
        if(s[i]==s[j])
        {    
            bool val = isPalindrome(s,i+1,j-1,t);
            if(val)
            {
                t[i,j]=1;
            }
            else
                t[i,j]=0;
            return val;
        }
        
        t[i,j]=0;
        return false;
    }
}



