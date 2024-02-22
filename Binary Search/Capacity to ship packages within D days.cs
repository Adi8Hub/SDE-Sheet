// https://leetcode.com/problems/capacity-to-ship-packages-within-d-days/description/

// Brute Force
public class Solution {
    public int ShipWithinDays(int[] weights, int days) {
        int n = weights.Length;
        int left = int.MinValue;
        int right = 0;
        // left and right denotes minimum and maximum capacity
        for(int i = 0;i<n;i++)
        {
            left = Math.Max(left,weights[i]);
            right += weights[i];
        }

        for(int i = left;i<=right;i++)
        {
            int d = f(weights,i);
            if(d<=days)
            {
                return i;
            }
        }
        return 0;
    }

    int f(int[] weights, int capacity)
    {
        int days=1;
        int currWt = 0;

        for(int i =0;i<weights.Length;i++)
        {
            if(currWt+weights[i]<=capacity)
            {
                currWt+=weights[i];
                
            }
            else
            {
                currWt=weights[i];
                days++;
            }
        }
        return days;
    }
}


// Binary Search
public class Solution {
    public int ShipWithinDays(int[] weights, int days) {
        int n = weights.Length;
        int left = int.MinValue;
        int right = 0;
        for(int i = 0;i<n;i++)
        {
            left = Math.Max(left,weights[i]);
            right += weights[i];
        }

        while(left<=right)
        {
            int mid = left+(right-left)/2;
            int d = f(weights,mid);
            if(d<=days)
                right = mid-1;
            else
                left=mid+1;
        }
        return left;
    }

    int f(int[] weights, int capacity)
    {
        int days=1;
        int currWt = 0;

        for(int i =0;i<weights.Length;i++)
        {
            if(currWt+weights[i]<=capacity)
                currWt+=weights[i];    
            else
            {
                currWt=weights[i];
                days++;
            }
        }
        return days;
    }
}
