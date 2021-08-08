using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeLib.Shapes;

namespace ShapeLib.Tests {
	[TestClass]
	public class TriangleTests {
		[TestMethod]
		public void ShouldBeEqual() {
			Distance[] firstTriangleSides = { new(6), new(5), new(4) };
			Triangle firstTriangle = new(firstTriangleSides[0], firstTriangleSides[1], firstTriangleSides[2]);

			Distance[] secondTriangleSides = { new(5), new(4), new(6) };
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
			Distance side = new(3);
			Triangle triangle = new(side, side, side);
			Assert.IsTrue(triangle.IsEquilateralTriangle);
		}

		[TestMethod]
		public void ShouldBeRightRectangle() {
			Triangle triangle = new(new Distance(3), new Distance(4), new Distance(5));
			Assert.IsTrue(triangle.IsRightTriangle);
		}

		[TestMethod]
		public void ShouldHaveCorrectName() {
			IShape triangle = new Triangle(new Distance(3), new Distance(4), new Distance(5));

			Assert.AreEqual(triangle.ShapeName, nameof(Triangle));
		}

		[TestMethod]
		public void ShouldHaveCorrectSquare() {
			IShape firstTriangle = new Triangle(new Distance(14), new Distance(13), new Distance(15));
			IShape secondTriangle = new Triangle(new Distance(3), new Distance(4), new Distance(5));

			Assert.AreEqual(firstTriangle.Square, 84.0d);
			Assert.AreEqual(secondTriangle.Square, 6.0d);
		}

		[TestMethod]
		public void ShouldNotBeEqualiteralRectangle() {
			Triangle triangle = new(new Distance(3), new Distance(4), new Distance(3));
			Assert.IsFalse(triangle.IsEquilateralTriangle);
		}

		[TestMethod]
		public void ShouldNotBeRightRectangle() {
			Triangle triangle = new(new Distance(3), new Distance(4), new Distance(6));
			Assert.IsFalse(triangle.IsRightTriangle);
		}

		[ExpectedException(typeof(ArgumentException))]
		[TestMethod]
		public void ShouldThrowOnNotPossibleSides() {
			Triangle _ = new(new Distance(10), new Distance(20), new Distance(40));
			Assert.Fail();
		}
	}
}
