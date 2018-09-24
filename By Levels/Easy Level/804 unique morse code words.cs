using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _804.Unique_Morse_Code_Words
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int UniqueMorseRepresentations(string[] words)
        {
            if (words == null)
                return 0;

            var letters = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            var hashset = new HashSet<string>();

            foreach (var item in words)
            {
                var sb = new StringBuilder();
                foreach (var letter in item)
                {
                    sb.Append(letters[letter - 'a']);
                }

                var key = sb.ToString();
                if (!hashset.Contains(key))
                {
                    hashset.Add(key);
                }
            }

            return hashset.Count;
        }
    }
}
