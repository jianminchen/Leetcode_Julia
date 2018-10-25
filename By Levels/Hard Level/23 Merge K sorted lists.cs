using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_Merge_k_sorted_lists
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public class MinHeap
        {
            /// <summary>
            /// We need to keep track of the heads of all lists at all times and be able 
            /// to do the following operations efficiently:
            /// 1- Get/Remove Min
            /// 2- Add (once you remove the head of one list, you need to add the next from that list)

            /// A min heap (or a priority queue) is obviously the data structure we need here, 
            /// where the key of the dictionary is the value of the ListNode, and the value of the 
            /// dictionary is a queue of ListNodes having that value. (we need to queue the ones with 
            /// the same value since Dictionary cannot have dupes)
            /// 
            /// Using a SortedDictionary of queues.
            /// SortedDictionary is internally implemented using a binary tree, and provides O(logn) 
            /// for Add() and O(1) for PopMin(), so it's as efficient as it gets.
            /// </summary>
            public SortedDictionary<int, Queue<ListNode>> map = new SortedDictionary<int, Queue<ListNode>>();

            public void Add(int val, ListNode node)
            {
                if (!map.ContainsKey(val))
                {
                    map.Add(val, new Queue<ListNode>());
                }

                map[val].Enqueue(node);
            }

            public ListNode PopMin()
            {
                int minKey = map.First().Key;
                var node = map[minKey].Dequeue();

                if (map[minKey].Count == 0)
                {
                    map.Remove(minKey);
                }

                return node;
            }
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
                return null;

            var n = lists.Length;

            while (n > 1)
            {
                int k = (n + 1) / 2;   // +1 is the secret to cover everything

                for (int i = 0; i < n / 2; i++)
                {
                    lists[i] = merge2list(lists[i], lists[i + k]); // ensure that i + k < n / 2 + (n+1)/2
                }

                n = k;
            }

            return lists[0];  // first list will contain everything
        }

        /// <summary>
        /// merge two lists, and then save the result into the first list
        /// </summary>
        /// <param name="head1"></param>
        /// <param name="head2"></param>
        /// <returns></returns>
        private ListNode merge2list(ListNode head1, ListNode head2)
        {
            var dummyNode = new ListNode(0);
            var merged = dummyNode;

            // finish one of the two lists first
            while (head1 != null && head2 != null)
            {
                // two pointer technique - move the pointer one
                if (head1.val <= head2.val)
                {
                    merged.next = head1;
                    head1 = head1.next;
                }
                else
                {
                    merged.next = head2;
                    head2 = head2.next;
                }

                merged = merged.next;
            }

            // rest of list is simple, just connect to one of the lists
            if (head1 != null)
            {
                merged.next = head1;
            }
            else if (head2 != null)
            {
                merged.next = head2;
            }

            return dummyNode.next;
        }
    }
}
