// https://leetcode.com/problems/substring-with-concatenation-of-all-words

/*
The time complexity of the given code is O(m * k) where m is the length of the string s and k is the length of each word within the words list. 

The space complexity is O(n * k) where n is the number of words in the given list words and k is the length of each word. 
This is due to two counters cnt and cnt1 storing, at most, n different words of k length each, 
along with the list ans that in the worst case could store up to m / k starting indices if every substring is a valid concatenation.

*/
public class Solution {
    public IList<int> FindSubstring(string s, string[] words) {
        Dictionary<string,int> count = new Dictionary<string,int>();
        // 1. Put array of strings in a map with its frequency
        foreach(var w in words)
        {
            count[w] = count.GetValueOrDefault(w,0)+1;
        } 

        int wordCount = words.Length;
        int eachWordLength = words[0].Length;
        int n = s.Length;
        List<int> indices = new List<int>();

        for(int i =0;i<eachWordLength;i++)
        {
            int left = i;
            int right = i;
            int totalWords = 0;
            Dictionary<string,int> currSeen = new Dictionary<string,int>();

            while(right+eachWordLength<=n)
            {
                string sub = s.Substring(right,eachWordLength);
                right+=eachWordLength;

                if(!count.ContainsKey(sub))
                {
                    // If substring is not part of thr array, then :
                    // 1. move left
                    // 2. clear the current dictionary
                    // 3. set totalCount to 0
                    currSeen.Clear();
                    left=right;
                    
                    totalWords=0;
                    continue;
                }

                // when substring is present, increase current map count and totalCount
                currSeen[sub] = currSeen.GetValueOrDefault(sub,0)+1;
                totalWords++;

                // if curr word count > actual count, then:
                // 1. To shrink the window from left, move left
                // 2. decrease the count of the substring from left
                // 3. decrease the totalCount
                while(currSeen[sub] > count[sub])
                {
                    string toRemove = s.Substring(left,eachWordLength);
                    left += eachWordLength;
                    currSeen[toRemove]--;
                    totalWords--;
                }

                if(totalWords==wordCount)
                    indices.Add(left);
            }
        }
        return indices; 
    }
}
