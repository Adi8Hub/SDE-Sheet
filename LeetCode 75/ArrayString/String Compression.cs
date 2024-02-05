//  https://leetcode.com/problems/string-compression

public class Solution {
    public int Compress(char[] chars) {
        int i = 0;
        int n = chars.Length;

        int currIdx=0;
        while(i<n)
        {
            int count=0;
            char currChar = chars[i];
            

            // Count repeating chars
            while(i<n && currChar==chars[i])
            {
                count++;
                i++;
            }

            // Assign char to the index and move to next index
            chars[currIdx++] = currChar;
            
            // If count>1, assign count to the index in string format
            if(count>1)
            {
                string cnt = count.ToString();

                foreach(var c in cnt)
                {
                    chars[currIdx++] = c;
                }
            }
        }
        return currIdx;

    }
}


