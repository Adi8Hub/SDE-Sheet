// https://leetcode.com/problems/lru-cache/

public class LRUCache 
{
    Node head = new Node(0,0);
    Node tail = new Node(0,0);

    Dictionary<int,Node> dict = new Dictionary<int,Node>();
    int capacity;

    public LRUCache(int capacity) 
    {
        this.capacity = capacity;
        head.next = tail;
        tail.prev = head;
    }
    
    public int Get(int key) 
    {
        if(dict.TryGetValue(key, out Node node))
        {
            Rem(node);
            Insert(node);
            return node.val;
        }
        else
        return -1;
    }
    
    public void Put(int key, int value) 
    {
        if(dict.TryGetValue(key, out Node node))
        {
            Rem(node);
        }
        if(dict.Count==capacity)
        {
            Rem(tail.prev);
        }
        Insert(new Node(key,value));
    }

    public void Insert(Node node)
    {
        dict[node.key] = node;
        node.next = head.next;
        node.prev = head;
        head.next = node;
        node.next.prev = node;
    }

    public void Rem(Node node)
    {
        dict.Remove(node.key);
        node.prev.next = node.next;
        node.next.prev = node.prev;
    }
    
    public class Node
    {
        public Node prev,next;
        public int key,val;

        public Node(int key,int val)
        {
            this.key = key;
            this.val = val;
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */

//  Use Dictionary to check if the element pre-exist.
//  Use DLL store the recently used items
