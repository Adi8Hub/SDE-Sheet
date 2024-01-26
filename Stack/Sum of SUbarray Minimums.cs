https://leetcode.com/problems/sum-of-subarray-minimums/

O(n): TC n SC

public class Solution {
    public int SumSubarrayMins(int[] arr) {
        
        // Get NSL and NGL: using stack
        // From 0 to n: i-NSL , NSR-i. totalways is product of these two
        // sum is no.*totalways
        double mod = 1e9+7;
        int n = arr.Length;
        double totalSum = 0;
        int[] nsl = getNSL(arr);
        int[] nsr = getNSR(arr);

        for(int i =0;i<n;i++)
        {
            int ls = i-nsl[i];
            int rs = nsr[i]-i;

            double totalWays = ls*rs;
            double sum = totalWays*arr[i];

            totalSum = (totalSum+sum)%mod;
        }
        return (int)totalSum;
    }

    public int[] getNSL(int[] arr)
    {
        int n = arr.Length;
        int[] result = new int[n];
        Stack<int> st = new Stack<int>();

        for(int i =0;i<n;i++)
        {
            if(st.Count==0)
                result[i] = -1;
            else
            {
                while(st.Count>0 && arr[st.Peek()]>arr[i])
                {
                    st.Pop();
                }
                result[i] = (st.Count==0) ? -1: st.Peek();
            }

            st.Push(i);
        }

        return result;
    }

    public int[] getNSR(int[] arr)
    {
        int n = arr.Length;
        int[] result = new int[n];
        Stack<int> st = new Stack<int>();

        for(int i =n-1;i>=0;i--)
        {
            if(st.Count==0)
                result[i] = n;
            else
            {
                while(st.Count>0 && arr[st.Peek()]>=arr[i])
                {
                    st.Pop();
                }
                result[i] = (st.Count==0) ? n: st.Peek();
            }

            st.Push(i);
        }

        return result;
    }
}
