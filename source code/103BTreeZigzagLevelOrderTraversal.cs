using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _103BTreeZigzagLevelOrderTraversal
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    class zigZagOrder
    {

        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);

            ArrayList output = zigzagOutput(root);
        }

        /*
         * Reference: 
         * 
         * http://rleetcode.blogspot.ca/2014/02/binary-tree-zigzag-level-order.html
         * Time Complexity is O(n)
            Take advantage of two stack
            one is used hold current level's node another is used to hold next level's hold,
            moreover there is flag used to mark the sequece (left to rigth or right to left)
            put the root first into curretn stack then pop it out, put left and right into next_level stack 
            (pay attention to sequence)
            once current stack is empty swap current and next level, level ++, 
            reverse sequence
         * 
         * Julia's comment: 
         * 1. Go through online judge
         * 2. Improve code readability, and improve the code - 
         * 3. Read more blogs about this problem and its solutions through leetcode blog, understand 
         *    better about various solution, and coding level, use best code for me to memorize. 
         * 4. Write down the thought process, extension discussion etc. 
 
         */
        public static ArrayList zigzagOutput(TreeNode root)
        {
            ArrayList result = new ArrayList();

            if (root == null)
                return null;

            Stack<TreeNode> currLevel = new Stack<TreeNode>();
            Stack<TreeNode> nextLevel = new Stack<TreeNode>();

            Stack<TreeNode> tmp;

            currLevel.Push(root);
            bool normalOrder = true;

            int level = 0;
            ArrayList temp = new ArrayList();

            while (currLevel.Count != 0)
            {
                if (result.Count == level)
                {
                    temp = new ArrayList();
                    result.Add(temp);
                }

                ArrayList cResult = new ArrayList();
                while (currLevel.Count != 0)
                {
                    TreeNode node = currLevel.Pop();
                    temp.Add(node.val);

                    if (normalOrder)
                    {
                        if (node.left != null)
                            nextLevel.Push(node.left);
                        if (node.right != null)
                            nextLevel.Push(node.right);
                    }
                    else
                    {
                        if (node.right != null)
                            nextLevel.Push(node.right);
                        if (node.left != null)
                            nextLevel.Push(node.left);
                    }
                }

                if (currLevel.Count == 0)
                {
                    tmp = currLevel;
                    currLevel = nextLevel;
                    nextLevel = tmp;
                    normalOrder = !normalOrder;
                    level++;
                }
            }
            return result;
        }

        public static ArrayList zigzagOutput_2while(TreeNode root)
        {
            ArrayList result = new ArrayList();

            if (root == null)
                return null;

            Stack<TreeNode> currLevel = new Stack<TreeNode>();
            Stack<TreeNode> nextLevel = new Stack<TreeNode>();

            Stack<TreeNode> tmp;

            currLevel.Push(root);
            bool normalOrder = true;

            while (currLevel.Count != 0)
            {
                ArrayList cResult = new ArrayList();
                while (currLevel.Count != 0)
                {
                    TreeNode node = currLevel.Pop();
                    cResult.Add(node.val);

                    if (normalOrder)
                    {
                        if (node.left != null)
                            nextLevel.Push(node.left);
                        if (node.right != null)
                            nextLevel.Push(node.right);
                    }
                    else
                    {
                        if (node.right != null)
                            nextLevel.Push(node.right);
                        if (node.left != null)
                            nextLevel.Push(node.left);
                    }
                }

                result.Add(cResult);
                tmp = currLevel;
                currLevel = nextLevel;
                nextLevel = tmp;
                normalOrder = !normalOrder;
            }
            return result;
        }
    }
}
