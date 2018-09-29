
using System;


namespace ConsoleApp01
{
	public class Shape
	{

		#region Properties

		public uint Rows
		{
			get { return _shape[0]; }
			set
			{
				if (value < 1)
					throw new ArgumentOutOfRangeException();

				_shape[0] = value;
			}
		}

		public uint Columns
		{
			get { return _shape[1]; }
			set
			{
				if (value < 1)
					throw new ArgumentOutOfRangeException();

				_shape[1] = value;
			}
		}

		private uint[] _shape;

		#endregion


		#region Constructors

		public Shape() : this(1, 1) { }

		public Shape(uint rows = 1, uint columns = 1)
		{
		
			if (rows < 1)
				throw new ArgumentOutOfRangeException("rows");
			if (columns < 1)
				throw new ArgumentOutOfRangeException("columns");

			_shape = new uint[] { rows, columns };
		}

		public Shape(Shape other)
		{
			_shape = new uint[other._shape.Length];

			Array.Copy(other._shape, _shape, _shape.Length);
		}

		#endregion


		#region Operators

		public uint this[int key]
		{
			get { return _shape[key]; }
			set
			{
				if (value < 1)
					throw new ArgumentOutOfRangeException();

				_shape[key] = value;
			}
		}

		public static implicit operator Shape(Tuple<uint, uint> shape)
		{
			return new Shape(shape.Item1, shape.Item2);
		}
		public static implicit operator Shape(Tuple<int, int> shape)
		{
			return new Shape((uint) shape.Item1, (uint) shape.Item2);
		}
		public static implicit operator Shape(uint[] shape)
		{
			if (shape == null)
				throw new ArgumentNullException();

			var result = new Shape();

			for (int i = 0; i < result._shape.Length; i++)
				if (shape.Length > i)
					result[i] = shape[i];

			return result;
		}
		public static implicit operator Shape(int[] shape)
		{
			if (shape == null)
				throw new ArgumentNullException();

			var result = new Shape();

			for (int i = 0; i < result._shape.Length; i++)
				if (shape.Length > i)
					result[i] = (uint) shape[i];

			return result;
		}

		#endregion

	}
}
