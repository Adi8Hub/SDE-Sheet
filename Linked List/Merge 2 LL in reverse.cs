// https://www.geeksforgeeks.org/problems/merge-2-sorted-linked-list-in-reverse-order/1
//
//  Steps: 1. Merge the 2 lists and then reverse the mergedList
//

//{ Driver Code Starts
import java.util.*;
import java.io.*;

class Node
{
    int data;
    Node next;

    Node(int d)
    {
        data = d;
        next = null;
    }
}


public class MainClass {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int t=scanner.nextInt();
        while(t-->0)
        {
            int N = scanner.nextInt();
            int M = scanner.nextInt();

            Node node1 = null;
            Node temp1 = null;
            for (int i = 0; i < N; i++) {
                int value = scanner.nextInt();
                Node newNode = new Node(value);
                if (node1 == null) {
                    node1 = newNode;
                    temp1 = node1;
                } else {
                    temp1.next = newNode;
                    temp1 = temp1.next;
                }
            }
    
            Node node2 = null;
            Node temp2 = null;
            for (int i = 0; i < M; i++) {
                int value = scanner.nextInt();
                Node newNode = new Node(value);
                if (node2 == null) {
                    node2 = newNode;
                    temp2 = node2;
                } else {
                    temp2.next = newNode;
                    temp2 = temp2.next;
                }
            }
    
            GfG gfg = new GfG();
            Node result = gfg.mergeResult(node1, node2);
    
            printList(result);
        }
    }

    static void printList(Node node) {
        while (node != null) {
            System.out.print(node.data + " ");
            node = node.next;
        }
        System.out.println();
    }
}

// } Driver Code Ends


/* Structure of the node*/
/* class Node
{
	int data;
	Node next;
	
	Node(int d)
	{
		data = d;
		next = null;
	}
} */

class GfG
{
    public Node MergeTwoLists(Node l1, Node l2) {
        if (l1 == null) return l2;
        if (l2 == null) return l1;

        Node result;

        if(l1.data < l2.data)
        {
            result = l1;
            result.next = MergeTwoLists(l1.next,l2);
        }
        else
        {
            result = l2;
            result.next = MergeTwoLists(l1,l2.next);
        }

        return result;
    } 
    
    public Node ReverseList(Node head) {
        if(head==null|| head.next==null) return head;

        Node last = ReverseList(head.next);
        head.next.next = head;
        head.next = null;
        return last;
    }
    
    public Node mergeResult(Node node1, Node node2)
    {
	// Your code here	
	    Node mergeList = MergeTwoLists(node1, node2);
	    
	    var reverseList = ReverseList(mergeList);
	    
	    return reverseList;
    }
}
