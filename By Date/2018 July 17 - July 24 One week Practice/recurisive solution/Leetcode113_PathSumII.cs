using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode113_PathSumII
{
    /// <summary>
    /// Leetcode 113 - path sum II
    /// 
    /// July 18, 2018
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }
       
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
 
        public class Solution
        {
            public IList<IList<int>> PathSum(TreeNode root, int sum)
            {
                if (root == null)
                    return new List<IList<int>>();

                var currentPath = new List<int>();
                var paths = new List<IList<int>>();

                pathSumHelper(root, sum, currentPath, paths);

                return paths;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="root"></param>
            /// <param name="residue"></param>
            /// <param name="currentPath"></param>
            /// <param name="paths"></param>
            private static void pathSumHelper(TreeNode root, int residue, IList<int> currentPath, IList<IList<int>> paths)
            {
                if (root == null)
                    return;

                var currentValue = root.val;
                currentPath.Add(currentValue);

                if (root.left == null && root.right == null)
                {
                    if(residue == currentValue)
                        paths.Add(currentPath);                    
                }
                else
                {                   
                    pathSumHelper(root.left,  residue - currentValue, new List<int>(currentPath), paths);                                      
                    pathSumHelper(root.right, residue - currentValue, new List<int>(currentPath), paths);                    
                }                
            }
        }
    }
}
