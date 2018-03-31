using NUnit.Framework;
using SortingLib;
using System.Collections;

namespace Sort.Tests
{
    [TestFixture]
    public class SortTests
    {
        [TestCase()]
        public void TestsForSort()
        {
            int[][] a = new int[][] { new int[] { 8, 3, 3, 7, 8, 4, 3 }, new int[] { 3, 7, 9, 1, 3 }, new int[] { 2, 6, 3, 7 } };
            int[][] b = new int[][] { new int[] { 2, 6, 3, 7 }, new int[] { 8, 3, 3, 7, 8, 4, 3 }, new int[] { 3, 7, 9, 1, 3 } };
            IComparer compare = new CompareBy(new GetMaxNumber());
            Sorting.BubbleSorting(a, compare);

            CollectionAssert.AreEqual(a, b);
        }

        [TestCase()]
        public void TestsForSort2()
        {
            int[][] a = new int[][] { new int[] { 8, 3, 3, 7, 8, 4, 3 }, new int[] { 3, 7, 9, 1, 3 }, new int[] { 2, 6, 3, 7 } };
            int[][] b = new int[][] { new int[] { 3, 7, 9, 1, 3 } , new int[] { 2, 6, 3, 7 }, new int[] { 8, 3, 3, 7, 8, 4, 3 }};

            IComparer compare = new CompareBy(new GetMinNumber());
            Sorting.BubbleSorting(a, compare);

            CollectionAssert.AreEqual(a, b);
        }

        [TestCase()]
        public void TestsForSort3()
        {
            int[][] a = new int[][] { new int[] { 8, 3, 3, 7, 8, 4, 3 }, new int[] { 3, 7, 9, 1, 3 }, new int[] { 2, 6, 3, 7 } };
            int[][] b = new int[][] { new int[] { 2, 6, 3, 7 }, new int[] { 3, 7, 9, 1, 3 }, new int[] { 8, 3, 3, 7, 8, 4, 3 } };

            IComparer compare = new CompareBy(new GetSumOfNumbers());
            Sorting.BubbleSorting(a, compare);

            CollectionAssert.AreEqual(a, b);
        }

        [TestCase()]
        public void TestsForSort4()
        {
            int[][] a = new int[][] { new int[] { 8, 3, 3, 7, 8, 4, 3 }, new int[] { 3, 7, 9, 1, 3 }, null, new int[] { 2, 6, 3, 7 } };
            int[][] b = new int[][] { new int[] { 2, 6, 3, 7 }, new int[] { 3, 7, 9, 1, 3 }, new int[] { 8, 3, 3, 7, 8, 4, 3 }, null };

            IComparer compare = new CompareBy(new GetSumOfNumbers());
            Sorting.BubbleSorting(a, compare);

            CollectionAssert.AreEqual(a, b);
        }

        [TestCase()]
        public void TestsForSort5()
        {
            int[][] a = new int[][] { new int[] { 8, 3, 3, 7, 8, 4, 3 }, new int[] { 3, 7, 9, 1, 3 }, null, null, null, new int[] { 2, 6, 3, 7 }, null };
            int[][] b = new int[][] { new int[] { 2, 6, 3, 7 }, new int[] { 3, 7, 9, 1, 3 }, new int[] { 8, 3, 3, 7, 8, 4, 3 }, null, null, null, null };
            
            IComparer compare = new CompareBy(new GetSumOfNumbers());
            Sorting.BubbleSorting(a, compare);

            CollectionAssert.AreEqual(a, b);
        }

        [TestCase()]
        public void TestsForSort6()
        {
            int[][] a = new int[][] { null, null, null, new int[] { 8, 3, 3, 7, 8, 4, 3 }, new int[] { 3, 7, 9, 1, 3 }, null, new int[] { 2, 6, 3, 7 } };
            int[][] b = new int[][] { new int[] { 2, 6, 3, 7 }, new int[] { 3, 7, 9, 1, 3 }, new int[] { 8, 3, 3, 7, 8, 4, 3 }, null, null, null, null };

            IComparer compare = new CompareBy(new GetSumOfNumbers());
            Sorting.BubbleSorting(a, compare);

            CollectionAssert.AreEqual(a, b);
        }
    }
}
