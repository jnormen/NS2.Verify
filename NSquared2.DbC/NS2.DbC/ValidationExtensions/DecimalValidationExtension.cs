using System;
using System.Diagnostics;

namespace NS2.Verify
{
    public static class DecimalValidationExtension
	{
		[DebuggerHidden]
		public static Validation<decimal> NotLessThan(this Validation<decimal> item, decimal value)
		{
			if (item.Value < value)
				throw new ArgumentOutOfRangeException($"InputParam '{item.ParameterName}' cannot be less than '{value}'");

			return item;
		}

		[DebuggerHidden]
		public static Validation<decimal> NotGreaterThan(this Validation<decimal> item, decimal value)
		{
			if (item.Value > value)
				throw new ArgumentOutOfRangeException($"InputParam '{item.ParameterName}' cannot be greater than '{value}'");

			return item;
		}
	}
}