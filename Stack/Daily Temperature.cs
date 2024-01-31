// https://leetcode.com/problems/daily-temperatures/

// Next Greater element
public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
            Stack<int> s = new Stack<int>();
            int[] result = new int[temperatures.Length];

            for(int i = temperatures.Length - 1; i>=0;i--)
            {
                
                while(s.Count > 0 && temperatures[s.Peek()] <= temperatures[i])
                    s.Pop();

                result[i] = s.Count == 0 ? 0 : s.Peek() - i; 
                
                s.Push(i);
            }
            return result;
    }
}
