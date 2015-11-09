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
				throw new ArgumentOutOfRangeException(string.Format("InputParam '{0}' cannot be less than '{1}'", item.ParameterName, value));

			return item;
		}

		[DebuggerHidden]
		public static Validation<double> NotGreaterThan(this Validation<double> item, double value)
		{
			if (item.Value > value)
				throw new ArgumentOutOfRangeException(string.Format("InputParam '{0}' cannot be greater than '{1}'", item.ParameterName, value));

			return item;
		}
	}
}