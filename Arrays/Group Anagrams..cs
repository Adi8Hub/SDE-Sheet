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


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// 2 . Without Sorting---------Use frequency Array
//T.C. n*k
public class Solution {
    public string freqArray(string temp)
    {
        char[] ch = new char[26];

        for(int i =0;i<temp.Length;i++)
        {            
            ch[temp[i]-'a']++;
        }

        string newWord="";
        for(int i =0;i<26;i++)
        {    
            int freq = ch[i];        
            while(freq-->0)
            {
                char c =(char)(i+'a');
                newWord += c.ToString();
            }
        }
        return newWord; 
    }

    public IList<IList<string>> GroupAnagrams(string[] strs) {
        int n = strs.Length;
        var result = new List<IList<string>>();
        var map = new Dictionary<string,List<string>>();

        for(int i =0;i<n;i++)
        {
            string temp = strs[i];
            string newWord = freqArray(temp);

            if(map.ContainsKey(newWord))
            {
                map[newWord].Add(strs[i]);
            }
            else
            {
                map.Add(newWord,new List<string>());
                map[newWord].Add(strs[i]);
            }
        }

        foreach(var item in map)
        {
            result.Add(item.Value);
        }
        return result;
    }
}
