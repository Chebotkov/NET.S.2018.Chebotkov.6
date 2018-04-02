namespace SortingLib
{
    /// <summary>
    /// Contains implementation of GetMaxNumber algorithm.
    /// </summary>
    public class GetMaxNumber : IAlgorithm
    {
        /// <summary>
        /// This method returns max value in array.
        /// </summary>
        /// <param name="array">Array.</param>0
        /// <returns>Integer number.</returns>
        public int ? Algorithm(int[] array)
        {
            if (array is null)
            {
                return null; 
            }

            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            return max;
        }
    }
}
