using System;
using System.Diagnostics;

namespace NSquared2.DbC.ValidationExtenstions
{
    public static class DecimalValidationExtenstion
	{
		[DebuggerHidden]
		public static Validation<decimal> NotLessThan(this Validation<decimal> item, decimal value)
		{
			if (item.Value < value)
				throw new ArgumentOutOfRangeException(string.Format("InputParam '{0}' cannot be less than '{1}'", item.ParameterName, value));

			return item;
		}

		[DebuggerHidden]
		public static Validation<decimal> NotGreaterThan(this Validation<decimal> item, decimal value)
		{
			if (item.Value > value)
				throw new ArgumentOutOfRangeException(string.Format("InputParam '{0}' cannot be greater than '{1}'", item.ParameterName, value));

			return item;
		}
	}
}