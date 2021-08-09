using System;

namespace ShapeLib {
	public readonly struct Distance : IEquatable<Distance>, IComparable<Distance> {
		/// <summary>
		///     Compares the current distance with another one and returns an integer
		///     that indicates whether the current instance precedes, follows, or occurs
		///     in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="other">Other distance instance.</param>
		/// <returns>A value that indicates the relative order of the distances being compared.</returns>
		public int CompareTo(Distance other) => Value.CompareTo(other.Value);

		public bool Equals(Distance other) => Value.Equals(other.Value);

		public override bool Equals(object? obj) => obj is Distance other && Equals(other);

		public override int GetHashCode() => Value.GetHashCode();

		/// <summary>
		///     Distance value.
		/// </summary>
		public double Value { get; }

		/// <summary>
		///     Creates distance instance.
		/// </summary>
		/// <param name="value">Underlying distance value.</param>
		public Distance(double value) {
			ValidateValue(value);
			Value = value;
		}

		/// <summary>
		///     Validates `double` value in order to make sure it's positive and not infinite number.
		/// </summary>
		/// <param name="value">Value to validate.</param>
		/// <param name="paramName">Value name - it will be thrown in exception if value is not valid.</param>
		/// <exception cref="ArgumentOutOfRangeException">Value is not valid, message contains exact reason.</exception>
		private static void ValidateValue(double value, string paramName = "") {
			switch (value) {
				case double.NegativeInfinity or double.PositiveInfinity:
					throw new ArgumentOutOfRangeException(paramName, "Value must be finite.");
				case double.NaN:
					throw new ArgumentOutOfRangeException(paramName, "Value must not be NaN.");
				case <= 0:
					throw new ArgumentOutOfRangeException(paramName, "Value must be positive.");
			}
		}
	}
}
