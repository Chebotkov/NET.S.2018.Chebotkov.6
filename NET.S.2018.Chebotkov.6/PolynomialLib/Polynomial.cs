using System;

namespace PolynomialLib
{
    /// <summary>
    /// This class contains different operations for polynomials.
    /// </summary>
    public class Polynomial
    {
        private readonly double[] polynomial;

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// </summary>
        /// <param name="polynomial">Received polynomial.</param>
        public Polynomial(double[] polynomial)
        {
            this.polynomial = polynomial;
        }

        /// <summary>
        /// Gets array of coefficients of the powers of a variable.
        /// </summary>
        public double[] PolynomialValue
        {
            get
            {
                return polynomial;
            }
        }

        /// <summary>
        /// This method checks identity of polynomials.
        /// </summary>
        /// <param name="first">First polynomial.</param>
        /// <param name="second">Second polynomial.</param>
        /// <returns>True if they are identity</returns>
        public static bool operator ==(Polynomial first, Polynomial second)
        {
            Random random = new Random();
            double xValue = random.NextDouble();
            int countOfChecks = first.PolynomialValue.Length < second.PolynomialValue.Length ? second.PolynomialValue.Length : first.PolynomialValue.Length;
            double firstResult = 0, secondResult = 0;
            for (int i = 0; i < countOfChecks; i++)
            {
                for (int j = 0; j < first.PolynomialValue.Length; j++)
                {
                    firstResult += first.PolynomialValue[j] * Math.Pow(xValue, i);
                }

                for (int j = 0; j < second.PolynomialValue.Length; j++)
                {
                    secondResult += second.PolynomialValue[j] * Math.Pow(xValue, i);
                }
                if(firstResult != secondResult)
                {
                    return false;
                }

                xValue = random.NextDouble();
                firstResult = 0;
                secondResult = 0;
            }

            return true;
        }

        /// <summary>
        /// This method checks identity of polynomials.
        /// </summary>
        /// <param name="first">First polynomial.</param>
        /// <param name="second">Second polynomial.</param>
        /// <returns>True if they are not identity.</returns>
        public static bool operator !=(Polynomial first, Polynomial second)
        {
            return first == second ? false : true;
        }

        /// <summary>
        /// This method returns sum of polynomials.
        /// </summary>
        /// <param name="first">First polynomial.</param>
        /// <param name="second">Second polynomial.</param>
        /// <returns>Returns sum of polynomials.</returns>
        public static Polynomial operator +(Polynomial first, Polynomial second)
        {
            double[] result = new double[first.PolynomialValue.Length < second.PolynomialValue.Length ? second.PolynomialValue.Length : first.PolynomialValue.Length];
            
            for (int i = 0; i < result.Length; i++)
            {
                if (first.PolynomialValue.Length < second.PolynomialValue.Length && i >= first.PolynomialValue.Length)
                {
                    result[i] = second.PolynomialValue[i];
                }
                else if (first.PolynomialValue.Length > second.PolynomialValue.Length && i >= second.PolynomialValue.Length)
                {
                    result[i] = first.PolynomialValue[i];
                }
                else
                {
                    result[i] = first.polynomial[i] + second.polynomial[i];
                }
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// This method returns difference of polynomials.
        /// </summary>
        /// <param name="first">First polynomial.</param>
        /// <param name="second">Second polynomial.</param>
        /// <returns>Returns difference of polynomials.</returns>
        public static Polynomial operator -(Polynomial first, Polynomial second)
        {
            double[] result = new double[first.PolynomialValue.Length < second.PolynomialValue.Length ? second.PolynomialValue.Length : first.PolynomialValue.Length];
            for (int i = 0; i < result.Length; i++)
            {
                if (first.PolynomialValue.Length < second.PolynomialValue.Length && i >= first.PolynomialValue.Length)
                {
                    result[i] = -second.PolynomialValue[i];
                }
                else if (first.PolynomialValue.Length > second.PolynomialValue.Length && i >= second.PolynomialValue.Length)
                {
                    result[i] = first.PolynomialValue[i];
                }
                else
                {
                    result[i] = first.polynomial[i] - second.polynomial[i];
                }
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// This method returns result of multiplication of polynomials.
        /// </summary>
        /// <param name="first">First polynomial.</param>
        /// <param name="second">Second polynomial.</param>
        /// <returns>Returns result of multiplication of polynomials.</returns>
        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            double[] result = new double[first.PolynomialValue.Length + second.PolynomialValue.Length - 1];
            for (int i = 0; i < first.PolynomialValue.Length; i++)
            {
                for (int j = 0; j < second.PolynomialValue.Length; j++)
                {
                    result[i + j] += first.PolynomialValue[i] * second.PolynomialValue[j]; 
                }
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// This function checks "algebraic equality";
        /// </summary>
        /// <param name="polynomial">Second object.</param>
        /// <returns>Returns true if all coeffitients are equal.</returns>
        public override bool Equals(object polynomial)
        {
            Polynomial receivedValue = (Polynomial) polynomial;
            if (this.PolynomialValue.Length != receivedValue.PolynomialValue.Length)
            {
                return false;
            }

            for (int i = 0; i < receivedValue.PolynomialValue.Length; i++)
            {
                if (receivedValue.PolynomialValue[i] != this.PolynomialValue[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// This function calculates hash code for current object.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = 0;
            for (int i = 0; i < PolynomialValue.Length; i++)
            {
                hashCode += (int)PolynomialValue[i] ^ i;
            }

            return hashCode;
        }

        /// <summary>
        /// This function returns string representation of current object. 
        /// </summary>
        /// <returns>String value.</returns>
        public override string ToString()
        {
            return String.Concat(PolynomialValue);
        }
    }
}
