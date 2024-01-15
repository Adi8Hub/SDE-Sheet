/*
https://leetcode.com/problems/top-k-frequent-elements/
*/

// Using Min Heap to get top or max elements
// TC: nlogk
// SC: n+k

public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        int n = nums.Length;

        //-----------------------    1. Build frequency map      --------------------//
        Dictionary<int,int> freqMap = new Dictionary<int,int>();

        for(int i =0;i<n;i++)
        {
            if(freqMap.ContainsKey(nums[i]))
            {
                freqMap[nums[i]]++;
            }
            else
            {
                freqMap[nums[i]]=1;
            }
        }
        //----------------------------------------------------------------------------//

      
        //--------------------    2. Build Priority Queue (Min-Heap)     -------------//
        PriorityQueue<int,int> pq = new PriorityQueue<int,int>();

        foreach(var key in freqMap.Keys)
        {
            pq.Enqueue(key,freqMap[key]);

            if(pq.Count>k)
                pq.Dequeue();
        }
        //---------------------------------------------------------------------------//
      
        //--------------------       3. Fill result array           -----------------//
        int[] result = new int[k];
        int idx =k;

        while(pq.Count>0)
        {
            result[--idx]=pq.Dequeue();
        }
        //---------------------------------------------------------------------------//
        return result;
    }
}

//********************************************************************************************

//----------------------------      2. Bucket Sort      ------------------------------------------
public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        int n = nums.Length;

        //  1. Build frequency map
        Dictionary<int,int> freqMap = new Dictionary<int,int>();

        for(int i =0;i<n;i++)
        {
            if(freqMap.ContainsKey(nums[i]))
            {
                freqMap[nums[i]]++;
            }
            else
            {
                freqMap[nums[i]]=1;
            }
        }

        //  2. Use bucket sort.  Use freq as index in bucket
        List<int>[] bucket = new List<int>[n+1];

        foreach(var num in freqMap.Keys)
        {
            int freq = freqMap[num];

            if(bucket[freq]==null)
            {
                bucket[freq] = new List<int>();
            }            
            bucket[freq].Add(num);                       
        }

        //3. Fill result array
        List<int> result = new List<int>();

        for(int i = bucket.Length-1;i>=0 && result.Count<k;i--)
        {   
            if(bucket[i]!=null)
            {
                result.AddRange(bucket[i]);
            }
        }

        return result.ToArray();
    }
}







//**********************************************************************************************
////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*
//      Step 1: Build the frequency map of elements in the nums array
        Dictionary<int, int> freqMap = new Dictionary<int, int>();max heap to find max
        foreach (var num in nums) {
            if (freqMap.ContainsKey(num))
                freqMap[num]++;
            else
                freqMap[num] = 1;
        }

        // Step 2: Prepare a list of lists to store elements with the same frequency
        List<int>[] buckets = new List<int>[nums.Length + 1];
        foreach (var num in freqMap.Keys) {
            int freq = freqMap[num];
            if (buckets[freq] == null)
                buckets[freq] = new List<int>();
            buckets[freq].Add(num);
        }

        // Step 3: Build the result array from buckets in descending order of frequency
        List<int> result = new List<int>();
        for (int i = buckets.Length - 1; i >= 0 && result.Count < k; i--) {
            if (buckets[i] != null)
                result.AddRange(buckets[i]);
        }

        // Step 4: Convert the result list to an array and return
        return result.ToArray();

--------------------------------------
                            // Using Priority Queue with Max Heap

                     
        var dict = new Dictionary<int, int>();
        var pq = new PriorityQueue<int,int>(Comparer<int>.Create((a,b)=>b-a));
        var res = new int[k];

        foreach(var num in nums)
            if (!dict.TryAdd(num, 1))
                dict[num]++;

        foreach(var pair in dict)
            pq.Enqueue(pair.Key, pair.Value);

        for(int i = 0; i < k; i++)
            res[i] = pq.Dequeue();

        return res;

        -----------------------------------------------------------------
        
                                Priority Queue (Min - Heap)
                                
                                Time complexity: O(n∗logk)
                                Space Complexity: O(n+k)


        Dictionary<int, int> freqMap = new();
        for(int i = 0; i < nums.Length; i++) {
            if (freqMap.ContainsKey(nums[i]))
                freqMap[nums[i]]++;
            else
                freqMap[nums[i]] = 1;
        }

        PriorityQueue<int, int> pq = new();
        foreach(var key in freqMap.Keys) {
            pq.Enqueue(key, freqMap[key]);
            if (pq.Count > k)
                pq.Dequeue();
        }

        int[] res = new int[k];
        int j = k;

        while (pq.Count > 0)
            res[--j] = pq.Dequeue();

        return res;
*/
////////////////////////////////////////////////////////////////////////////////////////////////////////////
