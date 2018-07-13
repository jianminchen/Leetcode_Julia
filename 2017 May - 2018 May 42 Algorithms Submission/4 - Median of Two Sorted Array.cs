public class Solution
{
    public double FindMedianSortedArrays(int[] A, int[] B)
    {
        int n = A.Length;

        int m = B.Length;

        bool isEven = (m + n) % 2 == 0;

        int firstIndex = 0;

        int lastIndex = m + n - 1;

        int middle = firstIndex + (lastIndex - firstIndex) / 2;

        int middleToRight = middle + 1;

        if (n == 0)
        {
            return (!isEven) ? B[middle] : (B[middle] + B[middleToRight]) / 2.0;
        }

        if (m == 0)
        {
            return (!isEven) ? A[middle] : (A[middle] + A[middleToRight]) / 2.0;
        }

        if (isEven)
        {
            double mVal1 = FindKthLargestElement(A, B, getKthLargest(middle, lastIndex));

            double mVal2 = FindKthLargestElement(A, B, getKthLargest(middleToRight, lastIndex));

            return (mVal1 + mVal2) / 2.0;
        }

        else
        {
            return FindKthLargestElement(A, B, getKthLargest(middle, lastIndex));
        }
    }

    private static int getKthLargest(int index, int lastIndex)
    {
        return lastIndex - index + 1;
    }

    public static double FindKthLargestElement(int[] array1, int[] array2, int k)
    {
        int length1 = array1.Length;
        int length2 = array2.Length;
        int nthSmallest = length1 + length2 - k + 1;  // bug in code review, need to add 1 here

        return FindKthSmallestElement_BinarySearch(array1, 0, array1.Length, array2, 0, array2.Length, nthSmallest);
    }

    private static double FindKthSmallestElement_BinarySearch(
       int[] array1,
       int start1,
       int length1,
       int[] array2,
       int start2,
       int length2,
       int k)
    {
        //always assume that length1 is equal or smaller than length2
        if (length1 > length2)
        {
            return FindKthSmallestElement_BinarySearch(array2, start2, length2, array1, start1, length1, k);
        }

        if (length1 == 0)
        {
            return array2[start2 + k - 1];
        }

        if (k == 1)
        {
            return Math.Min(array1[start1], array2[start2]); ///
        }

        //divide k into two parts  
        int half_k = Math.Min(k / 2, length1);
        int rest_kElements = k - half_k;

        int firstNode1 = start1 + half_k - 1;
        int firstNode2 = start2 + rest_kElements - 1;

        if (array1[firstNode1] == array2[firstNode2])
        {
            return array1[firstNode1];
        }

        if (array1[firstNode1] < array2[firstNode2]) // remove half_k
        {
            // Go to solve a smaller subproblem, remove first part of the array1
            int newStart = start1 + half_k;  // bug - missing start1 value
            int newLength = length1 - half_k;
            int searchNew = k - half_k;

            return FindKthSmallestElement_BinarySearch(
                array1,
                newStart,
                newLength,
                array2,
                start2,
                length2,
                searchNew);
        }
        else   // remove rest_kElements
        {
            // Go to solve a smaller subproblem, remove first part of the array2
            int newStart = start2 + rest_kElements;  // missing start2
            int newLength = length2 - rest_kElements;
            int searchNew = k - rest_kElements;

            return FindKthSmallestElement_BinarySearch(
                array1,
                start1,
                length1,
                array2,
                newStart,
                newLength,
                searchNew);
        }
    }

}