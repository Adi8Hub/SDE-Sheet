/*
https://leetcode.com/problems/lfu-cache/
*/


public class LFUCache 
{
    int capacity,currSize,minFreq;
    Dictionary<int,DLLNode> dict;
    Dictionary<int,DoublyLinkedList> freqDict;

    public LFUCache(int capacity) 
    {
        this.capacity = capacity;
        this.currSize = 0;
        this.minFreq = 0;

        dict = new Dictionary<int,DLLNode>();
        freqDict = new Dictionary<int,DoublyLinkedList>();
        
    }
    
    //Check in dict if exists or not. If yes, then increase its freq in freqDict
    public int Get(int key) 
    {
        if(dict.TryGetValue(key, out DLLNode currNode))
        {
            update(currNode);
            return currNode.val;
        }
        else
        return -1;
    }
    
    public void Put(int key, int value) 
    {
        if(capacity==0) return;

        if(dict.TryGetValue(key, out DLLNode currNode))
        {
            currNode.val = value;
            update(currNode);
        }
        else
        {
            currSize++;
            if(currSize > capacity)
            {
                DoublyLinkedList minFreqList = freqDict[minFreq];
                dict.Remove(minFreqList.tail.prev.key);
                minFreqList.RemoveNode(minFreqList.tail.prev);
                currSize--;
            }

            minFreq=1;
            DLLNode newNode = new DLLNode(key,value);
            DoublyLinkedList currList;
            if(freqDict.ContainsKey(1))
                currList = freqDict[1];
            else 
                currList = new DoublyLinkedList();

            currList.AddNode(newNode);
            freqDict[1] = currList;
            dict[key] = newNode;

        }
    }

    public void update(DLLNode node)
    {
        int currFreq = node.freq;
        DoublyLinkedList currList = freqDict[currFreq];
        currList.RemoveNode(node);

        if(currFreq==minFreq && currList.DLLSize==0) minFreq++;

        node.freq++;
        DoublyLinkedList newList;
        if(freqDict.ContainsKey(node.freq))
            newList = freqDict[node.freq];
        else
            newList = new DoublyLinkedList();

        newList.AddNode(node);
        freqDict[node.freq] = newList;
    }

    //1 item
    public class DLLNode
    {
        public DLLNode prev,next;
        public int key,val;
        public int freq;

        public DLLNode(int key,int val)
        {
            this.freq = 1;
            this.key = key;
            this.val = val;
        }
    }

    //List of items
    public class DoublyLinkedList
    {
        public int DLLSize;
        public DLLNode head;
        public DLLNode tail;

        public DoublyLinkedList()
        {
            this.DLLSize = 0;
            this.head = new DLLNode(0,0);
            this.tail = new DLLNode(0,0);
            head.next = tail;
            tail.prev = head;
        }

        public void AddNode(DLLNode nodeToAdd)
        {
            DLLNode nexNode = head.next;
            nodeToAdd.next = nexNode;
            nodeToAdd.prev = head;
            head.next = nodeToAdd;
            nexNode.prev = nodeToAdd;//re-visit...................nexNode.prev = nodeToAdd;
            DLLSize++;
        }

        public void RemoveNode(DLLNode nodeToRemove)
        {
            DLLNode pre = nodeToRemove.prev;
            DLLNode nex = nodeToRemove.next;
            pre.next = nex;
            nex.prev = pre;
            DLLSize--;
        }
        
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
