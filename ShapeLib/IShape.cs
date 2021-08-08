using System;

namespace ShapeLib {
	/// <summary>
	///		General interface for shape.
	/// </summary>
	public interface IShape : IEquatable<IShape> {
		/// <summary>
		///		Returns square of the shape.
		/// </summary>
		public double Square { get; }
		/// <summary>
		///		Returns name of the shape.
		/// </summary>
		public string ShapeName { get; }
	}
}
