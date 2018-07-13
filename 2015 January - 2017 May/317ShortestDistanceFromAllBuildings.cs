using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _317ShortestDistanceFromAllBuildings_B
{
    /*
    * Leetcode 317:
    * You want to build a house on an empty land which reaches all buildings in the shortest amount 
    * of distance. You can only move up, down, left and right. You are given a 2D grid of values 0, 1 or 2, 
    * where:
       Each 0 marks an empty land which you can pass by freely.
       Each 1 marks a building which you cannot pass through.
       Each 2 marks an obstacle which you cannot pass through.
       For example, given three buildings at (0,0), (0,4), (2,2), and an obstacle at (0,2):
   1 - 0 - 2 - 0 - 1
   |   |   |   |   |
   0 - 0 - 0 - 0 - 0
   |   |   |   |   |
   0 - 0 - 1 - 0 - 0
    * 
    * The point (1,2) is an ideal empty land to build a house, as the total travel distance of 3+3+1=7 is 
    * minimal. So return 7.
    * 
    * code reference:
    * http://buttercola.blogspot.ca/2016/01/leetcode-shortest-distance-from-all.html
    * 
    * Analysis from the above blog:
    * Note:
       There will be at least one building. If it is not possible to build such house according to       
       the above rules, return -1.
       Understand the problem:
       A BFS problem. Search from each building and calculate the distance to the building. 
    *  One thing to note is an empty land must be reachable by all buildings. To achieve this, 
    *  maintain an array of counters. Each time we reach a empty land from a building, increase the 
    *  counter. Finally, a reachable point must have the counter equaling to the number of buildings. 
    *  
    * Julia's comment on January 19, 2016:
    * 1. let us do the following:

       A. First, get the number of building in total - integer
       B. Get all the building into a data structure - a list - each one is (i,j) coordinate
       C. Then, go through each building, we need to report two things:

      distance[i][j], where 0 <= i < n, 0 <= j < n
      reach[i][j],    where 0 <= i < n, 0 <= j < n 

      How to do it? using BFS search 

      We need to put all the distance array, reach[i][j] into list as well, so we can sum the value, 
      compare to number of building - reachable, 

      And then, get the minimum distance. 


      Four direction of BFS search. 
      BFS search main points: 
      do not visit twice, avoid dead loop 

      Four direction for next move. 

      Base case of BFS:
      1. in the range of matrix 
      2. is not the building node - original starter
      3. is land node

      Task: distance to building, current distance, two arrays, one queue 

      So, based on the above 3 cases - design the function to do BFS
      arguments: 
      original node (x, y), new node (x1, y1), 

      Discussion: 

       1. Think about ideas: 
         A1: finding all buildings, go through each one, do BFS 
         A2: find all empty land, go through each land, and then, find land's distance to each of building. 
     
        Argue A1 and A2, difference between them.      
        
    *  January 19, 2016 8:00pm - 9:30pm - work on coding more than 1 hour
    *  BFS is hard algorithm to write. 
    *  How to shorten the time to 20 minutes? 
    *  
    *  Take more than 20 minutes to go over code to fix bugs before compiling - read the code, check variable scope, etc. 
    *  Look up jagged array initialization - learn using new int[] inside first dimension array {}
    *  
    */
    class Node
    {
        public int x;
        public int y;
        public int distance;        

        public Node(int a, int b, int dis = 0)
        {
            x = a;
            y = b;
            distance = dis; 
        }
    }

    class Solution
    {
        const int EMTPYLAND = 0;
        const int BUILDING = 1;
        const int OBSTACLE = 2;

        public int getNoOfBuildings(int[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;

            int m = grid.Length;
            int n = grid[0].Length;

            int count = 0;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == BUILDING)
                        count++;
                }
            return count;
        }

        public IList<Node> getListOfBuilding(int[][] grid)
        {
            IList<Node> list = new List<Node>();

            if (grid == null || grid.Length == 0)
                return list;

            int m = grid.Length;
            int n = grid[0].Length;

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == BUILDING)
                    {
                        Node node = new Node(i, j);
                        list.Add(node);
                    }

                }
            return list;
        }

        /*
         * get shortest distance to all the buildings 
         */
        public int shortestDistance(int[][] grid)
        {
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            int m = grid.Length;
            int n = grid[0].Length;

            int[][] dist = new int[m][];
            for (int i = 0; i < m; i++)
                dist[i] = new int[n];

            int[][] reach = new int[m][];
            for (int i = 0; i < m; i++)
                reach[i] = new int[n];

            // step 1: BFS and calcualte the min dist from each building
            // also, each building will do BFS, and accumulate the value of 
            // dist and reach array - 
            int numBuildings = getNoOfBuildings(grid);
            IList<Node> list = getListOfBuilding(grid);

            foreach (Node node in list)
            {
                bool[][] visited = new bool[m][];
                for (int i = 0; i < m; i++)
                    visited[i] = new bool[n];

                Queue<Node> queue = new Queue<Node>();
                BFS(node, 0, dist, reach, grid, visited, queue);
            }

            // step 2: caluclate the minimum distance
            int minDist = Int16.MaxValue;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == EMTPYLAND && reach[i][j] == numBuildings)
                    {
                        minDist = Math.Min(minDist, dist[i][j]);
                    }
                }
            }

            return minDist == Int16.MaxValue ? -1 : minDist;
        }
        /*
         * Design a BFS function - most challenge one 
         * 1. in the range of matrix 
           2. is not the building node - original starter
           3. is land node
         * 
         * bug 001 - do not allow 
         * declare statement:
         *  int x = originalNode.x
         * x scope is bigger than necessary, in while loop area - causing bug  
         * 
         */
        public void BFS(Node origNode,
            int currDistance,
            int[][] dist,
            int[][] reach,
            int[][] grid,
            bool[][] visited,
            Queue<Node> queue
            )
        {
            // add first node into the queue 
            fill(origNode.x, origNode.y, origNode.x, origNode.y, currDistance,
                dist, reach, grid, visited, queue);

            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();

                int x = node.x; // bug 001 
                int y = node.y;
                int distance = node.distance;

                distance++; // BUG-B-02   CANNOT USE ONE VARIABLE FOR DISTANCE - NEED TO SAVE IN THE QUEUE, RETRIEVE FROM QUEUE

                // four directions - call fill function
                fill(x, y, x - 1, y, distance, dist, reach, grid, visited,  queue);
                fill(x, y, x + 1, y, distance, dist, reach, grid, visited, queue);
                fill(x, y, x, y - 1, distance, dist, reach, grid, visited, queue);
                fill(x, y, x, y + 1, distance, dist, reach, grid, visited, queue);
            }
        }

        /*
         * Design talk:
         * 
         * Need to BFS - search empty land
         * Need to add first building in the queue
         * Edge cases:         * 
         * 1. check node - boundary of matrix 
         * 2. node is not visited yet - avoid visiting a node more than once
         * 3. only allow original building node fill once
         * 4. obstacle node cannot fill 
         * 
         * Actions:
         * A1: mark the node is visited, 
         * A2: node is reached by one building, increment one
         * A3: distance value should add this new one - from the new building
         * 
         * bug 001 - C# ref need for those jagged arrays (? No, remove ref for those arguments in fill function )
         * Lesson - need to look into more about ref using C# 
         * visited should check x1, y1, not x, y - Spent over 10 minutes to find the bug by debugging - Lesson learned. 
         * 
         * bug 002 - visit node (x1, y1), so focus on (x1, y1); check this new node, forget about (x,y) - confused. 
         * bug 003 - dist[x1][y1] - not [x][y] 
         * BUG_B_02 - DO NOT USE x, x1, too close; refactor: x - origX, x1 - x
         */
        public void fill(
            int origX, int origY, int x, int y, int curDistance, int[][] dist, int[][] reach,
            int[][] grid, bool[][] visited, Queue<Node> queue)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            // if (x1 < 0 || x1 >= m || y1 < 0 || y1 >= n || visited[x][y]) // check 1, 2  // bug 001 visited should check x1, y1, not x, y
            if (x < 0 || x >= m || y < 0 || y >= n || visited[x][y])
                return;
            //if ((x != x1 || y != y1) && grid[x][y] != EMTPYLAND) // check 3, 4 // bug 002 
            if ((x != origX || y != origY) && grid[x][y] != EMTPYLAND)
                return;

            visited[x][y] = true;           // Action 1
            reach[x][y]++;                  // Action 2
            //dist[x][y] += curDistance;    // Action 3  // bug 003 
            dist[x][y] += curDistance;      // Action 3 

            queue.Enqueue(new Node(x, y, curDistance));
        }
        /*   
         * Test case: 
         * 
         1 - 0 - 2 - 0 - 1
         |   |   |   |   |
         0 - 0 - 0 - 0 - 0
         |   |   |   |   |
         0 - 0 - 1 - 0 - 0
         * 
         The point (1,2) is an ideal empty land to build a house, as the total travel distance of 3+3+1=7 is 
         minimal. So return 7.
         * 
         * Ref: jagged array initilization lookup
         * https://msdn.microsoft.com/en-us/library/2s05feca.aspx
         * 
         * bug001    - result = 0   
         * BUG_B_002 - result = 11 
         * 
         * First building BFS
         * visited
             */
        static void Main(string[] args)
        {

            int[][] grid = new int[][] { 
                new int[] { 1, 0, 2, 0, 1 }, 
                new int[] { 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 1, 0, 0 } 
            };

            Solution sol = new Solution();

            int result = sol.shortestDistance(grid);
            Console.WriteLine(result);
        }
    }
}
