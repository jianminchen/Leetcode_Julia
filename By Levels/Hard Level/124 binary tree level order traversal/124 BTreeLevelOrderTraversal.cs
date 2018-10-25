using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTreeLevelOrderTraversal
{
    /*
     * julia's comment (July 23, 2015): 
     * 1. c++ structure everything default is public, but class member is private; so add public
     * 2. keep structure in C# from c++, trouble to compare to null value; and then, 
     * change to class. 
     */
    class TreeNode
    {
	    public int val;
	    public TreeNode left;
	    public TreeNode right;
	    public TreeNode(int x) { 
            val = x;
            left = null;
            right = null;
        }
    };

    class BTreeLevelOrderTraversal
    {
        const Int16 NULL_INT = 0;
        static void Main(string[] args)
        {
            /*Latest update: July 23, 2015 
             * Test the code and then find a bug 
             */
            TreeNode n1 = new TreeNode(1);
            n1.left = new TreeNode(2);
            n1.right = new TreeNode(3);
            n1.left.left = new TreeNode(4);
            n1.left.right = new TreeNode(5);
            n1.right.left = new TreeNode(6);
            n1.right.right = new TreeNode(7);

            ArrayList result = levelOrder_bugVersion(n1); 

            /*
             * Try to fix the bug
             * 
             */
            ArrayList result2 = levelOrder_bugFree(n1); 
        }

        /**
         * source code from blog:
         * https://github.com/xiaoxq/leetcode-cpp/blob/master/src/BinaryTreeLevelOrderTraversal.cpp
         * convert from C++ to C#
         * julia's comment: 
         * 1. check leetcode online judge, need to use IList<IList<int>> 
         * 2. how to use queue for level order traversal, null point as level divider. Kind of tricky. 
         *    first action before the loop, push first node into the queue, and then 
         *    push level divider: null point
         *    design null pointer action: once null pointer is met, and then, 
         *    finish the current level, go to next level: 
         *    1. first, save the current level visited value into the result for return; 
         *    2. second, check if the queue is empty -> yes, finish last level, ready to exit. 
         *    3. third, prepare for next level:
         *       A: clear the container for current level info
         *       B: review facts: B.1. there is no null in the queue 
         *                        B.2. there is only one level nodes in the queue, will be current level
         *          So, need to add level divider now. 
         * 3. C# has a bug - share one arrayList object for each level, 
         *    use clear method will not work out. 
         *    lesson A: C# List.addAll <->  C# ArrayList.addRange
         */
        public static ArrayList levelOrder_bugVersion(TreeNode root)
	    {
		    ArrayList result = new ArrayList();

		    if( root == null)
			    return result;

		    ArrayList level = new ArrayList();

		    Queue<TreeNode> toVisit = new Queue<TreeNode>();

		    toVisit.Enqueue( root );
		    toVisit.Enqueue( null );

		    while( true )
		    {
			    TreeNode cur = toVisit.Peek(); 
                toVisit.Dequeue();
			    // end a level

			    if( cur==null )
			    {
				    result.Add( level );

				    if( toVisit.Count == 0 )
					    break;

				    // add a new End-Of-Level
                    level.Clear();   // julia's comment: C# bug, cannot share one object - 
                                     //need to create new object for each level
				    toVisit.Enqueue( null );
			    }
			    else
			    {
				    level.Add( cur.val );
				    if( cur.left != null)
					    toVisit.Enqueue( cur.left );
				    if( cur.right != null )
					    toVisit.Enqueue( cur.right );
			    }
		    }

		    return result;
	    }

        /**
         * source code from blog:
         * https://github.com/xiaoxq/leetcode-cpp/blob/master/src/BinaryTreeLevelOrderTraversal.cpp
         * convert from C++ to C#
         * julia's comment: 
         * 1. check leetcode online judge, need to use IList<IList<int>> 
         * 2. how to use queue for level order traversal, null point as level divider. Kind of tricky. 
         *    first action before the loop, push first node into the queue, and then 
         *    push level divider: null point
         *    design null pointer action: once null pointer is met, and then, 
         *    finish the current level, go to next level: 
         *    1. first, save the current level visited value into the result for return; 
         *    2. second, check if the queue is empty -> yes, finish last level, ready to exit. 
         *    3. third, prepare for next level:
         *       A: clear the container for current level info
         *       B: review facts: B.1. there is no null in the queue 
         *                        B.2. there is only one level nodes in the queue, will be current level
         *          So, need to add level divider now. 
         * 3. C# has a bug - share one arrayList object for each level, 
         *    use clear method will not work out. 
         * 4. Fix the bug - 
         *    First try failed, using " copy the list, same pointer"
              second try, use addRange method, work out perfect!
         * http://stackoverflow.com/questions/10022441/how-to-move-contents-of-one-arraylist-to-another
         *    C# List.addAll <-> C# ArrayList.addRange method 
         */
        public static ArrayList levelOrder_bugFree(TreeNode root)
        {
            ArrayList result = new ArrayList();

            if (root == null)
                return result;

            ArrayList level = new ArrayList();

            Queue<TreeNode> toVisit = new Queue<TreeNode>();

            toVisit.Enqueue(root);
            toVisit.Enqueue(null);

            while (true)
            {
                TreeNode cur = toVisit.Peek();
                toVisit.Dequeue();
                // end a level

                if (cur == null)
                {
                    ArrayList list = new ArrayList(); // julia: bug fix                    
                    list.AddRange(level);  // julia: bug fix 
                    result.Add(list);  

                    if (toVisit.Count == 0)
                        break;

                    // add a new End-Of-Level                    
                    level.Clear();                      

                    toVisit.Enqueue(null);
                }
                else
                {
                    level.Add(cur.val);
                    if (cur.left != null)
                        toVisit.Enqueue(cur.left);
                    if (cur.right != null)
                        toVisit.Enqueue(cur.right);
                }
            }

            return result;
        }
    }
}
