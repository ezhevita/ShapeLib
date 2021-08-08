using System;

namespace ShapeLib.Shapes {
	/// <summary>
	///		General shape class with cacheable square.
	/// </summary>
	public abstract class Shape : IShape {
		protected Shape() => CalculatedSquare = new Lazy<double>(CalculateSquare);

		private Lazy<double> CalculatedSquare { get; }

		/// <summary>
		///		Returns square of the shape. Uses cached value if it was already calculated.
		/// </summary>
		public double Square => CalculatedSquare.Value;

		public abstract string ShapeName { get; }

		public abstract bool Equals(IShape other);

		/// <summary>
		///		Calculation method of square.
		/// </summary>
		/// <returns>Square value of the shape.</returns>
		protected abstract double CalculateSquare();

		public abstract override int GetHashCode();

		/// <summary>
		///		Validates `double` value in order to make sure it's positive and not infinite number.
		/// </summary>
		/// <param name="value">Value to validate.</param>
		/// <param name="paramName">Value name - it will be thrown in exception if value is not valid.</param>
		/// <exception cref="ArgumentException">Value is not valid, message contains exact reason.</exception>
		protected static void ValidateValue(double value, string paramName = "") {
			if (double.IsNegativeInfinity(value) || double.IsPositiveInfinity(value)) {
				throw new ArgumentOutOfRangeException(paramName, "Value must be finite.");
			}

			if (double.IsNaN(value)) {
				throw new ArgumentOutOfRangeException(paramName, "Value must not be NaN.");
			}

			if (value <= 0) {
				throw new ArgumentOutOfRangeException(paramName, "Value must be positive.");
			}
		}
	}
}
