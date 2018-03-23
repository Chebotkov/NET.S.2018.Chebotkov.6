using NUnit.Framework;
using SortingLib;

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
            JaggedArraySortingMethods.ChosenAlgorithm = new GetMaxNumber();
            JaggedArraySortingMethods.Sort(a);

            CollectionAssert.AreEqual(a, b);
        }

        [TestCase()]
        public void TestsForSort2()
        {
            int[][] a = new int[][] { new int[] { 8, 3, 3, 7, 8, 4, 3 }, new int[] { 3, 7, 9, 1, 3 }, new int[] { 2, 6, 3, 7 } };
            int[][] b = new int[][] { new int[] { 3, 7, 9, 1, 3 } , new int[] { 2, 6, 3, 7 }, new int[] { 8, 3, 3, 7, 8, 4, 3 }};
            JaggedArraySortingMethods.ChosenAlgorithm = new GetMinNumber();
            JaggedArraySortingMethods.Sort(a);

            CollectionAssert.AreEqual(a, b);
        }

        [TestCase()]
        public void TestsForSort3()
        {
            int[][] a = new int[][] { new int[] { 8, 3, 3, 7, 8, 4, 3 }, new int[] { 3, 7, 9, 1, 3 }, new int[] { 2, 6, 3, 7 } };
            int[][] b = new int[][] { new int[] { 2, 6, 3, 7 }, new int[] { 3, 7, 9, 1, 3 }, new int[] { 8, 3, 3, 7, 8, 4, 3 } };
            JaggedArraySortingMethods.ChosenAlgorithm = new GetSumOfNumbers();
            JaggedArraySortingMethods.Sort(a);

            CollectionAssert.AreEqual(a, b);
        }
    }
}
