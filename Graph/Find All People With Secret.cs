// https://leetcode.com/problems/find-all-people-with-secret/description

// BFS
//T.C : ~O(M*(M+N)) where M = number of meetings and N = number of people
//S.C : O(M+N)
public class Solution {
    public List<int> FindAllPeople(int n, int[][] meetings, int firstPerson) 
    {
        SortedDictionary<int, List<int[]>> timeMeetings = new SortedDictionary<int, List<int[]>>();
        bool[] knowsSecret = new bool[n];
        knowsSecret[0]=true;
        knowsSecret[firstPerson]=true;
        
        // Fill map from the matrix
        foreach(var meeting in meetings)
        {
            int x = meeting[0];
            int y = meeting[1];
            int t = meeting[2];

            if(!timeMeetings.ContainsKey(t))
                timeMeetings[t] = new List<int[]>();

            timeMeetings[t].Add(new int[]{x,y});
        }

        // Create graph for each time using adj list 
        // Add starting point for each graph 
        // BFS traversal for each graph
        foreach(var t in timeMeetings.Keys)
        {
            Dictionary<int,List<int>> meetingAdjList = new Dictionary<int,List<int>>();
            foreach(var meets in timeMeetings[t])
            {
                int x = meets[0];
                int y = meets[1];

                if(!meetingAdjList.ContainsKey(x))
                {
                    meetingAdjList[x] = new List<int>();
                }
                meetingAdjList[x].Add(y);

                if(!meetingAdjList.ContainsKey(y))
                {
                    meetingAdjList[y] = new List<int>();
                }
                meetingAdjList[y].Add(x);
            }

            // Add starting person in a set to avoid duplicates, using the map
            HashSet<int> start = new HashSet<int>();
            foreach(var m in timeMeetings[t])
            {
                if(knowsSecret[m[0]])
                    start.Add(m[0]);

                if(knowsSecret[m[1]])
                    start.Add(m[1]);
            }

            // BFS traversal--> next person who knows the secret to be added to Queue
            Queue<int> q = new Queue<int>(start);
            while(q.Count>0)
            {
                int person = q.Dequeue();
                if(meetingAdjList.ContainsKey(person))
                {
                    foreach(int nextPerson in meetingAdjList[person])
                    {
                        if(!knowsSecret[nextPerson])
                        {
                            knowsSecret[nextPerson] = true;
                            q.Enqueue(nextPerson);
                        }
                    }
                }                
            }

        }

        List<int> ans = new List<int>();
        for(var i=0;i<n;i++)
        {
            if(knowsSecret[i])
                ans.Add(i);
        }
        return ans;        
    }
}
//************************************************************************************************************************************************************************
// BFS traversal and storing Pairs
//T.C : O(M * (M+N)) -> M = Number of meetings, N = number of people, there can be at most N+M elements in the queue and a person may have M neighbours
//S.C : O(M+N)
public class Solution {
    public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson) {
        // 1. Make adjacency list for graph with values containing 
        // Pair--> (Person,time)
        Dictionary<int,List<(int,int)>> adj = new Dictionary<int,List<(int,int)>>();
        foreach(int[] meeting in meetings)
        {
            int p1 = meeting[0];
            int p2 = meeting[1];
            int t = meeting[2];

            if(!adj.ContainsKey(p1))
                adj[p1] = new List<(int,int)>();
            if(!adj.ContainsKey(p2))
                adj[p2] = new List<(int,int)>();
            adj[p1].Add((p2,t));
            adj[p2].Add((p1,t));
        }
        /*****************ENd of Graph Creation******************************/

        Queue<(int,int)> q = new Queue<(int,int)>();
        q.Enqueue((0,0));
        q.Enqueue((firstPerson,0));

        int[] earlyTime = new int[n];
        Array.Fill(earlyTime,int.MaxValue);
        earlyTime[0]=0;
        earlyTime[firstPerson]=0;

        // BFS
        while(q.Count>0)
        {
            var (person,time) = q.Dequeue();
            if(adj.ContainsKey(person))
            {
                // Traverse its neighbors
                foreach(var neighbor in adj[person])
                {
                    int p = neighbor.Item1;
                    int t = neighbor.Item2;

                    if(t>=time && earlyTime[p]>t)
                    {
                        earlyTime[p]=t;
                        q.Enqueue((p,t));
                    }
                }
            }
        }

        List<int> ans = new List<int>();
        for(int i =0;i<n;i++)
        {
            if(earlyTime[i]!=int.MaxValue)
                ans.Add(i);
        }
        return ans;

    }
}




