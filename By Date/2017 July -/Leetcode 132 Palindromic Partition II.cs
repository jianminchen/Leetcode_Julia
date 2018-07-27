using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_132_Palindromic_Partition_II
{
    /// <summary>
    /// Leetcode 132 Palindromic partition II
    /// source code is based on Java code
    /// https://github.com/IDeserve/learn/blob/master/PalindromePartitionMinCut.java
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// minimum cut - using dynamic programming 
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int partition(String s) {
		  int n = s.Length;
		  var palindrome = new bool[n, n]; 
		  
		  //Trivial case: single letter palindromes
		  for (int i = 0; i < n; i++) {
			  palindrome[i, i] = true;
		  }
		  
		  //Finding palindromes of two characters.
		  for (int i = 0; i < n-1; i++) {
		    if (s[i] == s[i+1]) {
		      palindrome[i, i+1] = true;
		    }
		  }
		  
		  //Finding palindromes of length 3 to n
		  for (int pLength = 3; pLength <= n; pLength++) {
		    for (int i = 0; i < n - pLength + 1; i++) {  
		      int j = i + pLength - 1;

		      if (s[i] == s[j]                 //1. The first and last characters should match 
		    	  && palindrome[i + 1, j - 1]) //2. Rest of the substring should be a palindrome
		      {
		    	palindrome[i, j] = true; 
		      }
		    }
		  }
		  
		  var cuts = new int[n];
		  for(int i = 0; i < n; i++)
		  {
			  int minimumCut = int.MaxValue;

              if (palindrome[0, i])
              {
                  cuts[i] = 0;
              }
              else
              {
                  // brute force all possible cut for [0,i], which divides into two ranges 
                  // [0, j], [j + 1, i] 
                  for (int j = 0; j < i; j++)
                  {
                      var currentCut = cuts[j] + 1;

                      if ((palindrome[j + 1, i]) && minimumCut > currentCut)
                      {
                          minimumCut = currentCut;
                      }
                  }

                  cuts[i] = minimumCut;
              }			  
		  }

		  return cuts[n - 1];
		}
    }
}
