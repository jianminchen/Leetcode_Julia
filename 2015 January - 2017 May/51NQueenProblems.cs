using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51NQueenProblems
{
    public class NQueenProblem_Backtrack
    {
        /*
         * Leetcode: 51 N Queen problem
         * naive algorithm
         * while thre are untried configurations
         * {
         *    generate the next configuration
         *    
         *    if queens don't attack in this configuration then
         *    {
         *        print this configuration; 
         *    }
         * }
         * 
         * Backtracking algorithm:
         * 
         * The idea is to place queens one by one in different columns, starting from the leftmost column.           
         * When we place a queen in a column, we check for clashes with already placed queens. 
         * In the current column, if we find a row for which there is no clash, we mark this row and column 
         * as part of the solution. If we do not find such a row due to clashes then we backtrack and return false. 
         * 1. start in the leftmost column
         * 2. if all queens are placed, return true
         * 3. try all rows in the current column. Do following for every tried row. 
         *   a) if the queen can be placed safely in this row then mark this [row, column] as part of the solution 
         *   and recursively check if placing queen here leads to a solution. 
         *   b) if placing queen in [row, column] leads to a solution then return true. 
         *   c) if placing queen doesn't lead to a solution then unmark this [row, column] (Backtrack) 
         *   and go to step (a) to try other rows. 
         *   4. If all rows have been tried and nothing worked, return false to trigger backtracking. 
         *   
         * Julia's comment: 
         * 1. Need to review in short future. Use online judge, and also review the solutions from leetcode blogs - Sept. 9, 2015
         * 
         * 
         */
        public const int N = 8;

        /*A utility function to print solution matrix sol[N][N]*/
        public static void printSolution(int[,] sol)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    System.Console.Write(sol[i, j] + " ");
                }
                System.Console.Write("\n");
            }
        }

        /*
         * A utility function to check if a queen can be placed on board[row][col]
         * Note that this function is called when "col" queens are already placed 
         * in columns from 0 to col-1. So we need to check only left side for 
         * attacking queens
         */
        public static bool isSafe(int[,] board, int row, int col)
        {
            int i, j;

            /*check this row on left side*/
            for (i = 0; i < col; i++)
            {
                if (board[row, i] == 1)
                    return false;
            }


            /* check upper diagnoal on left side*/
            /*
            for (i = row - 1; i > -0; i--)
            {
                int column = col + row - i;
                if (column >= 0 && board[i, column] == 1)
                    return false; 
            }*/
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1)
                    return false;
            }

            /* check lower diagonal on left side*/
            /* 
            for (i = row+1; i < N; i++)
            {               
                int column = col - i + row;

                if (column >= 0 && board[i, column] == 1)
                    return false; 
            }
             * */

            // code can be changed in the following:
            for (i = row, j = col; i < N && j >= 0; i++, j--)
            {
                if (board[i, j] == 1)
                    return false;
            }

            return true;
        }

        /*A recursive utility function to solve N queen problem*/
        public static bool solveNQUtil(int[,] board, int col)
        {
            /* base case: If all queens are placed then return true*/
            if (col >= N)
                return true;

            /* consider this column and try placing this queen in all rows one by one */
            for (int i = 0; i < N; i++)
            {
                if (isSafe(board, i, col))
                {
                    board[i, col] = 1;
                    if (solveNQUtil(board, col + 1))
                        return true;

                    /*back track*/
                    board[i, col] = 0;
                }
            }

            /*If queen can not be placed in any row in this column col then return false*/
            return false;
        }

        public static bool solveNQ()
        {
            // int[,] board = new int[4,4]{{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0} };

            int[,] board = new int[8, 8] { { 0, 0, 0, 0, 0, 0, 0, 0 }, 
            { 0, 0, 0, 0, 0, 0, 0, 0 }, 
            { 0, 0, 0, 0, 0, 0, 0, 0 }, 
            { 0, 0, 0, 0, 0, 0, 0, 0 }, 
            { 0, 0, 0, 0, 0, 0, 0, 0 }, 
            { 0, 0, 0, 0, 0, 0, 0, 0 }, 
            { 0, 0, 0, 0, 0, 0, 0, 0 }, 
            { 0, 0, 0, 0, 0, 0, 0, 0 } };

            if (solveNQUtil(board, 0))
            {
                printSolution(board);
                return true;
            }

            return false;
        }

        static void Main(string[] args)
        {
            solveNQ();
        }
    }
}
