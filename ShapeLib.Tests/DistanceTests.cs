using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShapeLib.Tests {
	[TestClass]
	public class DistanceTests {
		[TestMethod]
		public void ShouldBeComparable() {
			Distance a = new(5);
			Distance b = new(6);
			Distance c = new(5);

			Assert.AreEqual(a.CompareTo(b), -1);
			Assert.AreEqual(a.CompareTo(c), 0);
			Assert.AreEqual(b.CompareTo(c), 1);
		}

		[TestMethod]
		public void ShouldBeEqual() {
			const double distance = 5.0d;
			Distance a = new(distance);
			Distance b = new(distance);

			Assert.IsTrue(a.Equals(b));
			Assert.IsTrue(a.Equals((object)b));
			Assert.AreEqual(a.Value, distance);
			Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
		}

		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[TestMethod]
		public void ShouldThrowOnNaN() {
			Distance _ = new(double.NaN);
			Assert.Fail();
		}

		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[TestMethod]
		public void ShouldThrowOnNegative() {
			Distance _ = new(-5);
			Assert.Fail();
		}

		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[TestMethod]
		public void ShouldThrowOnNegativeInfinite() {
			Distance _ = new(double.NegativeInfinity);
			Assert.Fail();
		}

		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[TestMethod]
		public void ShouldThrowOnPositiveInfinite() {
			Distance _ = new(double.PositiveInfinity);
			Assert.Fail();
		}
	}
}
