using System;
using System.Diagnostics;

namespace NSquared2.DbC.ValidationExtenstions
{
    public static class DoubleValidationExtenstion
	{
		[DebuggerHidden]
		public static Validation<double> NotLessThan(this Validation<double> item, double value)
		{
			if (item.Value < value)
				throw new ArgumentOutOfRangeException($"InputParam '{item.ParameterName}' cannot be less than '{value}'");

			return item;
		}

		[DebuggerHidden]
		public static Validation<double> NotGreaterThan(this Validation<double> item, double value)
		{
			if (item.Value > value)
				throw new ArgumentOutOfRangeException($"InputParam '{item.ParameterName}' cannot be greater than '{value}'");

			return item;
		}
	}
}