// https://leetcode.com/problems/is-subsequence


public class Solution {
    public bool IsSubsequence(string s, string t) {
        int m = t.Length;
        int n = s.Length;
        int i = 0, j = 0;

        while (i < m && j < n) {
            if (t[i] == s[j]) {
                j++;
            }
            i++;
        }

        return j == n;
    }
}
