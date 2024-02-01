// https://leetcode.com/problems/product-of-array-except-self/

// Use prefix and suffix array
// These array is product of prev products except self
// resultant product  is the product of prefix and suffix arrays
public class Solution {
    public int[] ProductExceptSelf(int[] nums) {

        int n = nums.Length;
        int[] pre = new int[n];
        int[] suf = new int[n];
        
        pre[0]=1;
        suf[n-1]=1;

        for(int i =1;i<n;i++)
        {
            pre[i] = pre[i-1]*nums[i-1];
        }

        for(int i =n-2;i>=0;i--)
        {
            suf[i] = suf[i+1]*nums[i+1];
        }

        int[] result = new int[n];
        for(int i =0;i<n;i++)
        {
            result[i] = suf[i]*pre[i];
        }
        return result;
    }
}
