using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51NQueenProblem_B
{
    /*
     * Leetcode 51: N-Queen problems 
     * 
     * January 13, 2016
     * 
     * source code reference:
     * https://polythinking.wordpress.com/2013/02/27/leetcoden-queens-i-and-ii/
     * 
     * comment from the above blog:
     * 
        一开始写了深度优先和广度优先的版本都不成功（深度的超时，广度的超内存）。发觉自己的算法没有优化，
     * 好多地方都耗时间，优化后用一维数组记录就可以了。（一开始用二维数组后面发觉判断只需要一维就可以了）
     * 
     * The solution to this problem  is backtracking. Notice, we can use an array to represent 
     * the trial result(because every row must has and only has one queen. Each cell in the array 
     * represent the choice of each row.When we found a solution to putting queens, we can transform 
     * the array from one dimension to two dimension(“…..Q…”).) Most important, we could use 
        (abs(i-putQueenI)==abs(queenStatus[i]-putQueenJ))
        to judge if the new putting location is suitable for diagonal(the queens it put before). 
     * Here, i means the row it put before, queenStatus[i] means the place it put on in that row. 
     * putQueenI and putQueenJ are the new putting location.
     * 
     * julia's comment:
     * 1. write a C# program 
     * 2. Look into StringBuilder vs String (read only feature), StringBuilder analog in C++
     * 
     */
    class Solution 
    { 
        private IList<IList<string> >result = new List<IList<string>>();

        private const char DotChar = '.';
        private const char QueenChar = 'Q'; 
 
        //转换成二维数组的函数
 
        private IList<string> transformToMatrix(IList<int> queenStatus,int n) 
        { 
            IList<string> matrix = new List<string>();                      

            for (int i = 0; i < n; i++)                             
                matrix.Add( getString(queenStatus, i, n)); 
 
            return matrix; 
        }

        /*
         * https://msdn.microsoft.com/en-us/library/ms149403(v=vs.110).aspx
         * using C# StringBuilder
         * 
         * StringBuild.Replace index argument -1
         * method: Append, Replace, 
         */
        private string getString(IList<int> queenStatus, int i, int n)
        {
            StringBuilder s = new StringBuilder(n);
            s.Append(new string(DotChar, n));
            s.Replace(DotChar, QueenChar, queenStatus[i], 1);           
            
            return s.ToString(); 
        }        
 
        //检查是否能在那个位置放置皇后 
        private bool check(IList<int> queenStatus,int putQueenI,int putQueenJ,int n) 
        { 
            for (int i=0; i < putQueenI; i++) 
            { 
                if (queenStatus[i] == putQueenJ) 
                    return false; //检查纵向 

                if (Math.Abs(i-putQueenI) == Math.Abs(queenStatus[i]-putQueenJ)) 
                    return false;//检查斜线 
            }
 
            return true; 
        }
 
        //回溯使用的函数
        /*         
         * January 13, 2016
         * 1. 3 arguments in recursive function
         *   one is current index of row, 
         *   second one is the result of queen status, 
         *   third one is number of rows in total 
         * 2. queen status is stored in one dimension array, but result is in 2 dimension 
         * array, so one is IList<int>, second one is IList<IList<int>>
         * 3. check function is designed. 
         */
        private void putQueen(
            int index, 
            IList<int> queenStatus,
            int n) 
        { 
            if (index >= n) 
            { 
                result.Add(transformToMatrix(queenStatus,n)); 
                return; 
            }
 
            for (int j=0; j<n; j++) 
            { 
                if (check(queenStatus,index,j,n)) 
                { 
                    queenStatus[index]=j;
 
                    putQueen(index+1,queenStatus,n);
 
                    queenStatus[index]=-1;   // backstracking 
                } 
            } 
        }

        /*
         * Julia's comment: 
         * Design a function to return N-Queen problem result 
         * 1. Queen status array uses one dimension array
         * 2. design recursive function <-  Julia, you are still having problems with the skills to design the recursive function
         * 
         * Leetcode:
         * 9 / 9 test cases passed.
            Status: Accepted
            Runtime: 396 ms
         */
        public IList<IList<string>> solveNQueens(int n) {            
            result.Clear();
 
            IList<int> queenStatus = new List<int>(); 

            for(int i=0;i<n;i++)
                queenStatus.Add(-1); 

            putQueen(0,queenStatus,n); 
            return result; 
        }         
    }

    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();

            IList<IList<string>> res = sol.solveNQueens(8);
            IList<IList<string>> res2 = sol.solveNQueens(10); 
        }
    }
}
