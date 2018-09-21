using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _383_ransom_note
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// ransomNote should be saved in dictionary<char, int> 
        /// magazine should also be saved in dictionary<char, int> 
        /// </summary>
        /// <param name="ransomNote"></param>
        /// <param name="magazine"></param>
        /// <returns></returns>
        public bool CanConstruct(string ransomNote, string magazine)
        {
            if (ransomNote == null || magazine == null)
                return false;

            var ransomDict = saveToDict(ransomNote);
            var magazineDict = saveToDict(magazine);

            foreach (var pair in ransomDict)
            {
                var key = pair.Key;
                var value = pair.Value;

                if (!magazineDict.ContainsKey(key) || magazineDict[key] < value)
                    return false; 
            }

            return true; 
        }

        private static Dictionary<char, int> saveToDict(string words)
        {
            var dict = new Dictionary<char, int>();

            foreach (var item in words)
            {
                if (!dict.ContainsKey(item))
                {
                    dict.Add(item, 0);
                }

                dict[item]++; 
            }

            return dict; 
        }
    }
}
