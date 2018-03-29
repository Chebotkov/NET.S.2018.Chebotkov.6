using NUnit.Framework;

namespace Polynomial.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        [TestCase(true, new double[] { 5.023, 3.08, 3.09, 2.1}, new double[] { 5.023, 3.08, 3.09, 2.1})]
        [TestCase(true, new double[] { 4, 2, 4, 2 }, new double[] { 2, 4, 2, 4})]
        [TestCase(false, new double[] { 4, 4, 4, 2 }, new double[] { 2, 4, 2, 4 })]
        public void EqualOperatorTests(bool expected, double[] a1, double[] a2)
        {
            PolynomialLib.Polynomial polynomial1 = new PolynomialLib.Polynomial(a1);
            PolynomialLib.Polynomial polynomial2 = new PolynomialLib.Polynomial(a2);

            Assert.AreEqual(expected, polynomial1 == polynomial2);
        }

        [TestCase(false, new double[] { 5.023, 3.08, 3.09, 2.1 }, new double[] { 5.023, 3.08, 3.09, 2.1 })]
        [TestCase(false, new double[] { 4, 2, 4, 2 }, new double[] { 2, 4, 2, 4 })]
        [TestCase(true, new double[] { 4, 4, 4, 2 }, new double[] { 2, 4, 2, 4 })]
        public void DoestNotEqualOperatorTests(bool expected, double[] a1, double[] a2)
        {
            PolynomialLib.Polynomial polynomial1 = new PolynomialLib.Polynomial(a1);
            PolynomialLib.Polynomial polynomial2 = new PolynomialLib.Polynomial(a2);

            Assert.AreEqual(expected, polynomial1 != polynomial2);
        }

        [TestCase(true, new double[] { 5.023, 3.08, 3.09, 2.1 }, new double[] { 5.023, 3.08, 3.09, 2.1 })]
        [TestCase(false, new double[] { 5.023, 3.08, 3.09, 2.1 }, new double[] { 5.023, 3.08, 3.09 })]
        [TestCase(false, new double[] { 5.023, 3.08, 3.09, 2.1 }, new double[] { 5.023, 3.08, 3.09, 2.01 })]
        public void EqualsTests(bool expected, double[] a1, double[] a2)
        {
            PolynomialLib.Polynomial polynomial1 = new PolynomialLib.Polynomial(a1);
            PolynomialLib.Polynomial polynomial2 = new PolynomialLib.Polynomial(a2);

            Assert.AreEqual(expected, polynomial1.Equals(polynomial2));
        }

        [TestCase("3333", new double[] { 3, 3, 3, 3 })]
        public void ToStringTests(string expected, double[] a1)
        {
            PolynomialLib.Polynomial polynomial1 = new PolynomialLib.Polynomial(a1);

            Assert.AreEqual(expected, polynomial1.ToString());
        }

        [TestCase(new double[] { 7, 7.2, 7, 7.3 }, new double[] { 4, 4.2, 4, 4 }, new double[] { 3, 3, 3, 3.3 })]
        [TestCase(new double[] { 7, 7.2, 7, 7.3, 7.8, 7, 9 }, new double[] { 4, 4.2, 4, 4 }, new double[] { 3, 3, 3, 3.3, 7.8, 7,9 })]
        [TestCase(new double[] { 7, 7.2, 7, 7.3, 7.8, 7, 9 }, new double[] { 4, 4.2, 4, 4, 7.8, 7, 9 }, new double[] { 3, 3, 3, 3.3, })]
        public void PlusOperatorTests(double[] expected, double[] a1, double[] a2)
        {
            PolynomialLib.Polynomial polynomial1 = new PolynomialLib.Polynomial(a1);
            PolynomialLib.Polynomial polynomial2 = new PolynomialLib.Polynomial(a2);
            PolynomialLib.Polynomial polynomial3 = polynomial1 + polynomial2;
            PolynomialLib.Polynomial expectedP = new PolynomialLib.Polynomial(expected);
            
            Assert.AreEqual(expectedP, polynomial3);
        }

        [TestCase(new double[] { 1, 1.2, 1, 0.7 }, new double[] { 4, 4.2, 4, 4 }, new double[] { 3, 3, 3, 3.3 })]
        [TestCase(new double[] { 1, 1.2, 1, 0.7, -7.8, -7, -9 }, new double[] { 4, 4.2, 4, 4 }, new double[] { 3, 3, 3, 3.3, 7.8, 7, 9 })]
        [TestCase(new double[] { 1, 1.2, 1, 0.7, 7.8, 7, 9 }, new double[] { 4, 4.2, 4, 4, 7.8, 7, 9 }, new double[] { 3, 3, 3, 3.3, })]
        public void MinusOperatorTests(double[] expected, double[] a1, double[] a2)
        {
            PolynomialLib.Polynomial polynomial1 = new PolynomialLib.Polynomial(a1);
            PolynomialLib.Polynomial polynomial2 = new PolynomialLib.Polynomial(a2);
            PolynomialLib.Polynomial polynomial3 = polynomial1 - polynomial2;

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], polynomial3.PolynomialValue[i]);
            }
        }

        [TestCase(new double[] { 12, 24.6, 36.6, 49.8, 37.86, 25.2, 13.2 }, new double[] { 4, 4.2, 4, 4 }, new double[] { 3, 3, 3, 3.3 })]
        [TestCase(new double[] { 12, 24.6, 36.6, 49.8, 69.06, 85.96, 109.8, 97, 64, 36}, new double[] { 4, 4.2, 4, 4 }, new double[] { 3, 3, 3, 3.3, 7.8, 7, 9 })]
        [TestCase(new double[] { 12, 24.6, 36.6, 49.8, 61.26, 69.6, 84.6, 73.74, 50.1, 29.7}, new double[] { 4, 4.2, 4, 4, 7.8, 7, 9 }, new double[] { 3, 3, 3, 3.3, })]
        public void MultiplyOperatorTests(double[] expected, double[] a1, double[] a2)
        {
            PolynomialLib.Polynomial polynomial1 = new PolynomialLib.Polynomial(a1);
            PolynomialLib.Polynomial polynomial2 = new PolynomialLib.Polynomial(a2);
            PolynomialLib.Polynomial polynomial3 = polynomial1 * polynomial2;

            for (int i=0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], polynomial3.PolynomialValue[i]);
            }
        }
    }
}
