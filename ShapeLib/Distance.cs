using System;

namespace ShapeLib {
	public readonly struct Distance : IEquatable<Distance>, IComparable<Distance> {
		public int CompareTo(Distance other) => Value.CompareTo(other.Value);

		public bool Equals(Distance other) => Value.Equals(other.Value);

		public override bool Equals(object? obj) => obj is Distance other && Equals(other);

		public override int GetHashCode() => Value.GetHashCode();

		public static implicit operator double(Distance value) => value.Value;

		public double Value { get; }

		public Distance(double value) {
			ValidateValue(value);
			Value = value;
		}
		
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
