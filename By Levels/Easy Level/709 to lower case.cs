using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _709_To_lower_case
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public string ToLowerCase(string str)
        {
            if (str == null)
                return null;

            var sb = new StringBuilder();
            foreach (var item in str)
            {
                if (item >= 'A' && item <= 'Z')
                {
                    var lowerCase = (char)('a' + item - 'A');
                    sb.Append(lowerCase);
                }
                else
                {
                    sb.Append(item);
                }
            }

            return sb.ToString();
        }
    }
}
