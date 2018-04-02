using System.Collections;

namespace SortingLib
{
    /// <summary>
    /// Implements Icomparer. 
    /// </summary>
    public class Compare : IComparer
    {
        /// <summary>
        /// Compares two objects.
        /// </summary>
        /// <param name="a">First object.</param>
        /// <param name="b">Second object.</param>
        /// <returns>Returns '0' if objects are equal, '1' if second object bigger than first and '-1' if first object bigger than second.</returns>
        int IComparer.Compare(object a, object b)
        {
            if (ReferenceEquals(a, b))
            {
                return 0;
            }
            else if (ReferenceEquals(a, null))
            {
                return 1;
            }
            else if (ReferenceEquals(b, null))
            {
                return -1;
            }

            int[] x = (int[])a;
            int[] y = (int[])b;
            if (x.Length == y.Length)
            {
                return 0;
            }
            else if (x.Length > y.Length)
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

