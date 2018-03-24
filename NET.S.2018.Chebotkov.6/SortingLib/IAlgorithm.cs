namespace SortingLib
{
    /// <summary>
    /// Interface for "Strategy pattern".
    /// </summary>
    public interface IAlgorithm
    {
        /// <summary>
        /// This method implements determined algorithm.
        /// </summary>
        /// <param name="array">Array</param>
        /// <returns>Integer Number</returns>
        int ? Algorithm(int[] array);
    }
}
