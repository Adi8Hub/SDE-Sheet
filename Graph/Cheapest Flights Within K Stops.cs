// https://leetcode.com/problems/cheapest-flights-within-k-stops

//Approach-1 (BFS)
//T.C : O(V+E) - BFS traversal of Graph
//S.C : O(V+E)
public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        
        // 1. Convert adj matrix to Adj List
        Dictionary<int,List<int[]>> adj = new Dictionary<int,List<int[]>>();
        foreach(int[] f in flights)
        {
            int u = f[0];
            int v = f[1];
            int d = f[2];

            if(!adj.ContainsKey(u))
            {
                adj[u] = new List<int[]>();
            }
            
            adj[u].Add(new int[]{v,d});
        } 
        // End of 1

        // 2. Track minimum distance of each vertex using minDIst array
        // Initially set it as maxVal and src cell as 0
        int[] minDist = new int[n];
        Array.Fill(minDist,int.MaxValue);
        minDist[src] = 0;

        // 3. Use queue to add To_Vertex and minimum distance if less than previously found min distance
        Queue<int[]> q = new Queue<int[]>();
        q.Enqueue(new int[]{src,0});

        // 4. As maxK stops allowed,hence track stops using this variable
        int stops = 0;

        while(q.Count>0  && stops<=k)
        {
            int qSize = q.Count;
            while(qSize-- > 0)
            {
                int[] curr = q.Dequeue();
                int u = curr[0];
                int d = curr[1];// distance till u_vertex
                
                if(adj.ContainsKey(u))
                {
                    foreach(int[] neighbor in adj[u])
                    {
                        int v = neighbor[0];
                        int dist = neighbor[1];//distance till v,as of now

                        if((d + dist) < minDist[v] )//(distance till u + distance from u to v) < distance till v earlier 
                        {
                            minDist[v] = d + dist;
                            q.Enqueue(new int[]{v,d+dist});
                        }
                    }
                }                
            }
            stops++;
        }
        return (minDist[dst]==int.MaxValue)? -1 : minDist[dst];
    }
}
