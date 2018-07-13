using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _317ShortestDistanceFromAllBuildings_C
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

        private int getNoOfBuildings(int[][] grid)
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

        private IList<Node> getListOfBuilding(int[][] grid)
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
                BFS(node, dist, reach, grid);            

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

        private int getRowNo(int[][] grid)
        {
            return grid.Length; 
        }

        private int getColNo(int[][] grid)
        {
            return grid[0].Length; 
        }

        /*
         * January 20, 2016
         * 
         * Design a BFS function 
         * 3 arguments are int[][], do not mix them
         * grid - do not allow the change
         * dist - need to be updated
         * reach - need to be updated
         * 
         * reference:
         * ref, out parameter
         * https://msdn.microsoft.com/en-us/library/s6938f28.aspx         
         * 
         * array
         * https://msdn.microsoft.com/en-us/library/hyfeyz71.aspx
         * 
         * C# const analog - readonly - interface
         * http://stackoverflow.com/questions/114149/const-correctness-in-c-sharp
         * 
         * Book:
         * Effective C#: 50 Specific Ways to Improve Your C# 1st Edition
by Bill Wagner  (Author)
         * Item 2: Prefer readonly to const
         */
        private void BFS(Node origNode,            
            int[][] dist,
            int[][] reach,
            int[][] grid                        
            )
        {
            int m = getRowNo(grid);
            int n = getColNo(grid); 

            bool[][] visited = new bool[m][];
            for (int i = 0; i < m; i++)
                visited[i] = new bool[n];

            Queue<Node> queue = new Queue<Node>();

            // add first node into the queue 
            queue.Enqueue(new Node(origNode.x, origNode.y, 0));

            // BFS - visit all nodes in the grid
            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();
               
                int distance = node.distance;

                distance++;    // increment one !

                // four directions - breadth first search 
                int[][] directions = {new int[2]{-1,  0},    // left
                                      new int[2]{ 1,  0},    // right
                                      new int[2]{ 0, -1},    // down 
                                      new int[2]{ 0,  1}     // up 
                                     };

                for (int i = 0; i < directions.Length; i++)
                {
                    if(okToMove(node, directions[i], grid, visited))
                    {
                        // Let us complete some tasks
                        int x = node.x + directions[i][0];
                        int y = node.y + directions[i][1];   // bug001 - node.x - should be node.y

                        // alphabetic order 
                        dist[x][y]      += distance;                                   
                        reach[x][y]++;
                        visited[x][y]   = true;                         

                        queue.Enqueue(new Node(x, y, distance));
                    }
                }                
            }
        }

        /*
         *  January 20, 2016
         *  Design concern:
         *  BFS - search from a building node, 4 directions. 
         *  
         *  Filter out those 3 cases:
         *  1. The boundary check of matrix is ok 
         *  2. Do not visit more than once
         *  3. Only check empty land node
         *  
         * Ask myself, can this function be more simple? 
         * 4 arguements, but different types, so it is not possible to mix with them. 
         */
        private bool okToMove(
            Node        node, 
            int[]       direction, 
            int[][]     grid, 
            bool[][]    visited)
        {
            int m = getRowNo(grid);
            int n = getColNo(grid);

            int x = node.x + direction[0];
            int y = node.y + direction[1];            

            if (x < 0 || x >= m || y < 0 || y >= n )            
                return false ;

            if(visited[x][y])
                return false; 
             
            if (grid[x][y] != EMTPYLAND)
                return false;

            return true; 
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
         The point (1,2) is an ideal empty land to build a house, 
         as the total travel distance of 3+3+1=7 is minimal. So return 7.
         * 
         * Ref: jagged array initilization lookup
         * https://msdn.microsoft.com/en-us/library/2s05feca.aspx
       
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