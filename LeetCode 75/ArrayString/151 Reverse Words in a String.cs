// https://leetcode.com/problems/reverse-words-in-a-string/

// Using Regular Expression

// Use Trim - to remove left and right end spaces
// Regex.Replace(string,@"\s+"," ") replaces multiple spaces with single space
// Then split on the basis of space
using System.Text.RegularExpressions;

public class Solution {
    public string ReverseWords(string s) {
        s = s.Trim();
        String[] str  = Regex.Replace(s,@"\s+"," ").Split(" ");

        String ans = "";
        
        for (int i = str.Length - 1; i > 0; i--) 
        {            
            ans += str[i] + " ";
        }
        return ans+=str[0];      
    }
}





// SPlit method


// Using Split method on the basis of space and 
// removing empty entries using  StringSplitOptions.RemoveEmptyEntries

public class Solution {
    public string ReverseWords(string s) {
        
        string[] str = s.Split(' ',StringSplitOptions.RemoveEmptyEntries);


        String ans = "";
        
        for (int i = str.Length - 1; i > 0; i--) 
        {            
            ans += str[i] + " ";
        }
        return ans+=str[0];      
    }
}
