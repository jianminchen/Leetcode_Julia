using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _904_Fruit_into_basket
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int TotalFruit(int[] tree)
        {
            if (tree == null || tree.Length == 0)
                return 0;
            var length = tree.Length;
            if (length == 2)
                return 2;
            var countRepetition = countNumber(tree);

            var maxLength = 0;
            var start = 0;
            var twoNumbers = new HashSet<int>();
            for (int i = 0; i < length; i++)
            {
                if (i == 0)
                {
                    start = i;
                }

                twoNumbers.Add(tree[i]);
                var current = 0;
                if (twoNumbers.Count <= 2)
                {
                    current = i - start + 1;
                }
                else
                {
                    twoNumbers.Clear();
                    twoNumbers.Add(tree[i]);
                    twoNumbers.Add(tree[i - 1]);
                    current = countRepetition[i - 1] + 1;
                    start = i - countRepetition[i - 1];
                }

                maxLength = current > maxLength ? current : maxLength;
            }

            return maxLength;
        }

        public static int[] countNumber(int[] tree)
        {
            var length = tree.Length;
            var count = new int[length];

            for (int i = 0; i < length; i++)
            {
                if (i == 0 || tree[i] != tree[i - 1])
                    count[i] = 1;
                else
                    count[i] = count[i - 1] + 1;
            }

            return count;
        }
    }
}
