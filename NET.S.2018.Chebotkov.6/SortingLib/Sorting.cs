using System;
using System.Collections;

namespace SortingLib
{
    /// <summary>
    /// This class contains implementation of "Bubble sorting".
    /// </summary>
    public static class Sorting
    {
        #region BubbleSorting
        /// <summary>
        /// This method sorts array with "Bubble Sorting".
        /// </summary>
        /// <param name="array">Array.</param>
        public static void BubbleSorting(int[][] jaggedArray, IComparer comparer)
        {
            if (jaggedArray == null)
            {
                throw new ArgumentNullException(nameof(jaggedArray));
            }
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            bool isSorted = false;
            int endOfSortedPart = 0;
            while (!isSorted)
            {
                isSorted = true;
                for (int i = jaggedArray.Length - 1; i > endOfSortedPart; i--)
                {

                    if (comparer.Compare(jaggedArray[i], jaggedArray[i - 1]) < 0)
                    {
                        Swap(ref jaggedArray[i], ref jaggedArray[i - 1]);
                        isSorted = false;
                    }
                }
                endOfSortedPart++;
            }
        }
        #endregion

        #region Swap
        /// <summary>
        /// Swaps two indices in array.
        /// </summary>
        /// <param name="index1">First index.</param>
        /// <param name="index2">Second index.</param>
        private static void Swap(ref int[] index1, ref int[] index2)
        {
            int[] temp = index1;
            index1 = index2;
            index2 = temp;
        }
        #endregion
    }
}
