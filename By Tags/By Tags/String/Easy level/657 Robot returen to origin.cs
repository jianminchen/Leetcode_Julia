using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _657.Robot_Return_to_Origin
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Keep two count 
        /// vertical - U +1, D -1
        /// horizontal - R +1, L - 1
        /// check two count variables' values
        /// </summary>
        /// <param name="moves"></param>
        /// <returns></returns>
        public bool JudgeCircle(string moves)
        {
            if (moves == null)
                return true;

            var vertical = 0;
            var horizontal = 0;
            foreach (var item in moves)
            {
                if (item == 'U')
                {
                    vertical++;
                }
                else if (item == 'D')
                {
                    vertical--;
                }
                else if (item == 'R')
                {
                    horizontal++;
                }
                else
                    horizontal--;
            }

            return vertical == 0 && horizontal == 0;
        }
    }
}
