using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTreeLevelOrderTraversal4
{
    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x)
        {
            val = x;
            left = null;
            right = null;
        }
    };

    class BTreeLevelOrderTraversal4
    {
        static void Main(string[] args)
        {
            /*Latest update: July 23, 2015 
            * Test the code  
            */
            TreeNode n1 = new TreeNode(1);
            n1.left = new TreeNode(2);
            n1.right = new TreeNode(3);
            n1.left.left = new TreeNode(4);
            n1.left.right = new TreeNode(5);
            n1.right.left = new TreeNode(6);
            n1.right.right = new TreeNode(7);

            IList<IList<int>> result3 = levelOrder(n1);
        }

        /*
         * source code from blog:
         * http://fisherlei.blogspot.ca/2013/01/leetcode-binary-tree-level-order.html
         *  
         * convert from C++ to C#
         * Julia's commment:
         *  1. It is DFS algorithm 
         */
        public static IList<IList<int>> levelOrder(TreeNode root) {  
                 
            IList<IList<int>> output = new List<IList<int>>();  

            if(root == null ) 
                return output;  

            IList<int> oneLine = new List<int>();  

            int     currentLevel  = 1; 
            bool    hasNextLevel  = true;  
             
            while(hasNextLevel)  
            {  
                hasNextLevel = false;  

                levelTravel(root, currentLevel, ref hasNextLevel, oneLine);

                List<int> l = new List<int>();
                l.AddRange(oneLine);
                output.Add(l);               

                oneLine.Clear();

                currentLevel++; 
            } 
 
            return output;  
        } 
 
        public static void levelTravel(  
            TreeNode node,   
            int level,  
            ref bool hasNextLevel,  
            IList<int> result)  
        {  
            if(node == null) return;  

            if(level == 1)  
            {  
                result.Add(node.val);
  
                if(node.left !=null || node.right !=null)  
                    hasNextLevel = true;  
                return;  
            }  
            else  
            {  
                levelTravel(node.left, level-1, ref hasNextLevel, result);  
                levelTravel(node.right, level-1, ref hasNextLevel, result);  
            }  
        }  
    }
}
