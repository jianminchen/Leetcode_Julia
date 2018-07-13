using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestRectangleInHistogram
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            list.Add(2);
            list.Add(1);
            list.Add(5);
            list.Add(6);
            list.Add(2);
            list.Add(3);

            // O(N) algorithm
            int result = largestRectangleArea(list);
            int resultP = largestRectangleArea_Pruning(list); 

            int[] a = { 2,1,5,6,2,3};
            int result1 = largestRectangleArea2(a);

            // O(NxN) algorithm 
            int result2 = largestRectangleAreaBF(list); 


        }

        /**
         * Latest update: June 9, 2015 
         * O(NxN) algorithm
         * 对于每一个height，遍历前面所有的height，求取面积最大值。时间复杂度是O(n*n)
         * http://fisherlei.blogspot.ca/2012/12/leetcode-largest-rectangle-in-histogram.html
         */
         public static int largestRectangleAreaBF(ArrayList height) {              
      
            int maxV = 0;  
      
            //First loop i: begin to end marks the area 
            for(int end =0; end< height.Count; end++)  
            {  
                int minH_i = (int)height[end];  

                for(int start =end; start>=0; start--)  
                {
                    minH_i = Math.Min(minH_i, (int)height[start]); 
 
                    int area_ij = minH_i*(end-start+1);  
                    if(area_ij > maxV)  
                        maxV = area_ij;  
                }  
            }  

            return maxV;  
        }

         public static int largestRectangleAreaBF2(int[] height)
         {
             int maxV = 0;

             //First loop i: begin to end marks the area 
             for (int end = 0; end < height.Length; end++)
             {
                 int minH_i = (int)height[end];

                 for (int start = end; start >= 0; start--)
                 {
                     minH_i = Math.Min(minH_i, (int)height[start]);

                     int area_ij = minH_i * (end - start + 1);
                     if (area_ij > maxV)
                         maxV = area_ij;
                 }
             }

             return maxV;
         }

         /**
          * latest update: June 9, 2015
          * 一个简单的改进，是只对合适的右边界（峰顶），往左遍历面积。
          * O(NxN) time complexity 
          */
         public static int largestRectangleArea_Pruning(ArrayList height)
         {            
            int maxV = 0;  
      
            //First loop i: begin to end marks the area 
            for(int end =0; end< height.Count; end++)  
            {  
                int minH_i = (int)height[end];

                // if not peak node, skip it
                if (end + 1 < height.Count
                      && (int)height[end] <= (int)height[end + 1])   
                    continue;  

                for(int start =end; start>=0; start--)  
                {
                    minH_i = Math.Min(minH_i, (int)height[start]); 
 
                    int area_ij = minH_i*(end-start+1);  
                    if(area_ij > maxV)  
                        maxV = area_ij;  
                }  
            }  

            return maxV;  
         }

        /**
         * 168ms 
         */
         public static int largestRectangleArea_Pruning2(int[] height)
         {
             int maxV = 0;

             //First loop i: begin to end marks the area 
             for (int end = 0; end < height.Length; end++)
             {
                 int minH_i = (int)height[end];

                 // if not peak node, skip it
                 if (end + 1 < height.Length
                       && (int)height[end] <= (int)height[end + 1])
                     continue;

                 for (int start = end; start >= 0; start--)
                 {
                     minH_i = Math.Min(minH_i, (int)height[start]);

                     int area_ij = minH_i * (end - start + 1);
                     if (area_ij > maxV)
                         maxV = area_ij;
                 }
             }

             return maxV;
         }

         /**
          * Latest update: June 9, 2015
          * http://fisherlei.blogspot.ca/2012/12/leetcode-largest-rectangle-in-histogram.html
          * 维护一个递增的栈，每次比较栈顶与当前元素。如果当前元素大于栈顶元素，则入站，否则合并现有栈，
          * 直至栈顶元素大于当前元素
          * Test case: A histogram where width of each bar is 1, given height = [2,1,5,6,2,3].
          * The largest rectangle is shown in the shaded area, which has area = 10 unit.
          * Action item: understand the algorithm by going through the debugging process; 
          *    still, I understood the algorithm until step by step debugging. 
          * O(N) algorithm
          */
        public static int largestRectangleArea(ArrayList h) {  
            Stack S = new Stack();  
            h.Add(0);  
            
            int sum = 0;  
            for (int i = 0; i < h.Count; i++) {                

                if (S.Count == 0 || (int)h[i] > (int)h[(int)S.Peek()]) 
                    S.Push(i);  
                else {  
                    int tmp = (int)S.Peek();  
                    S.Pop();

                    //int value4 = (int)S.Peek();
                    int value5 = (int)h[tmp];
                    sum = Math.Max(sum, value5 * ((S.Count == 0) ? i : i - (int)S.Peek() - 1));  
                    i--;  
                }  
            }  
            return sum;  
        }

        /**
         * Leetcode online judge: int[] as input argument 
         * 208ms
         */
        public static int largestRectangleArea2(int[] height)
        {
            Stack S = new Stack();
            int len = height.Length; 
            int[] newH = new int[len + 1];
            
            for (int i = 0; i < len; i++)
                newH[i] = height[i];

            newH[len] = 0; 

            int sum = 0;
            for (int i = 0; i < newH.Length; i++)
            {
                if (S.Count == 0 || (int)newH[i] > (int)newH[(int)S.Peek()])
                    S.Push(i);
                else
                {
                    int tmp = (int)S.Peek();
                    S.Pop();
                    
                    int value_i = (int)newH[tmp];
                    sum = Math.Max(sum, value_i * ((S.Count == 0) ? i : i - (int)S.Peek() - 1));
                    i--;
                }
            }

            return sum;
        }  
    }
}
