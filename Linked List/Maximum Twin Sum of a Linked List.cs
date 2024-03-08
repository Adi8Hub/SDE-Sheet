// https://leetcode.com/problems/maximum-twin-sum-of-a-linked-list/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public int PairSum(ListNode head) {
        if(head.next.next==null)
            return head.val+head.next.val;
        
        // Approach 2: Put all the nodes in stack and keep counting size,
        // Then traverse from head to N/2, and calculate sum of curr and stack top
        Stack<int> st = new Stack<int>();
        int count=0;
        ListNode curr = head;
        while(curr!=null)
        {
            st.Push(curr.val);
            count++;
            curr=curr.next;
        }
        count/=2;
        int maxSum=0;
        while(count-->0)
        {
            int currSum = head.val+st.Pop();
            maxSum = Math.Max(currSum,maxSum);
            head= head.next;
        }
        return maxSum;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Approach 1: Save LL in a list/array and traverse from left&right

        int maxSum=0;
        List<int> temp = new List<int>();
        while(head!=null)
        {
            temp.Add(head.val);
            head = head.next;
        }

        int i = 0,j=temp.Count-1;
        while(i<j)
        {
            int currSum = temp[i++]+temp[j--];
            maxSum = Math.Max(currSum,maxSum);
        }
        return maxSum;
        
    }
}
