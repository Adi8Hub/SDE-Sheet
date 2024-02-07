// https://leetcode.com/problems/sort-characters-by-frequency/

// Using Bucket Sort
// Create map of chars with its freq
// Create array of list ie.e bucket based on frequency where frequence can be at most be equal to the length of the string
// Put the values from the map in the bucket at intended frequence index
// traverse from right in the bucket and if its >0,take out the char and add i times, where i= that index or frequency
public class Solution {
    public string FrequencySort(string s) {
        Dictionary<char, int> map = new Dictionary<char, int>();
        foreach (char ch in s) {
            if (map.ContainsKey(ch))
                map[ch]++;
            else
                map[ch] = 1;
        }

        List<char>[] bucket = new List<char>[s.Length + 1];
        foreach (var entry in map) {
            char key = entry.Key;
            int freq = entry.Value;
            if (bucket[freq] == null)
                bucket[freq] = new List<char>();
            bucket[freq].Add(key);
        }

        StringBuilder sb = new StringBuilder();
        for (int i = bucket.Length - 1; i >= 0; i--) {
            if (bucket[i] != null) {
                foreach (char ch in bucket[i]) {
                    for (int j = 0; j < i; j++) {
                        sb.Append(ch);
                    }
                }
            }
        }
        return sb.ToString();
    }
}
