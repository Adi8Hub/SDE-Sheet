// https://leetcode.com/problems/remove-element


// Maintain a pointer to point to lastSameVal
// Iterate and check if pointer and val are same
// If not then swap and move the pointer
public class Solution {
    public int RemoveElement(int[] nums, int val) {
        int n = nums.Length;
        int sameValueIndex=0;
        for(int i =0;i<n;i++)
        {
            if(nums[i]!=val)
            {
                int temp = nums[i];
                nums[i] = nums[sameValueIndex];
                nums[sameValueIndex] = temp;
                sameValueIndex++;
            }
        }
        return sameValueIndex;
    }
}
