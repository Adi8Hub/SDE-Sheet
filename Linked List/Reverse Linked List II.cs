// https://leetcode.com/problems/reverse-linked-list-ii/description/

// Refer to video: https://www.youtube.com/watch?v=bRZ_Fy4zRRY


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
    public ListNode ReverseBetween(ListNode head, int left, int right) {
        if(head==null || head.next==null)
            return head;

        ListNode dummy = new ListNode(0,null);

        dummy.next = head;
        ListNode prev = dummy;
        for(int i =1;i<left;i++)
        {
            prev = prev.next;
        }

        ListNode curr= prev.next;

        for(int i =1;i<=(right-left);i++)//right-left => no of links to be reversed
        {
            ListNode temp = prev.next;
            prev.next = curr.next;
            curr.next = curr.next.next;
            prev.next.next = temp;
        }

        return dummy.next;
    }
}



// Another Approach - Using stack
