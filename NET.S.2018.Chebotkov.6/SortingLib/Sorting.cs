using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static void BubbleSorting(int ? [] array, int[][] jaggedArray)
        {
            bool isSorted = false;
            while (!isSorted)
            {
                isSorted = true; 
                for (int i = array.Length-1; i >0; i--)
                {
                    if (!array[i - 1].HasValue)
                    {
                        if (!array[i].HasValue)
                        {                        
                            continue;
                        }
                        else
                        {
                            Swap(ref array[i], ref array[i - 1]);
                            Swap(ref jaggedArray[i], ref jaggedArray[i - 1]);
                            isSorted = false;
                        }
                    }
                    
                    if (array[i] < array[i-1])
                    {
                        Swap(ref array[i], ref array[i - 1]);
                        Swap(ref jaggedArray[i], ref jaggedArray[i - 1]);
                        isSorted = false;
                    }
                }
            }
        }
        #endregion

        #region Swap
        /// <summary>
        /// Swap two indices in array.
        /// </summary>
        /// <param name="index1">First index.</param>
        /// <param name="index2">Second index.</param>
        private static void Swap (ref int ? index1, ref int ? index2)
        {
            int ?  temp = index1;
            index1 = index2;
            index2 = temp;
        }

        /// <summary>
        /// Swap two arrays in jagged array.
        /// </summary>
        /// <param name="arr1">First array.</param>
        /// <param name="arr2">Second array.</para
        private static void Swap(ref int [] arr1, ref int [] arr2)
        {
            int [] temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }
        #endregion
    }
}
