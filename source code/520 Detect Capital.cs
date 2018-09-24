using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _520_Detect_Capital
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public bool DetectCapitalUse(string word)
        {
            if (word == null)
                return false;

            return word.ToUpper().CompareTo(word) == 0 ||
                   word.ToLower().CompareTo(word) == 0 ||
                   (word.Length > 1 &&
                    word[0].ToString().ToUpper().CompareTo(word[0].ToString()) == 0 &&
                    word.Substring(1).ToLower().CompareTo(word.Substring(1)) == 0);
        }
    }
}
