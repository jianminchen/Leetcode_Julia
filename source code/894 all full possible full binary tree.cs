using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _894_all_full_possible_full_binary_tree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var result = AllPossibleFBT(7);
        }

        /// <summary>
        /// Lesson learned again. 
        /// Make sure that variables have limited scope; do not allow any variable scope too big, 
        /// specially in the contest environment. 
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public static IList<TreeNode> AllPossibleFBT(int N)
        {
            if (N % 2 == 0)
                return new List<TreeNode>();           

            if (N == 1)
            {
                var root = new TreeNode(0);
                var treeList = new List<TreeNode>();

                treeList.Add(root);
                return treeList; 
            }

            if (N == 3)
            {
                var root = new TreeNode(0);
                var treeList = new List<TreeNode>();

                treeList.Add(root);
                root.left  = new TreeNode(0);
                root.right = new TreeNode(0);

                return treeList;
            }

            var list = new List<TreeNode>();
            // left child's size from 1 to N - 2, right child will be N - 5 to 0
            for (int leftChildCount = 1; leftChildCount <= (N - 2); leftChildCount += 2)
            {
                var rightChildCount = N - 1 - leftChildCount;

                var leftChildren  = AllPossibleFBT(leftChildCount);
                var rightChildren = AllPossibleFBT(rightChildCount); 

                foreach(var leftChild in leftChildren)
                {                    
                    foreach (var rightChild in rightChildren)
                    {
                        var myRoot = new TreeNode(0); // catched by online judge N = 7 - should be inside second for loop
                        myRoot.left = leftChild;      // catched by online judge N = 7 - should be inside second for loop

                        myRoot.right = rightChild;

                        list.Add(myRoot); // catched by online judge 
                    }                    
                }
            }

            return list;
        }
    }
}
