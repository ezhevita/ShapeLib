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
	}
}
