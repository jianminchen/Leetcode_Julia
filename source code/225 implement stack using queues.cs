using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _225_implement_stack_using_queues
{
    public class MyStack
    {
        private bool usingQueue1;
        private int  lastOne; 

        private Queue<int> queue1;        
        private Queue<int> queue2; 

        /** Initialize your data structure here. */
        public MyStack()
        {
            queue1 = new Queue<int>();
            queue2 = new Queue<int>();
            usingQueue1 = true; 
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            if (usingQueue1)
            {
                queue1.Enqueue(x);                
            }
            else
            {
                queue2.Enqueue(x);
            }

            lastOne = x;
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            int lastOneInQueue;
            if (usingQueue1)
            {
                // move elements from queue1 to queue2, except last one
                lastOneInQueue = moveElementsBetweenExceptLastOne(queue1, queue2);
                usingQueue1 = false;
            }
            else
            {
                // move elements from queue2 to queue1, except last one
                lastOneInQueue = moveElementsBetweenExceptLastOne(queue2, queue1);
                usingQueue1 = true; 
            }

            return lastOneInQueue;  
        }

        /** Get the top element. */
        public int Top()
        {
            return lastOne; 
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return ( usingQueue1  && queue1.Count == 0) ||
                   (!usingQueue1 && queue2.Count  == 0);
        }

        private int moveElementsBetweenExceptLastOne(Queue<int> queueFrom, Queue<int> queueTo)
        {
            int visit = 0;
            int count = queueFrom.Count;

            int index = 0;
            while (queueFrom.Count > 0)
            {
                visit = queueFrom.Dequeue();
                if (index < count - 1)
                {
                    queueTo.Enqueue(visit);
                    lastOne = visit; // added since first submission failed on Top after Pop is called
                }

                index++; 
            }

            return visit; 
        }
    }

    /**
     * Your MyStack object will be instantiated and called as such:
     * MyStack obj = new MyStack();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Top();
     * bool param_4 = obj.Empty();
     */
}
