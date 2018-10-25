using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51_N_Queen
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private IList<IList<string>> result = new List<IList<string>>();

        private const char DotChar = '.';
        private const char QueenChar = 'Q';

        //转换成二维数组的函数

        private IList<string> transformToMatrix(IList<int> queenStatus, int n)
        {
            IList<string> matrix = new List<string>();

            for (int i = 0; i < n; i++)
                matrix.Add(getString(queenStatus, i, n));

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
        private bool check(IList<int> queenStatus, int putQueenI, int putQueenJ, int n)
        {
            for (int i = 0; i < putQueenI; i++)
            {
                if (queenStatus[i] == putQueenJ)
                    return false; //检查纵向 

                if (Math.Abs(i - putQueenI) == Math.Abs(queenStatus[i] - putQueenJ))
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
                result.Add(transformToMatrix(queenStatus, n));
                return;
            }

            for (int j = 0; j < n; j++)
            {
                if (check(queenStatus, index, j, n))
                {
                    queenStatus[index] = j;

                    putQueen(index + 1, queenStatus, n);

                    queenStatus[index] = -1;   // backstracking 
                }
            }
        }

        public IList<IList<string>> SolveNQueens(int n)
        {
            result.Clear();

            IList<int> queenStatus = new List<int>();

            for (int i = 0; i < n; i++)
                queenStatus.Add(-1);

            putQueen(0, queenStatus, n);
            return result;
        }
    }
}
