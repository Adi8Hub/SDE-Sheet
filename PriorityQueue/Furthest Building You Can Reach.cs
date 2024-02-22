// https://leetcode.com/problems/furthest-building-you-can-reach/

public class Solution {
    public int FurthestBuilding(int[] heights, int bricks, int ladders) {
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
        for (int i = 0; i < heights.Length - 1; i++) {
            if (heights[i] >= heights[i + 1]) continue;
            bricks -= heights[i + 1] - heights[i];
            pq.Enqueue(heights[i + 1] - heights[i], heights[i + 1] - heights[i]);
            if (bricks < 0) {
                bricks += pq.Dequeue();
                if (ladders > 0) ladders--;
                else return i;
            }
        }
        return heights.Length - 1;
    }
}
