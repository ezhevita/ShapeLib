using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeLib.Shapes;

namespace ShapeLib.Tests {
	[TestClass]
	public class CircleTests {
		[TestMethod]
		public void ShouldBeComparable() {
			Circle[] circles = { new(new Distance(6)), new(new Distance(4)), new(new Distance(5)) };

			Assert.AreEqual(circles[0].CompareTo(circles[1]), 1);
			Assert.AreEqual(circles[1].CompareTo(circles[2]), -1);
			Assert.AreEqual(circles[0].CompareTo(circles[2]), 1);

			Array.Sort(circles);

			Assert.AreEqual(circles[0].Radius.Value, 4);
			Assert.AreEqual(circles[1].Radius.Value, 5);
			Assert.AreEqual(circles[2].Radius.Value, 6);

			Assert.AreEqual(circles[0].CompareTo(null), 1);
			Assert.AreEqual(circles[0].CompareTo(circles[0]), 0);
		}

		[TestMethod]
		public void ShouldBeEqual() {
			Circle firstCircle = new(new Distance(6));
			Circle secondCircle = new(new Distance(6.0d));

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
			IShape circle = new Circle(new Distance(3));

			Assert.AreEqual(circle.ShapeName, nameof(Circle));
		}

		[TestMethod]
		public void ShouldHaveCorrectSquare() {
			IShape firstCircle = new Circle(new Distance(10 / Math.Sqrt(Math.PI)));
			IShape secondCircle = new Circle(new Distance(1));

			Assert.AreEqual(firstCircle.Square, 100.0d, 0.0000000001d);
			Assert.AreEqual(secondCircle.Square, Math.PI, 0.0000000001d);
		}
	}
}
