using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromic
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputStr = "abccba"; 
            string s = longestPalindrome1(inputStr);

            // naive approach - time exceeds 
            string testStr = "iopsajhffgvrnyitusobwcxgwlwniqchfnssqttdrnqqcsrigjsxkzcmuoiyxzerakhmexuyeuhjfobrmkoqdljrlojjjysfdslyvckxhuleagmxnzvikfitmkfhevfesnwltekstsueefbrddxrmxokpaxsenwlgytdaexgfwtneurhxvjvpsliepgvspdchmhggybwupiqaqlhjjrildjuewkdxbcpsbjtsevkppvgilrlspejqvzpfeorjmrbdppovvpzxcytscycgwsbnmspihzldjdgilnrlmhaswqaqbecmaocesnpqaotamwofyyfsbmxidowusogmylhlhxftnrmhtnnljjhhcfvywsqimqxqobfsageysonuoagmmviozeouutsiecitrmkypwknorjjiaasxfhsftypspwhvqovmwkjuehujofiabznpipidhfxpoustquzyfurkcgmioxacleqdxgrxbldcuxzgbcazgfismcgmgtjuwchymkzoiqhzaqrtiykdkydgvuaqkllbsactntexcybbjaxlfhyvbxieelstduqzfkoceqzgncvexklahxjnvtyqcjtbfanzgpdmucjlqpiolklmjxnscjcyiybdkgitxnuvtmoypcdldrvalxcxalpwumfx";

            string s2 = longestPalindrome2(testStr);

            string s3 = longestPalindrome3("abccba");

        }

        /*
         * Latest update: June 15, 2015
         * Naive approach 
         * Brute force, time complexity O(N^3)
         * http://www.programcreek.com/2013/12/leetcode-solution-of-longest-palindromic-substring-java/
         * practice coding using c#
         * Two changes made: 
         *   1. second for loop, correction: j <= length, not 'j < length'
         *   2. String.Substring function second parameter 
         * Comment: 1. understand more about C# String class 
         *  2. Basic counting how many characters should be processed 
         */
        public static String longestPalindrome1(String s)
        {

            int maxPalinLength = 0;
            String longestPalindrome = null;
            int length = s.Length;

            // check all possible sub strings
            for (int i = 0; i < length; i++)
            {
                // j <= length, not 'j < length' 
                for (int j = i + 1; j <= length; j++)
                {
                    int len = j - i;
                    // String.Substring function(int pos, int length), second parament is the length 
                    String curr = s.Substring(i, len );

                    if (isPalindrome(curr))
                    {
                        if (len > maxPalinLength)
                        {
                            longestPalindrome = curr;
                            maxPalinLength = len;
                        }
                    }
                }
            }

            return longestPalindrome;
        }

        public static bool isPalindrome(String s)
        {
            int len = s.Length;

            for (int i = 0; i < len - 1; i++)
            {
                if (s[i] != s[len - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }


        /*
         * Latest update: June 15, 2015
         * accepted by leetcode: 480ms
         * 
         * Dynamic programming 
         * 
         * Latest update: June 15, 2015
         * Time O(n^2) Space O(n^2)
         * start condition:
         * table[i][i] == 1;
           table[i][i+1] == 1  => s.charAt(i) == s.charAt(i+1) 
         * 
         * Changing condition:
         * table[i+1][j-1] == 1 && s.charAt(i) == s.charAt(j)
            =>
            table[i][j] == 1
         */

        public static String longestPalindrome2(String s) {
	        if (s == null)
		        return null;
 
	        if(s.Length <=1)
		        return s;
 
	        int maxLen = 0;
	        String longestStr = null;
 
	        int length = s.Length;
 
	        int[][] table = new int[length][];
            for (int i = 0; i < length; i++)
                table[i] = new int[length]; 

            //every single letter is palindrome
            for (int i = 0; i < length; i++)
            {
                table[i][i] = 1;
            }

	        //printTable(table);
 
	        //e.g. bcba
	        //two consecutive same letters are palindrome
	        for (int i = 0; i <= length - 2; i++) {
		        if (s[i] == s[i + 1]){
			        table[i][i + 1] = 1;
			        longestStr = s.Substring(i, 2);
		        }	
	        }

	        //printTable(table);

	        //condition for calculate whole table
	        for (int l = 3; l <= length; l++) {
		        for (int i = 0; i <= length-l; i++) {
			        int j = i + l - 1;

			        if (s[i] == s[j]) {
				        // how to ensure that table[i+1][j-1] is calculated before table[i][j] because the first one's length is j-i-2 whereas the second one is j-i. So, it is in the order. 
                        table[i][j] = table[i + 1][j - 1];

                        if (table[i][j] == 1 && l > maxLen)
                        {
                            longestStr = s.Substring(i, j + 1 - i);
                            maxLen = j + 1 - i; 
                        }
			        } else {
				        table[i][j] = 0;
			        }
			    
                   // printTable(table);
		        }
	        }
 
	        return longestStr;
        }

        public static void printTable(int[][] x){
            int len1 = x.GetLength(0); 
            int len2 = x[0].GetLength(0); 

	        for(int i=0;i<len1;i++){
                for (int j = 0; j < len2;j++ )
                {
                    Console.WriteLine(x[i][j] + " ");
                }

		        Console.WriteLine();
	        }

	        Console.WriteLine("------");
        }

        /**
         * Latest update: June 15, 2015
         * A Simple Algorithm
         * Time O(n^2), Space O(1)
         * Action item: need to debug and understand the code
         */
        public static String longestPalindrome3(String s)
        {
            if (s.Length ==0)
            {
                return null;
            }

            if (s.Length == 1)
            {
                return s;
            }

            String longest = s.Substring(0, 1);
            for (int i = 0; i < s.Length; i++)
            {
                // get longest palindrome with center of i
                String tmp = expand(s, i, i);
                if (tmp.Length > longest.Length)
                {
                    longest = tmp;
                }

                // get longest palindrome with center of i, i+1
                tmp = expand(s, i, i + 1);
                if (tmp.Length > longest.Length)
                {
                    longest = tmp;
                }
            }

            return longest;
        }

        // Given a center, either one letter or two letter, 
        // Find longest palindrome
        // Test case 1: s - "abccba"
        //  begin: 2, end: 3 
        //  return longest palindrome "abccba"
        // Test case 2: s - "abccba"
        //  begin: 1, end: 2
        //  return longest palindrome ""
        public static String expand(String s, int begin, int end)
        {
            while (begin >= 0 && end <= s.Length - 1 && s[begin] == s[end])
            {
                begin--;
                end++;
            }

            // this part of string is palindrome
            return s.Substring(begin + 1, end-begin-1);
        }
    }
}
