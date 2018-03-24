namespace SortingLib
{
    /// <summary>
    /// Contains sorting algorithm for jagged array. 
    /// </summary>
    public static class JaggedArraySortingMethods
    {
        /// <summary>
        /// Certain algorithm.
        /// </summary>
        public static IAlgorithm ChosenAlgorithm { get; set; } = new GetSumOfNumbers();

        /// <summary>
        /// This method sorts jagged array with determined algorithm with "Bubble sorting". 
        /// </summary>
        /// <param name="jaggedArray">Jagged array</param>
        public static void Sort(int [][] jaggedArray)
        {
            int ? [] resultsOfMethod = new int ? [jaggedArray.Length];
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                resultsOfMethod[i] = ChosenAlgorithm.Algorithm(jaggedArray[i]);
            }

            Sorting.BubbleSorting(resultsOfMethod, jaggedArray);
        }
    }
}
