// https://leetcode.com/problems/merge-strings-alternately/

/*
Take a pointer, add element of that pointer from word1 and then word2

*/

public class Solution {
    public string MergeAlternately(string word1, string word2) {
        StringBuilder ans = new StringBuilder();
        int w1= 0;
        // int w2=0;
       
        while(w1<Math.Max(word1.Length,word2.Length))
        {
            if(w1<word1.Length)
            {

            ans.Append(word1[w1]);
            
            
            }
            if(w1<word2.Length)
            {
                ans.Append(word2[w1]);
                

            }
            w1++;
            
        }
        return ans.ToString();
    }
}
