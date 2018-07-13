using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSum
{
    public class Node{
        public int id,val;
    }

    class Program
    {
        static void Main(string[] args)
        {
        }

        /*
         * source code from blog:
         * http://www.acmerblog.com/leetcode-two-sum-5223.html
         * 
         * 解法1：先排序，然后从开头和结尾同时向中间查找，原理也比较简单。复杂度O(nlogn)
         * 
         * julia's comment: 
         * 
         */
        public static ArrayList twoSum(int[] numbers, int target)
        {
            int len = numbers.Length;
            Node[] tmpNodes = new Node[len];

            for (int i = 0; i < len; i++)
            {
                tmpNodes[i].id = i + 1;
                tmpNodes[i].val = numbers[i];
            }

            Node[] nodes = sortArray(tmpNodes);

            int start = 0, end = len - 1;

            ArrayList ans = new ArrayList();

            while (start < end)
            {
                if (nodes[start].val + nodes[end].val == target)
                {

                    if (nodes[start].id > nodes[end].id)
                    {
                        swap(ref tmpNodes, start, end);

                        ans.Add(tmpNodes[start].id);
                        ans.Add(tmpNodes[end].id);

                        return ans;

                    }
                    else if (tmpNodes[start].val + tmpNodes[end].val < target)
                        start++;
                    else
                        end--;
                }
            }

            return ans; 
        }

        public static void swap(ref Node[] nA, int start, int end)
        {
            Node tmp = nA[start];
            nA[start] = nA[end];
            nA[end] = tmp; 
        }

        public static Node[] sortArray(Node[] nA)
        {
            return nA;   // implement later
        }

        public static bool compare(Node a, Node  b){
            return a.val < b.val;
        }

        /*
           source code from blog:
         * http://www.acmerblog.com/leetcode-two-sum-5223.html
         * 
         * 解法2：使用HashMap。把每个数都存入map中，任何再逐个遍历，
         * 查找是否有 target – nubmers[i]。 时间复杂度 O(n), space need for hashtable
         */
        int[] twoSum(int[] numbers, int target) {

            int[] res = new int[2];

            int length = numbers.Length;

            Hashtable mp = new Hashtable();   // map C++ vs Hashtable C#

            bool find;

            for(int i = 0; i < length; ++i){

                int key = target - numbers[i];
                find = mp.Contains(key);

                if( find ){

                    res[0] = (int)mp[key]; 
                    res[1] = i+1;

                    break;
                }

                mp[numbers[i]] = i+1;
            }

            return res;

        }

    }
}
