/*
https://www.geeksforgeeks.org/problems/factorials-of-large-numbers2508/1
TC- O(n^2)

*/

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
                int N = Convert.ToInt32(Console.ReadLine());// Input for size of array
                Solution obj = new Solution();
                List<int> res = new List<int>();
                res = obj.factorial(N);
                for (int i = 0; i < res.Count; i++)
                {
                    Console.Write(res[i]);
                }
                Console.WriteLine();

            }

        }
    }
}

// } Driver Code Ends

class Solution
{
    //Complete this function
    public List<int> factorial(int N)
    {
        List<int> ans = new List<int>();        
        ans.Add(1);        
        for(int i =2;i<=N;i++)
        {
            reverseFactorial(ans,i);
        }
        
        ans.Reverse();
        return ans;
    }
    
    public void reverseFactorial(List<int> ans, int i)
    {
        int carry=0;
        for(int j=0;j<ans.Count;j++)
        {
            int prod= i*ans[j];
            ans[j] = (prod+carry)%10;
            carry = (prod+carry)/10;
        }
        
        //Remaining carry
        while(carry>0)
        {
            ans.Add(carry%10);
            carry/=10;
        }
    }
}
