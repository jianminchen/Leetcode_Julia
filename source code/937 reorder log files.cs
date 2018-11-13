using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _937_Reorder_log_files
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public string[] ReorderLogFiles(string[] logs)
        {
            if (logs == null || logs.Length == 0)
            {
                return new string[0];
            }

            var digits = new List<string>();
            var dict = new Dictionary<string, string>();

            var result = new List<string>();

            foreach (var log in logs)
            {
                var split = log.Split(' ');
                var firstWord = split[0];
                char firstChar = split[1][0];
                var isLetter = firstChar - 'a' >= 0 && 'z' - firstChar >= 0;
                if (isLetter)
                {
                    dict.Add(log, log.Substring(firstWord.Length));
                }
                else
                {
                    digits.Add(log);
                }
            }

            var myList = dict.ToList();

            myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

            foreach (var pair in myList)
            {
                result.Add(pair.Key);
            }

            foreach (var item in digits)
            {
                result.Add(item);
            }

            return result.ToArray();
        }
    }
}
