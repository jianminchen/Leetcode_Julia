using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class _179LargestNumber
{
    //http://www.cnblogs.com/zhuli19901106/p/4245021.html
    /* 2015.03.31 
     * Leetcode Question 179 
     * Given a list of non negative integers, arrange them such that 
     * they form the largest number.

        For example, given [3, 30, 34, 5, 9], the largest formed number 
     *  is 9534330.

        Note: The result may be very large, so you need to return a string 
     *  instead of an integer.

        Solution:

        Sort the numbers and piece them together, you'll get the answer, 
          either largest or smallest. 
          As for how to sort them, please see the comparator().

        Time complexity is O(n * log(n)), space complexity may be the same, or less.
     */
    static void Main(string[] args)
    {
        //76,30,60,89,77,62,61,56,44,81
        //3, 30, 34, 5, 9
        //76,30,60,89,77,62,61,56,44,81
        int[] arry = { 76, 30, 60, 89, 77, 62, 61, 56, 44, 81 };

        //ArrayList result = largestNumber(arry);
        string result = LargestNumber(arry);
        Console.WriteLine("The program is completed.");
    }

    /*
     * Reference:
     * https://msdn.microsoft.com/en-us/library/system.collections.icomparer%28v=vs.110%29.aspx 
     */
    public class largestNumberclass : IComparer
    {
        // Calls CaseInsensitiveComparer.Compare with the parameters reversed. 
        int IComparer.Compare(object s1, object s2)
        {
            string s12, s21;

            s12 = (string)s1 + (string)s2;
            s21 = (string)s2 + (string)s1;

            Int64 s12Int = Math.Abs(Convert.ToInt64(s12));
            Int64 s21Int = Math.Abs(Convert.ToInt64(s21));

            bool firstOneLarger = s12Int < s21Int;
            if (firstOneLarger) return 1;
            else return -1;
        }
    }

    /*
     * Julia's comment: 
     */
    public static string LargestNumber(int[] num)
    {

        ArrayList l = new ArrayList();

        int len = num.Length;

        for (int i = 0; i < len; ++i)
        {
            l.Add(num[i].ToString());
        }


        IComparer myComparer = new largestNumberclass();
        l.Sort(myComparer);

        string output = "";
        foreach (string sin in l)
            output = output + sin;

        if (output.Length > 1 && output[0] == '0')
            return "0";

        return output;
    }
}

