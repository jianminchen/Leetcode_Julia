using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int dim = 5;
            int[][] matrix = new int[dim][];

            for (int i = 0; i < dim; i++)
                matrix[i] = new int[dim];

            for (int i = 0; i < dim; i++)
                for (int j = 0; j < dim; j++)
                {
                    matrix[i][j] = i * dim + j; 
                }

            ArrayList list = spiralOrder_2(matrix); 

            // test case
            int[,] matrix2 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            
            IList<int> list2 = SpiralOrder(matrix2);            
        }

        /**
         * latest update: 
         * Leetcode: Spiral Array
         */
        public static IList<int> SpiralOrder(int[,] matrix)       
        {
            IList<int> list = new List<int>();
            
            int len1 = matrix.GetLength(0);
            int len2 = matrix.GetLength(1);

            int[][] matrix_input = new int[len1][];
            
            for (int i = 0; i < len1;i++ )
                matrix_input[i] = new int[len2];

            for (int i = 0; i < len1; i++)
                for (int j = 0; j < len2; j++)
                {
                    matrix_input[i][j] = matrix[i,j]; 
                }

            ArrayList al = spiralOrder_2(matrix_input); 

            foreach(object  s in al)
            {
                list.Add((int)s); 
            }
            return list; 
        }

        public static ArrayList spiralOrder_2(int[][] matrix)
        {            
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) 
                return new ArrayList();
            return spiralOrder_3(matrix, 0, 0, matrix.Length, matrix[0].Length);
        }
    
        /**
         * Latest update: June 12, 2015 
         * Leetcode: spiral array
         * http://gongxuns.blogspot.ca/2012/12/leetcode-spiral-matrix.html
         * Test case: 
         * 1. empty array 
         * 2. one element:           1 -
         * 2B. one row : 1 2 --
         * 3. one column : 1 |
         *                 2 |
         * 4. more than 1 row, 
         *    or more than 1 column   
         *     1 2
         *     3 4
         *     output: 1 2 4 3 
         * 5. 3 rows, 3 columns
         *    1 2 3
         *    4 5 6
         *    7 8 9
         *    output: 1 2 3 6 9 8 7 4 5 
         * 
         */
        public static ArrayList spiralOrder_3(int [][] matrix, int x, int y, int m, int n){
            ArrayList res = new ArrayList();
            // test case: empty array
            if(m<=0||n<=0) return res;

            // test case 2: one row and one column
            if(m==1&&n==1) {
                res.Add(matrix[x][y]);
                return res;
            }

            //  row, from left to right 
            for(int i=0;i<n-1;i++){
                res.Add(matrix[x][y++]);
            }

            //  column, from top to down
            for(int i=0;i<m-1;i++){
                res.Add(matrix[x++][y]);
            }

            // conditional: second row, from right to left 
            if(m>1){    
                for(int i=0;i<n-1;i++){
                    res.Add(matrix[x][y--]);
                }
            }

            // conditional: second column, from bottom to top
            if(n>1){
                for(int i=0;i<m-1;i++){
                    res.Add(matrix[x--][y]);
                }
            }

            // test case: one row, 1 2 3, where 1 2 is procesed above and 3 is left for next round 
            // one column:
            if (m == 1 || n == 1)
            {
                ArrayList l = spiralOrder_3(matrix, x, y, 1, 1);

                foreach(object val in l)                
                    res.Add((int)val);                
            }
            else
            {
                ArrayList l = spiralOrder_3(matrix, x + 1, y + 1, m - 2, n - 2);
                foreach(object val in l)                
                    res.Add((int)val);
            }

            return res;
        }    
    }
}
