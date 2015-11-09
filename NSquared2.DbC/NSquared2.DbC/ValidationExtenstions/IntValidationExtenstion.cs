using System;
using System.Diagnostics;

namespace NSquared2.DbC.ValidationExtenstions
{
    public static class IntValidationExtenstion
	{

		[DebuggerHidden]
		public static Validation<int> NotLessThan(this Validation<int> item, int value)
		{
			if (item.Value < value)
				throw new ArgumentOutOfRangeException(string.Format("InputParam '{0}' cannot be less than '{1}'", item.ParameterName, value));

			return item;
		}

		[DebuggerHidden]
		public static Validation<int> NotGreaterThan(this Validation<int> item, int value)
		{
			if (item.Value > value)
				throw new ArgumentOutOfRangeException(string.Format("InputParam '{0}' cannot be greater than '{1}'", item.ParameterName, value));

			return item;
		}
	}
}