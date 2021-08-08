using System;

namespace ShapeLib.Shapes {
	public class Circle : Shape, IEquatable<Circle>, IComparable<Circle> {
		/// <summary>
		///		Create circle with specified radius.
		/// </summary>
		/// <param name="radius">Radius value of the circle.</param>
		public Circle(double radius) {
			ValidateValue(radius, nameof(radius));

			Radius = radius;
		}

		/// <summary>
		///		Radius value of the circle.
		/// </summary>
		public double Radius { get; }

		public override string ShapeName => nameof(Circle);

		/// <summary>
		///		Compares the current circle with another one and returns an integer
		///		that indicates whether the current instance precedes, follows, or occurs
		///		in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="other">Other circle instance.</param>
		/// <returns>A value that indicates the relative order of the circles being compared.</returns>
		public int CompareTo(Circle? other) {
			if (ReferenceEquals(this, other)) {
				return 0;
			}

			return other == null ? 1 : Radius.CompareTo(other.Radius);
		}

		public bool Equals(Circle? other) => (other != null) && Radius.Equals(other.Radius);

		// Uses multiplication by itself instead of Math.Pow since it's faster
		protected override double CalculateSquare() => Math.PI * Radius * Radius;

		public override bool Equals(IShape other) {
			if (ReferenceEquals(this, other)) {
				return true;
			}

			return other is Circle circle && Equals(circle);
		}

		public override bool Equals(object? other) => other is Circle circle && Equals(circle);

		public override int GetHashCode() => Radius.GetHashCode();
	}
}
