/*
https://leetcode.com/problems/group-anagrams/
*/

//1. Using Sorting
/*
- Take individual words out of string[], and sort them by taking char array
- Create a map of these sorted words, if sorted word found then add it to the list, else add key with original word
- Print the key's value iteratively

Time Complexity - n*klogk
*/
public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        int n = strs.Length;

        var result = new List<IList<string>>();
        var map = new Dictionary<string,List<string>>();
        for(int i =0;i<n;i++)//n
        {
            string temp = strs[i];

            char[] ch = temp.ToCharArray();
            Array.Sort(ch);//klogk
            temp = new string(ch);

            if(map.ContainsKey(temp))
            {
                map[temp].Add(strs[i]);
            }
            else
            {
                map.Add(temp,new List<string>());
                map[temp].Add(strs[i]);
            }
        }

        foreach(var item in map)
        {
            result.Add(item.Value);
        }

        return result;
    }
}
