// https://leetcode.com/problems/evaluate-reverse-polish-notation


public class Solution {
    public int EvalRPN(string[] tokens) {
        
        if (tokens == null || tokens.Length == 0)
            return 0;
        
        Stack<int> stk = new Stack<int>();
        
        foreach(var token in tokens)
        {
            if(token == "+" || token == "-" || token == "*" || token == "/")
            {
                int num1 = stk.Pop();
                int num2 = stk.Pop();
                
                switch(token)
                {
                    case "+" : 
                        stk.Push(num1 + num2);
                        break;
                    case "-" : 
                        stk.Push(num2 - num1);
                        break;
                    case "*" : 
                        stk.Push(num1 * num2);
                        break;
                    case "/" : 
                        stk.Push(num2/num1);
                        break;
                }
            }
            else
                stk.Push(Convert.ToInt32(token));
        }
        
        return stk.Peek();
    }
}
