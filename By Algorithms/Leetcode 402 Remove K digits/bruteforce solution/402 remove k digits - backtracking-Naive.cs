using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _402_remove_k_digits
{
    class Program
    {
        static void Main(string[] args)
        {            
            var result = RemoveKdigits("1432219", 3);
            Debug.Assert(result.CompareTo("1219") == 0);             
        }

        static StringBuilder minimumNumber;
        /// <summary>
        /// brute force solution
        /// use DFS to search all possible k digits to remove
        /// </summary>
        /// <param name="number"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static string RemoveKdigits(string number, int k)
        {
            if (number == null || number.Length < k)
                return string.Empty;

            minimumNumber = new StringBuilder();
            var length = number.Length;
            for (int i = 0; i < length - k; i++)
            {
                minimumNumber.Append("9"); 
            }

            var list = new List<char>(); 

            runDFS(number, 0, k, list);

            var trimmed = minimumNumber.ToString().TrimStart(new Char[] { '0' });
            return trimmed.Length == 0 ? "0" : trimmed;             
        }
                
        /// <summary>
        /// standard depth first search algorithm
        /// </summary>
        /// <param name="number"></param>
        /// <param name="index"></param>
        /// <param name="removed"></param>
        /// <param name="?"></param>
        /// <param name="list"></param>
        private static void runDFS(string number, int index, int removed, List<char> list)
        {            
            if (removed == 0)
            {                
                // append rest of digits to list
                // cannot use list, otherwise backtracking will not work
                // make a copy of list instead
                var copyList = new List<char>(list); 
                for (int i = index; i < number.Length; i++)
                {
                    copyList.Add(number[i]); 
                }

                var current = new string(copyList.ToArray());                 

                if(current.CompareTo(minimumNumber.ToString()) < 0)
                {
                    minimumNumber = new StringBuilder(current);                    
                }

                return; 
            }

            if (index == number.Length)
            {
                return;
            }            

            // remove current digit
            runDFS(number, index + 1, removed - 1, list );

            // keep current digit
            list.Add(number[index]);
            runDFS(number, index + 1, removed, list);
            list.RemoveAt(list.Count - 1); // backtracking
        }
    }
}
