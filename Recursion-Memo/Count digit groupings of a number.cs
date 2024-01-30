// https://www.geeksforgeeks.org/problems/count-digit-groupings-of-a-number1520/1

//{ Driver Code Starts
//Initial Template for C#

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverCode
{

    class GFG
    {
        static void Main(string[] args)
        {
            int testcases;// Taking testcase as input
            testcases = Convert.ToInt32(Console.ReadLine());
            while (testcases-- > 0)// Looping through all testcases
            {
                string str = Console.ReadLine();
                Solution obj = new Solution();
                int res = obj.TotalCount(str);
                Console.Write(res);
                Console.Write("\n");
          }

        }
    }
}

// } Driver Code Ends


//User function Template for C#

class Solution
    {
        //Complete this function
        //Function to count the total number of times 'z' appears in the given string.
        public int TotalCount(string str)
        {
            int n = str.Length;
            int[,] t = new int[101,1000];
            
            for(int i =0;i<101;i++)
            {
                for(int j =0;j<1000;j++)
                {
                    t[i,j]=-1;
                }
            }
            return solve(str,0,0,n,t);
            
        }
        
        public int solve(string str, int i , int prevSum,int n,int[,] t)
        {
            if(i>=n)
            {
                return 1;//Found 1 valid grouping
            }
            
            if(t[i,prevSum]!=-1)
                return t[i,prevSum];
                
            int result = 0;
            
            int currSum=0;
            
            for(int j =i;j<n;j++)
            {
                currSum+=(str[j]-'0');
                if(currSum>=prevSum)
                {
                    result+=solve(str,j+1,currSum,n,t);
                }
            }
            return t[i,prevSum]= result;
        }
    }
    
