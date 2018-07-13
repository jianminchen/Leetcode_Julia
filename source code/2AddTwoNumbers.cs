using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2AddTwoNumbers_
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int v)
        {
            val = v;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }

        /*
         * problem statement:
         * 
         * You are given two linked lists representing two non-negative numbers. 
         * The digits are stored in reverse order and each of their nodes contain 
         * a single digit. Add the two numbers and return it as a linked list.
            Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
            Output: 7 -> 0 -> 8
         * 
         */
        /*
         * source code from blog:
         * http://fisherlei.blogspot.ca/2013/01/leetcode-add-two-numbers-solution.html
         * 
         * http://blog.csdn.net/lilong_dream/article/details/19544995
         * 
         * analysis from the above blog:
         * 要考虑进位。表示结果的结点要new出来。
         * 
         * Julia's comment: 
         * 1. Write down the thought process
         *  First, step 1, base case, if one of list is empty, then, return the other one; 
         *  step 2: do some calculation, get length of two list; 
         *  step 3: define two explainable variable, one is called short one, one is longer one by comparing list length
         *      The code will be more clear to read, and discussion of addition is more clear to read. 
         *      Adopt this smart idea!
         *  step 4: go through two lists in the same time, until short one finishes. 
         *      first, calculate addition of two values (maybe 2 digits), and then, carry and value 
         *      and then, store the sum in the new list; take care new list head creation, build up link
         *  step 5: go through the longer list alone, 
         *      similar work as step 4
         *  step 6: if there is extra node to create for the sum, last carry. 
         *  
         * online judge:
         *  1555 / 1555 test cases passed.
            Status: Accepted
            Runtime: 208 ms
         */
        public static ListNode addTwoNumbers(ListNode l1, ListNode l2)
        {
            // IMPORTANT: Please reset any member data you declared, as  
            // the same Solution instance will be reused for each test case.  
            if (l1 == null)
            {
                return l2;
            }
            if (l2 == null)
            {
                return l1;
            }

            int len1 = getLength(l1);   // length of list 1 
            int len2 = getLength(l2);

            ListNode longer = len1 >= len2 ? l1 : l2;  // smart! reduce if discussion
            ListNode shorter = len1 < len2 ? l1 : l2;

            ListNode result = null;
            ListNode sum = null;

            int val = 0;
            int carry = 0;

            while (shorter != null)
            {
                val = longer.val + shorter.val + carry;
                carry = getCarry(val);    // at most two digit, get the second digit expressing 10; if there is one, it is 1 
                val = getValue(val);   // adjust val to one digit 

                if (sum == null)     // beginning of addition 
                {
                    sum = new ListNode(val);
                    result = sum;
                }
                else
                {
                    sum.next = new ListNode(val);
                    sum = sum.next;
                }

                longer = longer.next;
                shorter = shorter.next;
            }

            while (longer != null)
            {
                val = longer.val + carry;
                carry = val / 10;
                val -= carry * 10;

                sum.next = new ListNode(val);
                sum = sum.next;

                longer = longer.next;
            }

            if (carry != 0)
            {
                sum.next = new ListNode(carry);
            }

            return result;
        }

        public static int getCarry(int val)
        {
            return val / 10;
        }
        /*
         * test case: 
         * 13, 
         * value is 3, carry is 1
         */
        public static int getValue(int val)
        {
            int carry = val / 10;
            val -= carry * 10;
            return val;
        }

        public static int getLength(ListNode l)
        {
            if (l == null) return 0;

            int len = 0;
            ListNode head = l;

            while (head != null)  // get length of list 1 
            {
                ++len;
                head = head.next;
            }

            return len;
        }
    }
}
