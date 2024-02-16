// https://leetcode.com/problems/longest-repeating-character-replacement/

// TC: O(n) SC: O(1)
public class Solution {
    public int CharacterReplacement(string s, int k) {
        int[] freq = new int[26];
        int mostFreqLetter = 0;
        int left = 0;
        int max = 0;
        
        for(int right = 0; right < s.Length; right++){
            freq[s[right] - 'A']++;
            mostFreqLetter = Math.Max(mostFreqLetter, freq[s[right] - 'A']);
            
            int lettersToChange = (right - left + 1) - mostFreqLetter;
            // if k=1, AABABB..mostfrqletter=B,right=6,left=1
            // then windowsize=6,letters to change = windowsize-mostfreq=6-4=2,which is more than k
            // then decrease window from left
            if(lettersToChange > k){
                freq[s[left] - 'A']--;
                left++;
            }
            
            max = Math.Max(max, right - left + 1);
        }
        
        return max;
    }
}
