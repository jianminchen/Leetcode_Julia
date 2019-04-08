using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1023_Camelcase_matching
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public IList<bool> CamelMatch(string[] queries, string pattern)
        {
            var result = new List<bool>();

            foreach (var item in queries)
            {
                result.Add(match(item, pattern));
            }

            return result;
        }

        private static bool match(string query, string pattern)
        {
            if (query.Length == 0 && pattern.Length == 0)
                return true;

            if (query.Length == 0 && pattern.Length > 0)
                return false;

            if (pattern.Length == 0)
            {
                return query.CompareTo(query.ToLower()) == 0;
            }

            var firstP = pattern[0];
            var isLowerCase = isLowerCaseChar(firstP);

            if (isLowerCase)
            {
                var length = query.Length;

                for (int i = 0; i < length; i++)
                {
                    var current = query[i];
                    if (!isLowerCaseChar(current))
                    {
                        return false;
                    }

                    if (current == firstP)
                    {
                        return match(query.Substring(i + 1), pattern.Substring(1));
                    }
                }
                return false;
            }
            else
            {
                var length = query.Length;

                for (int i = 0; i < length; i++)
                {
                    var current = query[i];
                    if (isLowerCaseChar(current))
                    {
                        continue;
                    }

                    if (current == firstP)
                    {
                        return match(query.Substring(i + 1), pattern.Substring(1));
                    }
                    else
                        return false;
                }

                return false;
            }
        }

        private static bool isLowerCaseChar(char c)
        {
            return c <= 'z' && c >= 'a';
        }
    }
}
