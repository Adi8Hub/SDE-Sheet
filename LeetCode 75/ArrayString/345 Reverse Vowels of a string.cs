// https://leetcode.com/problems/reverse-vowels-of-a-string/

public class Solution {
    public string ReverseVowels(string s) {        
        int l = 0;
        int r = s.Length-1;
        char[] ch = s.ToCharArray();

        while(l<r)
        {
            while(l<r && !isVowel(s[l])) l++;
            while(l<r && !isVowel(s[r])) r--;

            char temp = ch[l];
            ch[l]=ch[r];
            ch[r] = temp;    

            l++;r--;        
        }

        string result = new string(ch);
        return result;
    }

    public bool isVowel(char c)
    {
        if(c=='a'|| c=='e'|| c=='i' || c=='o'|| c=='u'|| c=='A'|| c=='E'|| c=='I'|| c=='O'|| c=='U')
            return true;
        
        return false;
    }
}
