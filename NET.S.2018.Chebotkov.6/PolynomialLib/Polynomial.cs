using System;
using System.IO;

namespace PolynomialLib
{
    /// <summary>
    /// This class contains different operations for polynomials.
    /// </summary>
    public sealed class Polynomial
    {
        private readonly double[] polynomial = { };
        private static readonly double epsilon;
        private static readonly int exponent;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// </summary>
        /// <param name="polynomial">Received polynomial.</param>
        public Polynomial(params double[] polynomial)
        {
            this.polynomial = new double[polynomial.Length];
            Array.Copy(polynomial, this.polynomial, polynomial.Length);
        }

        /// <summary>
        /// Initializes static members of the <see cref="Polynomial"/> class.
        /// </summary>
        static Polynomial()
        {
            try
            {
                double.Parse(System.Configuration.ConfigurationManager.AppSettings["epsilon"]);         
            }
            catch(IOException)
            {
                epsilon = 1e-6;
            }
            finally
            { 
                exponent = GetExponent(epsilon);
            }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Gets array of coefficients of the powers of a variable.
        /// </summary>
        public double[] PolynomialValue
        {
            get
            {
                double[] newArr = new double[polynomial.Length];
                Array.Copy(polynomial, newArr, polynomial.Length);
                return newArr;
            }
        }

        /// <summary>
        /// This method checks identity of polynomials.
        /// </summary>
        /// <param name="first">First polynomial.</param>
        /// <param name="second">Second polynomial.</param>
        /// <returns>Returns true if they are identity and false if aren't.</returns>
        public static bool operator ==(Polynomial first, Polynomial second)
        {
            if (ReferenceEquals(null, first)) return false;
            if (ReferenceEquals(first, second)) return true;


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
            return Operation(first, second, 1);
        }

        /// <summary>
        /// This method returns difference of polynomials.
        /// </summary>
        /// <param name="first">First polynomial.</param>
        /// <param name="second">Second polynomial.</param>
        /// <returns>Returns difference of polynomials.</returns>
        public static Polynomial operator -(Polynomial first, Polynomial second)
        {
            return Operation(first, second, -1);
        }

        /// <summary>
        /// This method returns result of multiplication of polynomials.
        /// </summary>
        /// <param name="first">First polynomial.</param>
        /// <param name="second">Second polynomial.</param>
        /// <returns>Returns result of multiplication of polynomials.</returns>
        /// <exception cref="ArgumentNullException">Throws when one ore both arguments is null.</exception>
        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            if (ReferenceEquals(null, first) || ReferenceEquals(null, second))
            {
                throw new ArgumentNullException("Polynomial can't be null");
            }

            double[] result = new double[first.PolynomialValue.Length + second.PolynomialValue.Length - 1];
            for (int i = 0; i < first.PolynomialValue.Length; i++)
            {
                for (int j = 0; j < second.PolynomialValue.Length; j++)
                {
                    result[i + j] += first.PolynomialValue[i] * second.PolynomialValue[j]; 
                }
            }
            
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Math.Round(result[i], exponent);
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
            if (ReferenceEquals(null, polynomial)) return false;
            if (ReferenceEquals(this, polynomial)) return true;

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
        #endregion

        #region Private methods

        /// <summary>
        /// This method returns sum of two polynomials.
        /// </summary>
        /// <param name="first">First polynomial.</param>
        /// <param name="second">Second polynomial.</param>
        /// <param name="sign">Sign (+1\-1).</param>
        /// <returns>Returns new polynomial after addition.</returns>
        /// <exception cref="ArgumentNullException">Throws when one ore both arguments is null.</exception>
        private static Polynomial Operation(Polynomial first, Polynomial second, int sign)
        {
            if (ReferenceEquals(null, first) || ReferenceEquals(null, second))
            {
                throw new ArgumentNullException("Polynomial can't be null");
            }

            double[] result = new double[first.PolynomialValue.Length < second.PolynomialValue.Length ? second.PolynomialValue.Length : first.PolynomialValue.Length];
            for (int i = 0; i < result.Length; i++)
            {
                if (first.PolynomialValue.Length < second.PolynomialValue.Length && i >= first.PolynomialValue.Length)
                {
                    result[i] = Math.Round(sign * second.PolynomialValue[i], exponent);
                }
                else if (first.PolynomialValue.Length > second.PolynomialValue.Length && i >= second.PolynomialValue.Length)
                {
                    result[i] = Math.Round(first.PolynomialValue[i], exponent);
                }
                else
                {
                    result[i] = Math.Round(first.polynomial[i] + sign * second.polynomial[i], exponent);
                }
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Returns exponent of epsilon.
        /// </summary>
        /// <param name="epsilon">Epsilon.</param>
        /// <returns>Exponent of epsilon.</returns>
        private static int GetExponent(double epsiloN)
        {
            int exponent = 0;
            while (epsiloN < 1)
            {
                epsiloN = epsiloN * 10;
                exponent++;
            }

            return exponent;
        }
        #endregion
    }
}
