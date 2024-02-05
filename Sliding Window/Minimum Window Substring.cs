// https://leetcode.com/problems/minimum-window-substring

public class Solution {
    public string MinWindow(string s, string t) {
        int n = s.Length;
        int required = t.Length;

        int left=0,right=0;

        // Fill the map with t char count
        Dictionary<char,int> map = new Dictionary<char,int>();
        foreach(var str in t)
        {
            if(map.ContainsKey(str))
            {
                map[str]++;
            }
            else
            {
                map.Add(str,1);
            }
        }

        int minWindow=int.MaxValue;
        int minStart=0;

        //Traverse the string s and operate on the map
        while(right<n)
        {
            char c = s[right];

            // if currChar is encountered then reduce the required Count and count in the map
            if(map.ContainsKey(c) && map[c]>0)// signifies that it was part of t and still available to be added in the window
                required--;

            if(map.ContainsKey(c))
            {
                map[c]--;
            }
            else
            {
                map.Add(c,-1);
            }

            // After changing the required Count, if it becomes 0, then it implies we have encountered all chars of t
            // Now we can check if the window can be reduced
            while(required==0)
            {
                // First get the min window length and the start point of this window
                if(minWindow>right-left+1)
                {
                    minWindow = right-left+1;
                    minStart = left;
                }

                char curr = s[left];// left pointer of the window to be removed while shrinking the window

                // When removing the char from the window, increase its count in the map
                // Check if the count>0,if yes, increase the required as it was part of t and has now been removed from the window
                map[curr]++;
                if(map.ContainsKey(curr) && map[curr]>0)
                {
                    required++;
                }
                left++;
            }
            right++;
            
        }
        if(minWindow==int.MaxValue)
            return "";

        return s.Substring(minStart,minWindow);
    }
}
