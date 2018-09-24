using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Roman_to_integer
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// the idea is to make two hashmaps. 
        /// First one with increasing order those 
        /// six numbers: 
        /// 4, 9, 40, 90, 400, 900
        /// The second hashmap for 
        /// I 1
        /// V 5
        /// X 10
        /// L 50
        /// C 100
        /// D 500
        /// M 1000
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int RomanToInt(string s)
        {
            if (s == null || s.Length == 0)
                return 0;

            var length = s.Length;
            var dict    = RomanToIntegerDefault();
            var special = RomanToIntegerSpecial();

            int sum = 0; 
            for (int i = 0; i < length; i++)
            {                
                if (i + 1 < length)
                {
                    var key = s.Substring(i, 2);
                    if (special.ContainsKey(key))
                    {
                        sum += special[key];
                        i++;                        
                        continue;
                    }                    
                }

                sum += dict[s[i]];                
            }

            return sum;
        }

        private static IDictionary<char, int> RomanToIntegerDefault()
        {
            var dict = new Dictionary<char, int>();
            
            dict.Add('I', 1);
            dict.Add('V', 5);
            dict.Add('X', 10);
            dict.Add('L', 50);
            dict.Add('C', 100);
            dict.Add('D', 500);
            dict.Add('M', 1000);

            return dict; 
        }

        private static IDictionary<string, int> RomanToIntegerSpecial()
        {
            var dict = new Dictionary<string, int>();

            dict.Add("IV", 4);
            dict.Add("IX", 9);
            dict.Add("XL", 40);
            dict.Add("XC", 90);
            dict.Add("CD", 400);
            dict.Add("CM", 900);            

            return dict;
        }
    }
}
