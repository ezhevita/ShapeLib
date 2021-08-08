using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeLib.Shapes;

namespace ShapeLib.Tests {
	[TestClass]
	public class TriangleTests {
		[TestMethod]
		public void ShouldBeEqual() {
			double[] firstTriangleSides = { 6, 5, 4 };
			Triangle firstTriangle = new(firstTriangleSides[0], firstTriangleSides[1], firstTriangleSides[2]);

			double[] secondTriangleSides = { 5, 4, 6 };
			Triangle secondTriangle = new(secondTriangleSides[0], secondTriangleSides[1], secondTriangleSides[2]);

			Assert.IsTrue(firstTriangle.Sides.ToArray().SequenceEqual(firstTriangleSides));
			Assert.IsTrue(secondTriangle.Sides.ToArray().SequenceEqual(secondTriangleSides));

			Assert.AreEqual(firstTriangle.GetHashCode(), secondTriangle.GetHashCode());

			Assert.IsTrue(firstTriangle.Equals(firstTriangle));
			Assert.IsTrue(((IShape)firstTriangle).Equals(firstTriangle));

			Assert.IsFalse(firstTriangle.Equals(null));

			Assert.IsTrue(firstTriangle.Equals(secondTriangle));
			Assert.IsTrue(((IShape)firstTriangle).Equals(secondTriangle));
			Assert.IsTrue(((object)firstTriangle).Equals(secondTriangle));
		}

		[TestMethod]
		public void ShouldBeEqualiteralRectangle() {
			Triangle triangle = new(3, 3, 3);
			Assert.IsTrue(triangle.IsEquilateralTriangle);
		}

		[TestMethod]
		public void ShouldBeRightRectangle() {
			Triangle triangle = new(3, 4, 5);
			Assert.IsTrue(triangle.IsRightTriangle);
		}

		[TestMethod]
		public void ShouldHaveCorrectName() {
			IShape triangle = new Triangle(3, 4, 5);

			Assert.AreEqual(triangle.ShapeName, nameof(Triangle));
		}

		[TestMethod]
		public void ShouldHaveCorrectSquare() {
			IShape firstTriangle = new Triangle(14, 13, 15);
			IShape secondTriangle = new Triangle(3, 4, 5);

			Assert.AreEqual(firstTriangle.Square, 84.0d);
			Assert.AreEqual(secondTriangle.Square, 6.0d);
		}

		[TestMethod]
		public void ShouldNotBeEqualiteralRectangle() {
			Triangle triangle = new(3, 4, 3);
			Assert.IsFalse(triangle.IsEquilateralTriangle);
		}

		[TestMethod]
		public void ShouldNotBeRightRectangle() {
			Triangle triangle = new(3, 4, 6);
			Assert.IsFalse(triangle.IsRightTriangle);
		}

		[ExpectedException(typeof(ArgumentException))]
		[TestMethod]
		public void ShouldThrowOnNaNSide() {
			Triangle _ = new(10, double.NaN, 40);
			Assert.Fail();
		}

		[ExpectedException(typeof(ArgumentException))]
		[TestMethod]
		public void ShouldThrowOnNegativeInfiniteSide() {
			Triangle _ = new(10, 20, double.NegativeInfinity);
			Assert.Fail();
		}

		[ExpectedException(typeof(ArgumentException))]
		[TestMethod]
		public void ShouldThrowOnNegativeSide() {
			Triangle _ = new(10, 20, -40);
			Assert.Fail();
		}

		[ExpectedException(typeof(ArgumentException))]
		[TestMethod]
		public void ShouldThrowOnNotPossibleSides() {
			Triangle _ = new(10, 20, 40);
			Assert.Fail();
		}

		[ExpectedException(typeof(ArgumentException))]
		[TestMethod]
		public void ShouldThrowOnPositiveInfiniteSide() {
			Triangle _ = new(10, 20, double.PositiveInfinity);
			Assert.Fail();
		}
	}
}
