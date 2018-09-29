
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp01
{
	public struct Shape
	{

		#region Properties

		public uint Rows
		{
			get { return _rows; }
			set
			{
				if (value < 1)
					throw new ArgumentOutOfRangeException();

				_rows = value;
			}
		}
		private uint _rows;

		public uint Columns
		{
			get { return _columns; }
			set
			{
				if (value < 1)
					throw new ArgumentOutOfRangeException();

				_columns = value;
			}
		}
		private uint _columns;

		#endregion


		#region Constructors

		public Shape(uint rows = 1, uint columns = 1)
		{
			if (rows < 1)
				throw new ArgumentOutOfRangeException("rows");
			if (columns < 1)
				throw new ArgumentOutOfRangeException("columns");

			_rows		= rows;
			_columns	= columns;
		}

		#endregion


		#region Operators

		public uint this[int key]
		{
			get
			{
				if (key < 0 || key > 1)
					throw new IndexOutOfRangeException();

				return (key == 0) ? _rows : _columns;
			}
			set
			{
				if (value < 1)
					throw new ArgumentOutOfRangeException();

				if (key == 0)
					_rows = value;
				else if (key == 1)
					_columns = value;
				else
					throw new IndexOutOfRangeException();
			}
		}

		public static implicit operator Shape(Tuple<uint, uint> shape)
		{
			return new Shape(shape.Item1, shape.Item2);
		}
		public static implicit operator Shape(Tuple<int, int> shape)
		{
			if (shape.Item1 < 0 || shape.Item2 < 0)
				throw new ArgumentOutOfRangeException("Shape values must be non-negative.");

			return new Shape((uint) shape.Item1, (uint) shape.Item2);
		}
		public static implicit operator Shape(uint[] shape)
		{
			if (shape == null)
				throw new ArgumentNullException();

			var result = new Shape();

			for (int i = 0; i < 2; i++)
				if (shape.Length > i)
				{
					if (shape[i] < 1)
						throw new ArgumentOutOfRangeException();

					result[i] = shape[i];
				}

			return result;
		}
		public static implicit operator Shape(int[] shape)
		{
			if (shape == null)
				throw new ArgumentNullException();

			var result = new Shape();

			for (int i = 0; i < 2; i++)
				if (shape.Length > i)
				{
					if (shape[i] < 1)
						throw new ArgumentOutOfRangeException();

					result[i] = (uint) shape[i];
				}

			return result;
		}

		#endregion

	}
}
