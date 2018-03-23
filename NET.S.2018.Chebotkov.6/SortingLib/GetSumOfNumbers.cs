namespace SortingLib
{
    /// <summary>
    /// Contains implementation of GetMinNumber algorithm.
    /// </summary>
    public class GetSumOfNumbers : IAlgorithm
    {
        /// <summary>
        /// This method returns sum of elements of array.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <returns>Integer number.</returns>
        public int Algorithm(int[] array)
        {
            int sum = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }
    }
}
