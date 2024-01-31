// https://leetcode.com/problems/greatest-common-divisor-of-strings/

public class Solution {
    public string GcdOfStrings(string str1, string str2) {
        if(str1.Length<str2.Length)
            return GcdOfStrings(str2,str1);

        if(str1.Equals(str2)) return str2;

        if(str1.StartsWith(str2))
            return GcdOfStrings(str1.Substring(str2.Length),str2);

        return "";
    }
}


//Using GCD length
public class Solution {
    public string GcdOfStrings(string str1, string str2) {
                
        // Check if concatenated resultant string in both directions gives equal value or not
        if(!string.Equals(str1+str2, str2+str1)) return "";

        int s1 = str1.Length;
        int s2 = str2.Length;

        int gcdLength = gcd(s1,s2);
        return str1.Substring(0,gcdLength);

    }

    public int gcd(int s1,int s2)
    {
        if(s2==0) return s1;
        return gcd(s2,s1%s2);
    }
}
