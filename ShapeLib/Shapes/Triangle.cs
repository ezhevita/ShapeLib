using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeLib.Shapes {
	public class Triangle : Shape, IEquatable<Triangle> {
		private readonly Lazy<bool> CalculatedIsRightTriangle;
		private readonly double[] SortedSides;

		/// <summary>
		///		Create triangle instance with specified sides.
		/// </summary>
		/// <param name="firstSide">First side of the triangle.</param>
		/// <param name="secondSide">Second side of the triangle.</param>
		/// <param name="thirdSide">Third side of the triangle.</param>
		/// <exception cref="ArgumentException">Thrown if any of the sides is invalid or it's impossible to compose a triangle with specified sides.</exception>
		public Triangle(double firstSide, double secondSide, double thirdSide) {
			ValidateValue(firstSide, nameof(firstSide));
			ValidateValue(secondSide, nameof(secondSide));
			ValidateValue(thirdSide, nameof(thirdSide));

			if ((firstSide + secondSide <= thirdSide) || (firstSide + thirdSide <= secondSide) || (secondSide + thirdSide <= firstSide)) {
				throw new ArgumentException("Triangle can't be created from sides");
			}

			CalculatedIsRightTriangle = new Lazy<bool>(CalculateIsRightTriangle);
			Sides = new[] { firstSide, secondSide, thirdSide };
			SortedSides = Sides.OrderBy(x => x).ToArray();
		}

		/// <summary>
		///		Sides of the triangle, contains 3 elements.
		/// </summary>
		public IReadOnlyList<double> Sides { get; }

		/// <summary>
		///		Determines whether the triangle is right (one of the angles is 90°).
		/// </summary>
		public bool IsRightTriangle => CalculatedIsRightTriangle.Value;
		
		/// <summary>
		///		Determines whether the triangle is equilateral (all of the sides are equal).
		/// </summary>
		// ReSharper disable once CompareOfFloatsByEqualityOperator - values are stored as is from user input, so it won't differ if user input is the same
		public bool IsEquilateralTriangle => Sides.Skip(1).All(side => side == Sides[0]);

		public override string ShapeName => nameof(Triangle);

		public bool Equals(Triangle? other) {
			if (ReferenceEquals(null, other)) {
				return false;
			}

			if (ReferenceEquals(this, other)) {
				return true;
			}

			return SortedSides.SequenceEqual(other.SortedSides);
		}

		private bool CalculateIsRightTriangle() {
			double[] orderedSides = Sides.OrderBy(x => x).ToArray();

			// ReSharper disable once CompareOfFloatsByEqualityOperator - it should work fine on multiplication
			// Uses multiplication by itself instead of Math.Pow since it's faster
			return orderedSides[0] * orderedSides[0] + orderedSides[1] * orderedSides[1] == orderedSides[2] * orderedSides[2];
		}

		protected override double CalculateSquare() {
			double halfPerimeter = Sides.Sum() / 2;

			return Math.Sqrt(Sides.Aggregate(halfPerimeter, (value, side) => value * (halfPerimeter - side)));
		}

		public override bool Equals(IShape other) {
			if (ReferenceEquals(this, other)) {
				return true;
			}

			return other is Triangle triangle && Equals(triangle);
		}

		public override bool Equals(object? other) => other is Triangle triangle && Equals(triangle);

		public override int GetHashCode() => (SortedSides[0], SortedSides[1], SortedSides[2]).GetHashCode();
	}
}
