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


//  Bottom-Up DP
/*
traverse from length 1 to n
    traverse i from 0 to i+l-1 . Here j becomes i+l-1, as above loop gives length as l,hence current substring starts from i and ends at j=i+l-1(-1 ==> 0-based indexing)
        - For 1 length substring t[i,i]=1 as 1 lenght substring is palindrome
        - For 2 length, i.e. i+1==j, if same chars then palindrome
        - For >2 length, if(s[i]==s[j] && remaining i.e., from i+1 to j-1 is palindrome, then i to j is palindrome
*/

public class Solution {
    
    public int CountSubstrings(string s) 
    {
        int n = s.Length;
        int count=0;
        bool[,] t = new bool[n,n];

        for(int l=1;l<=n;l++)
        {
            for(int i =0;i+l-1<n;i++)//0-based
            {
                int j =i+l-1;// substring starts from i and ends at j with length l

                if(i==j)// 1-length palindrome
                {
                    t[i,j] = true;
                }
                else if(i+1 == j)//2-length palindrome
                {
                    if(s[i] == s[j])
                        t[i,j] = true;
                    else
                        t[i,j] = false;
                }
                else// more than 2 length substring, check if left end and right are same and in-between substring is plaindrome 
                {
                    t[i,j] = (s[i]==s[j] && t[i+1,j-1]);
                }

                if(t[i,j])
                    count++;                
            }    
        }        
        return count;
    }
}


// Better Approach: TC: n^2 SC: 1
// Find plaindrome count based on index as center, if length id odd then check for i, if even then check for i and (i+1)
public class Solution {    
    int count=0;
    public int CountSubstrings(string s) 
    {
        int n = s.Length;
        /*
         * Every single character in the string is a center for possible odd-length
         * palindromes: check(s, i, i); Every pair of consecutive characters in the
         * string is a center for possible even-length palindromes: check(s, i, i+1);
         */
        for (int i = 0; i < n; i++) {
            check(s, i, i, n);// Odd-length palindrome ,hence center would be i
            check(s, i, i + 1, n);//Even length palindrome,hence center would be i,i+1
        }
        return count;
    }

    void check(string s, int i , int j, int n)
    {
        while(i>=0 && j<n && s[i]==s[j])
        {
            count++;
            i--;
            j++;
        }
        
    }
}
