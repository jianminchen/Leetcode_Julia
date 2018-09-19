using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _171_excel_sheet_column_number
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int TitleToNumber(string s)
        {
            if (s == null)
                return 0;
            
            int number = 0;

            for (int i = 0; i < s.Length; i++)
            {
                var current = s[i];
                var value = current - 'A' + 1;
                number = number * 26 + value; 
            }

            return number; 
        }
    }
}
