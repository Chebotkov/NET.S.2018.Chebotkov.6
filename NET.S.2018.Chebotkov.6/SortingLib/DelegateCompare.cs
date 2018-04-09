namespace SortingLib
{
    /// <summary>
    /// Implements comparison logic. 
    /// </summary>
    public class DelegateCompare
    {
        /// <summary>
        /// Compares two arrays.
        /// </summary>
        /// <param name="a">First array.</param>
        /// <param name="b">Second array.</param>
        /// <returns>Returns '0' if objects are equal, '1' if second object bigger than first and '-1' if first object bigger than second.</returns>
        public static int CompareArrays(int[] firstArray, int[] secondArray)
        {
            if (ReferenceEquals(firstArray, secondArray))
            {
                return 0;
            }
            else if (ReferenceEquals(firstArray, null))
            {
                return 1;
            }
            else if (ReferenceEquals(secondArray, null))
            {
                return -1;
            }

            if (firstArray.Length == secondArray.Length)
            {
                return 0;
            }
            else if (firstArray.Length > secondArray.Length)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
