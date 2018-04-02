namespace SortingLib
{
    /// <summary>
    /// Contains implementation of GetMinNumber algorithm.
    /// </summary>
    public class GetMinNumber : IAlgorithm
    {
        /// <summary>
        /// This method returns min value in array.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <returns>Integer number.</returns>
        public int ? Algorithm(int[] array)
        {
            if (array is null)
            {
                return null;
            }

            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }
    }
}
