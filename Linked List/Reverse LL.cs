/*
https://leetcode.com/problems/reverse-linked-list/
*/

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

//Recursive
public class Solution {
    public ListNode ReverseList(ListNode head) {
        if(head==null|| head.next==null) return head;

        ListNode last = ReverseList(head.next);
        head.next.next = head;
        head.next = null;
        return last;
    }
}
