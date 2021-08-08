using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeLib.Shapes;

namespace ShapeLib.Tests {
	[TestClass]
	public class CircleTests {
		[TestMethod]
		public void ShouldBeComparable() {
			Circle[] circles = { new(6), new(4), new(5) };

			Assert.AreEqual(circles[0].CompareTo(circles[1]), 1);
			Assert.AreEqual(circles[1].CompareTo(circles[2]), -1);
			Assert.AreEqual(circles[0].CompareTo(circles[2]), 1);

			Array.Sort(circles);

			Assert.AreEqual(circles[0].Radius, 4);
			Assert.AreEqual(circles[1].Radius, 5);
			Assert.AreEqual(circles[2].Radius, 6);

			Assert.AreEqual(circles[0].CompareTo(null), 1);
			Assert.AreEqual(circles[0].CompareTo(circles[0]), 0);
		}

		[TestMethod]
		public void ShouldBeEqual() {
			Circle firstCircle = new(6);
			Circle secondCircle = new(6.0d);

			Assert.AreEqual(firstCircle.Radius, secondCircle.Radius);
			Assert.AreEqual(firstCircle.GetHashCode(), secondCircle.GetHashCode());

			Assert.IsTrue(firstCircle.Equals(firstCircle));
			Assert.IsTrue(((IShape)firstCircle).Equals(firstCircle));

			Assert.IsFalse(firstCircle.Equals(null));

			Assert.IsTrue(firstCircle.Equals(secondCircle));
			Assert.IsTrue(((IShape)firstCircle).Equals(secondCircle));
			Assert.IsTrue(((object)firstCircle).Equals(secondCircle));
		}

		[TestMethod]
		public void ShouldHaveCorrectName() {
			IShape circle = new Circle(3);

			Assert.AreEqual(circle.ShapeName, nameof(Circle));
		}

		[TestMethod]
		public void ShouldHaveCorrectSquare() {
			IShape firstCircle = new Circle(10 / Math.Sqrt(Math.PI));
			IShape secondCircle = new Circle(1);

			Assert.AreEqual(firstCircle.Square, 100.0d, 0.0000000001d);
			Assert.AreEqual(secondCircle.Square, Math.PI, 0.0000000001d);
		}

		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[TestMethod]
		public void ShouldThrowOnNaNRadius() {
			Circle _ = new(double.NaN);
			Assert.Fail();
		}

		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[TestMethod]
		public void ShouldThrowOnNegativeInfiniteRadius() {
			Circle _ = new(double.NegativeInfinity);
			Assert.Fail();
		}

		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[TestMethod]
		public void ShouldThrowOnNegativeRadius() {
			Circle _ = new(-5);
			Assert.Fail();
		}

		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[TestMethod]
		public void ShouldThrowOnPositiveInfiniteRadius() {
			Circle _ = new(double.PositiveInfinity);
			Assert.Fail();
		}
	}
}
