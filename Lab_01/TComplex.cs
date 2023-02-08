namespace Lab_01
{
    public class TComplex
    {
        protected double Real;
        protected double Imaginary;

        /// <summary>
        /// Create a complex number with real and imaginary parts equal to zero.
        /// </summary>
        public TComplex()
        {
            Real = 0;
            Imaginary = 0;
        }

        /// <summary>
        /// Create a complex number with real and imaginary parts.
        /// </summary>
        /// <param name="real">Real part of complex number</param>
        /// <param name="imaginary">Imaginary part of complex number</param>
        public TComplex(double real, double imaginary = 0)
        {
            Real = real;
            Imaginary = imaginary;
        }

        /// <summary>
        /// Create a complex number with real and imaginary parts from another complex number.
        /// </summary>
        /// <param name="complex">Complex number</param>
        public TComplex(TComplex complex)
        {
            Real = complex.Real;
            Imaginary = complex.Imaginary;
        }

        /// <summary>
        /// Input real and imaginary parts of complex number
        /// </summary>
        public void Input()
        {
            Console.Write("Уведіть дійсну частину: ");
            if (!double.TryParse(Console.ReadLine(), out double RealTemp))
            {
                Console.WriteLine("\nПомилка введення дійсної частини!\n");
                Input();
                return;
            }

            Console.Write("Уведіть уявну частину: ");
            if (!double.TryParse(Console.ReadLine(), out double ImaginaryTemp))
            {
                Console.WriteLine("\nПомилка введення уявної частини!\n");
                Input();
                return;
            }

            Real = RealTemp;
            Imaginary = ImaginaryTemp;
        }

        /// <summary>
        /// Print complex number in the form a + bi.
        /// </summary>
        public void Print()
        {
            Console.WriteLine(ToString());
        }

        /// <summary>
        /// Convert complex number to string.
        /// </summary>
        /// <returns>A string representing complex number in the form a + bi.</returns>
        public override string ToString()
        {
            return Real + " " + (Imaginary >= 0 ? "+" : "-") + " " + Math.Abs(Imaginary) + "i";
        }

        /// <summary>
        /// Addition of two complex numbers.
        /// </summary>
        /// <param name="w">First complex number.</param>
        /// <param name="z">Second complex number.</param>
        /// <returns>A TComplex object representing result of addition.</returns>
        public static TComplex operator +(TComplex w, TComplex z)
        {
            return new TComplex(w.Real + z.Real, w.Imaginary + z.Imaginary);
        }

        /// <summary>
        /// Subtraction of two complex numbers.
        /// </summary>
        /// <param name="w">First complex number.</param>
        /// <param name="z">Second complex number.</param>
        /// <returns>A TComplex object representing result of subtraction.</returns>
        public static TComplex operator -(TComplex w, TComplex z)
        {
            return new TComplex(w.Real - z.Real, w.Imaginary - z.Imaginary);
        }

        /// <summary>
        /// Multiplication of two complex numbers.
        /// </summary>
        /// <param name="w">First complex number.</param>
        /// <param name="z">Second complex number.</param>
        /// <returns>A TComplex object representing result of multiplication.</returns>
        public static TComplex operator *(TComplex w, TComplex z)
        {
            return new TComplex(w.Real * z.Real - w.Imaginary * z.Imaginary,
                w.Real * z.Imaginary + w.Imaginary * z.Real);
        }

        /// <summary>
        /// Division of two complex numbers.
        /// </summary>
        /// <param name="w">First complex number.</param>
        /// <param name="z">Second complex number.</param>
        /// <returns>A TComplex object representing result of division.</returns>
        /// <exception cref="DivideByZeroException">Thrown when second complex number is zero.</exception>
        public static TComplex operator /(TComplex w, TComplex z)
        {
            if (z.Real == 0 && z.Imaginary == 0)
            {
                throw new DivideByZeroException();
            }

            return new TComplex(
                (w.Real * z.Real + w.Imaginary * z.Imaginary) / (z.Real * z.Real + z.Imaginary * z.Imaginary),
                (w.Real * z.Imaginary - w.Imaginary * z.Real) / (z.Real * z.Real + z.Imaginary * z.Imaginary)
            );
        }

    }
}