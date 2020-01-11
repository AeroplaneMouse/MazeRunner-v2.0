using System;

namespace MazeRunner_v2._0
{
	public class Pos
	{
		public int X;
		public int Y;

		/// <summary>
		/// Creates a new pos object with coordinates (0,0)
		/// </summary>
		public Pos()
			: this(0, 0)
		{ }

		/// <summary>
		/// Creates a new pos object with coordinates (x,y)
		/// </summary>
		/// <param name="x">The value of the x coordinate</param>
		/// <param name="y">The value of the y coordinate</param>
		public Pos(int x, int y)
		{
			X = x;
			Y = y;
		}

		/// <summary>
		/// Compares the X and Y values of this and the given Pos object
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>True if the X and Y values of this and given Pos object are equal. 
		/// False if not, or given object is not a Pos</returns>
		public override bool Equals(object obj)
		{
			if (obj is Pos b)
				return X == b.X && Y == b.Y;
			else
				return false;
		}
	}
}
