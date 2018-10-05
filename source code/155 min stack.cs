using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _155_min_stack
{  
    public class MinStack
    {
        private Stack<int> stack1 { get; set; }
        private Stack<int> stackForMinimums { get; set; }

        static void Main(string[] args)
        {
        }

        /** initialize your data structure here. */
        public MinStack()
        {
            stack1 = new Stack<int>();
            stackForMinimums = new Stack<int>(); 
        }

        public void Push(int x)
        {
            if (stackForMinimums.Count == 0 || x <= GetMin()) // add = because of failed test case
            {
                stackForMinimums.Push(x);
            }

            stack1.Push(x); 
        }

        public void Pop()
        {
            var value = stack1.Peek();
            if (value == GetMin())
            {
                stackForMinimums.Pop();
            }

            stack1.Pop();
        }

        public int Top()
        {
            return stack1.Peek();
        }

        public int GetMin()
        {
            if (stackForMinimums.Count > 0)
                return stackForMinimums.Peek();
            else
                return 0; 
        }
    }

    /**
     * Your MinStack object will be instantiated and called as such:
     * MinStack obj = new MinStack();
     * obj.Push(x);
     * obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.GetMin();
     */
}
