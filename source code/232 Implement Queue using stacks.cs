using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _232_using_stack_to_implement_queue
{
    public class MyQueue
    {
        private Stack<int> stack1;
        private Stack<int> stack2;
        private bool usingStack1;
        private int  firstOne;

        public static void Main(string[] args)
        {
            var queue = new MyQueue();
            queue.Push(1);
            queue.Push(2);

            var number = queue.Peek();
            var number2 = queue.Pop();
            var result = queue.Empty(); 
        }

        /** Initialize your data structure here. */
        public MyQueue()
        {
            stack1 = new Stack<int>();
            stack2 = new Stack<int>();

            usingStack1 = true;
            firstOne    = 0;
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            if (usingStack1)
            {
                if (stack1.Count == 0)
                {
                    firstOne = x; 
                }

                stack1.Push(x);
            }
            else  // reverse order 
            {
                firstOne = stack2.Count == 0 ? x : stack2.Peek();

                while (stack2 != null && stack2.Count > 0)
                {
                    stack1.Push(stack2.Pop());
                }

                stack1.Push(x);

                usingStack1 = true; 
            }
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            int frontOne = 0;
            if (usingStack1)
            {
                frontOne = moveFromStacksDequeue(stack1, stack2);
                usingStack1 = false;
            }
            else
            {
                frontOne = stack2.Pop();
                if (stack2.Count > 0)
                {
                    firstOne = stack2.Peek();
                }
            }

            return frontOne;
        }

        /** Get the front element. */
        public int Peek()
        {
            return firstOne; 
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return ( usingStack1 && stack1.Count == 0) ||
                   (!usingStack1 && stack2.Count == 0);
        }

        private int moveFromStacksDequeue(Stack<int> stackFrom, Stack<int> stackTo)
        {
            var count = stackFrom.Count;
            int index = 0;

            var dequeue = 0; 
          
            while (stackFrom.Count > 0)
            {
                var current = stackFrom.Pop();
                if (index < count - 1)
                { 
                    stackTo.Push(current);
                    firstOne = current;
                }
                else
                {
                    dequeue = current;
                }

                index++;
            }

            return dequeue;
        }
    }

    /**
     * Your MyQueue object will be instantiated and called as such:
     * MyQueue obj = new MyQueue();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Peek();
     * bool param_4 = obj.Empty();
     */
}
