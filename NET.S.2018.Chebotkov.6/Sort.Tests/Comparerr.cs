using System.Collections;

namespace SortingLib
{
    /// <summary>
    /// Implements Icomparer. 
    /// </summary>
    public class Comparerr : IComparer
    {
        /// <summary>
        /// Gets / sets certain algorithm.
        /// </summary>
        public static IAlgorithm ChosenAlgorithm { get; set; } = new GetSumOfNumbers();

        public Comparerr(IAlgorithm algorithm)
        {
            ChosenAlgorithm = algorithm;
        }

        /// <summary>
        /// Compares two objects.
        /// </summary>
        /// <param name="a">First object.</param>
        /// <param name="b">Second object.</param>
        /// <returns>Returns '0' if objects are equal, '1' if second object bigger than first and '-1' if first object bigger than second.</returns>
        int IComparer.Compare(object a, object b)
        {
            int? x = ChosenAlgorithm.Algorithm((int[])a);
            int? y = ChosenAlgorithm.Algorithm((int[])b);
            if (ReferenceEquals(x, y))
            {
                return 0;
            }
            else if (ReferenceEquals(x, null))
            {
                return 1;
            }
            else if (ReferenceEquals(y, null))
            {
                return -1;
            }

            if (x == y)
            {
                return 0;
            }
            else if (x > y)
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