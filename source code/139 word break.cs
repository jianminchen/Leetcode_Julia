using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _139_word_break
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public bool WordBreak(string s, ISet<string> wordDict)
        {
            if (s == null || s.Length == 0)
                return false;

            int len = s.Length;

            bool[] cache = new bool[len + 1];
            cache[0] = true; // "" empty string 

            for (int i = 0; i < len; i++)
            {
                // "ab", "abc"
                // "a"
                // right string start position point index 
                for (int pos = i; pos >= 0; pos--)
                {
                    string left = pos == 0 ? "" : s.Substring(0, pos);
                    //string right = s.Substring(pos, len - left.Length);   // bug001 - not len, should be i
                    string right = s.Substring(pos, i + 1 - left.Length);

                    if (cache[pos] && wordDict.Contains(right))
                    {
                        cache[i + 1] = true;
                        break;
                    }
                }

            }

            return cache[len];
        }
    }
}
