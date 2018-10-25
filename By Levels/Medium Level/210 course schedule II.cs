using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210_course_schedule_II
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int[] FindOrder(int numCourses, int[,] prerequisites)
        {
            var dependents = new Stack<int>[numCourses];

            for (int i = 0; i < numCourses; ++i)
            {
                dependents[i] = new Stack<int>();
            }

            // build dependency list for each prerequisite course, 
            // and set up indegree variable for each courses matching with prerequisite courses' number.
            int[] indegree = new int[numCourses];
            for (int i = 0; i < prerequisites.GetLength(0); ++i)
            {
                int takeFirst = prerequisites[i, 1];
                int takeAfter = prerequisites[i, 0];

                dependents[takeFirst].Push(takeAfter);
                ++indegree[takeAfter];
            }

            // add those courses with 0 indegree to the queue
            Queue<int> queue = new Queue<int>();
            for (int courseId = 0; courseId < numCourses; ++courseId)
            {
                if (indegree[courseId] == 0)
                {
                    queue.Enqueue(courseId);
                }
            }

            // take courses with indgree zero only
            var coursesByTakingOrder = new int[numCourses];
            int count = 0;
            while (queue.Count > 0)
            {
                int readyToTake = queue.Dequeue();

                coursesByTakingOrder[count++] = readyToTake;

                foreach (int courseId in dependents[readyToTake])
                {
                    // decrement value of indegree by 1 
                    indegree[courseId]--;

                    // add to the queue if there is no prerequisite left
                    if (indegree[courseId] == 0)
                    {
                        queue.Enqueue(courseId);
                    }
                }
            }

            if (count != numCourses)
            {
                return new int[] { };
            }

            return coursesByTakingOrder;
        }
    }
}
