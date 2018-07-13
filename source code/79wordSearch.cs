using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Latest update: July 6, 2015
              Test case: 
              ["ABCE"],
              ["SFCS"],
              ["ADEE"]
              
              word = "ABCCED", -> returns true,
              word = "SEE", -> returns true,
              word = "ABCB", -> returns false.
            */
            char[][] board = new char[3][];
            
            board[0] = new char[]{'A','B','C','E'}; 
            board[1] = new char[]{'S','F','C','S'};
            board[2] = new char[]{'A','D','E','E'};

            bool result1 = exist(board, "ABCE");
            bool r2 = exist(board, "SEE");
            bool r3 = exist(board, "ABCB"); 

            //exist
        }

        /**
         * Latest update: July 6, 2015 
         * Leetcode: word search 
         * source code from: 
         * http://www.acmerblog.com/leetcode-solution-word-search-6226.html
         *
         LeetCode, Word Search
        Word Search
        Given a 2D board and a word, find if the word exists in the grid.

        The word can be constructed from letters of sequentially adjacent cell, 
        where “adjacent” cells are those horizontally or vertically neighboring. 
        The same letter cell may not be used more than once.

        For example,
        Given board =

        [
          ["ABCE"],
          ["SFCS"],
          ["ADEE"]
        ]
        word = "ABCCED", -> returns true,
        word = "SEE", -> returns true,
        word = "ABCB", -> returns false.

        DFS，Recursion

        Time complexity O(n^2*m^2)，space complexity O(n^2)
         * */

        /*
         * Leetcode: online judge
         * pass online judge: 216ms, 82 test cases
         */
        public static bool exist2(char[,] board, string word)
        {
            int m = board.GetLength(0); // rows ? 
            int n = board.GetLength(1); // columns ? 
            char[][] board2 = new char[m][];

            for (int i = 0; i < m; i++)
                board2[i] = new char[n];

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    board2[i][j] = board[i, j];

            return exist(board2, word); 

        }

        public static bool exist(char[][] board, string word)
        {

            int m = board.Length;

            int n = board[0].Length;

            bool[][] visited = new bool[m][]; 

            for(int i=0;i<m;i++)
            {
                visited[i] = new bool[n]; 
            }
            for(int i=0;i<m;i++)
                for(int j=0;j<n;j++)
                    visited[i][j] = false; 


            for (int i = 0; i < m; ++i)
                for (int j = 0; j < n; ++j)
                    if (dfs(board, word, 0, i, j, visited))
                        return true;

            return false;
        }

        /**
         * copied from the blog:
         * http://www.acmerblog.com/leetcode-solution-word-search-6226.html
         * convert the code using C#
         * julia comment: 
         *  Memorize DFS solution, 
         *  1. step 1, when to end the solution, find one solution 
         *  2. step 2, when to terminate because of out of boundary array checking
         *  3. step 3, the node has been visited before; only use once, so terminate search as well. 
         *  4. step 4, check if current visit char is equal to the one in the word; if not, prune it; terminate the search
         *  5. step 5, mark the char is visited. 
         *  6. check if up, down, left, right search, any one of them is true
         *  7. backtracking, set the current char visited is not visited
         *  8. return the result from step 6. 
         */
        public static bool dfs(char[][] board, string word, int index, int x, int y, bool[][]visited) {
            if (index == word.Length)
                return true; // 收敛条件 

            if (x < 0 || y < 0 || x >= board.Length || y >= board[0].Length)
                return false;  // 越界，终止条件 

            if (visited[x][y]) return false; // 已经访问过，剪枝 

            if (board[x][y] != word[index]) return false; // 不相等，剪枝

            visited[x][y] = true;

            bool ret = dfs(board,  word, index + 1, x - 1, y, visited)    || // 上
                       dfs(board,  word, index + 1, x + 1, y, visited)    || // 下
                       dfs(board,  word, index + 1, x, y - 1, visited)    || // 左
                       dfs(board,  word, index + 1, x, y + 1, visited);      // 右

            visited[x][y] = false;   // backtrack 

            return ret;
        }
    } 
}
