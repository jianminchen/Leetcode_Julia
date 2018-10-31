using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _138_copy_list_with_random_pointer
{
    public class RandomListNode {
      public int label;
      public RandomListNode next, random;
      public RandomListNode(int x) { this.label = x; }
    };

    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// two steps:
        /// First step, make a copy a list, and also build a hashmap between nodes in 
        /// the original linked list to the copy list
        /// Second step, copy random point for the list
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static RandomListNode CopyRandomList(RandomListNode head)
        {
            if (head == null)
                return null;

            var dict = new Dictionary<RandomListNode, RandomListNode>();

            var copyHead = copyListWithoutRandom(head, dict);

            copyRandomPointer(head, dict);

            return copyHead; 
        }

        /// <summary>
        /// use recursive function to shorten the time
        /// </summary>
        /// <param name="head"></param>
        /// <param name="dict"></param>
        /// <returns></returns>
        private static RandomListNode copyListWithoutRandom(RandomListNode head, Dictionary<RandomListNode, RandomListNode> dict)
        {
            if (head == null)
                return null;

            var value = head.label;
            var copyHead = new RandomListNode(value);

            dict.Add(head, copyHead);

            copyHead.next = copyListWithoutRandom(head.next, dict);

            return copyHead; 
        }

        private static void copyRandomPointer(RandomListNode head, Dictionary<RandomListNode, RandomListNode> dict)
        {
            while (head != null)
            {
                var random = head.random;
                if (random != null)
                {
                    dict[head].random = dict[random];
                }
                else
                {
                    dict[head].random = null; 
                }

                head = head.next;
            }
        }
    }
}
