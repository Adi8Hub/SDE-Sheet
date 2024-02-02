// https://leetcode.com/problems/sequential-digits

// Use BFS
// Add 1 to 8 in the Q intially,not 9 because it's +1 would be 10 which is 2 digits
// Traverse the Q and check if the elements is within the range
// If yes, add it to the result 
// For outside the range, get the remainder, do +1 and cehck if its<=9
// If yes, then add this +1 to the original dequeued element
// Add it back to the Q
public class Solution {
    public IList<int> SequentialDigits(int low, int high) {
        var result = new List<int>();

        Queue<int> q = new Queue<int>();

        for(int i =1;i<=9;i++)
        {
            q.Enqueue(i);
        }

        while(q.Count>0)
        {
            int temp = q.Dequeue();

            if(temp>=low && temp<=high)
            {
                result.Add(temp);

            }

            int lastdigit = temp%10;
            if(lastdigit+1<=9)
            {
                temp=temp*10+(lastdigit+1);
                q.Enqueue(temp);
            }
        } 
        return result;
    }
}
