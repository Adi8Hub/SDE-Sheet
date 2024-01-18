// https://leetcode.com/problems/insert-delete-getrandom-o1/

/*
 - To remove element from the index, get the last element to this index, and remove the last element from the list to avoid shifting

 - Use map to directly jump to desired index
*/

public class RandomizedSet {
    public List<int> list;
    public Dictionary<int,int> map ;
    public RandomizedSet() {
        list = new List<int>();
        map = new Dictionary<int,int>();        
    }
    
    public bool Insert(int val) 
    {
        if(map.ContainsKey(val))
        {
            return false;
        }

        list.Add(val);
        map.Add(val,list.Count-1);
        return true;
    }
    
    public bool Remove(int val) {
        if(!map.ContainsKey(val)) 
        {
            return false;
        }

        // To remove element from the index, get the last element to this index, and 
        // remove the last element from the list to avoid shifting
        int idx = map[val];
        int lastEl = list[list.Count-1];
        list[idx] = lastEl;
        list.RemoveAt(list.Count-1);
        map[lastEl]=idx;
        map.Remove(val);
        return true;
    }
    
    public int GetRandom() {
        int size = list.Count;
        Random rand = new Random();
        int idx = rand.Next(size);
        return list[idx];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */
