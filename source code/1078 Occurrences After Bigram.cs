using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1078_Occurrences_after_bigram
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 1078 Occurrences After Bigram
        /// </summary>
        /// <param name="text"></param>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public string[] FindOcurrences(string text, string first, string second)
        {
            if (text == null)
                return new string[0];

            var words = text.Split(' ');

            var list = new List<string>();
            var length = words.Length;
            for (int i = 2; i < length; i++)
            {
                var firstOne = words[i - 2];
                var secondOne = words[i - 1];

                if (firstOne.CompareTo(first) == 0 && secondOne.CompareTo(second) == 0)
                    list.Add(words[i]);
            }

            return list.ToArray();
        }
    }
}
