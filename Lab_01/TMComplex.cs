namespace Lab_01
{
	public class TMComplex : TComplex
	{
		public TMComplex() : base()
		{
		}

		public TMComplex(double real, double imaginary) : base(real, imaginary)
		{
		}

		public TMComplex(TComplex complex) : base(complex)
		{
		}

		/// <summary>
		/// Get the quadrant in which the complex number is located.
		/// </summary>
		/// <returns>Arabic number of quadrant.</returns>
		public int GetQuadrant()
		{
			/* 
                1-4 quadrants are numbered clockwise from the OX.
                5-8 axis are numbered clockwise from the OX. 
                0 - point is origin or on axis.
            */

			if (base.Real == 0 && base.Imaginary == 0) // If point is origin
			{
				return 0;
			}

			if (base.Real == 0) // If point is on axis
			{
				return base.Imaginary > 0 ? 6 : 8; // 1 - OY, 5 - -OY
			}

			if (base.Imaginary == 0) // If point is on axis
			{
				return base.Real > 0 ? 5 : 7; // 3 - OX, 7 - -OX
			}

			if (base.Real > 0) // If point is in 1 or 2 quadrant
			{
				return base.Imaginary > 0 ? 1 : 2; // 1 - 1st quadrant, 2 - 2nd quadrant
			}

			return base.Imaginary > 0 ? 3 : 4; // 3 - 3rd quadrant, 4 - 4th quadrant
		}

		/// <summary>
		/// Get distance from the origin (0,0) to the point (real, imaginary).
		/// </summary>
		/// <returns>Module of complex number.</returns>
		public double GetModulus()
		{
			// Modulus = sqrt(real^2 + imaginary^2)
			return Math.Sqrt(base.Real * base.Real + base.Imaginary * base.Imaginary);
		}
	}
}