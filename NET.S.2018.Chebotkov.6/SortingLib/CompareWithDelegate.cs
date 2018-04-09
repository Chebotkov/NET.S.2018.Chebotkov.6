using System.Collections;

namespace SortingLib
{
    /// <summary>
    /// Implements comparison logic. 
    /// </summary>
    public static class CompareWithDelegate
    {
        private static IComparer comparer = new Compare(); 
        /// <summary>
        /// Compares two arrays.
        /// </summary>
        /// <param name="a">First array.</param>
        /// <param name="b">Second array.</param>
        /// <returns>Returns '0' if objects are equal, '1' if second object bigger than first and '-1' if first object bigger than second.</returns>
        public static int CompareArrays(int[] firstArray, int[] secondArray)
        {
            return comparer.Compare(firstArray, secondArray);
        }
    }
}
