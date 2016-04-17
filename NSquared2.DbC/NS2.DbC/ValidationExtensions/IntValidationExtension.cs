using System;
using System.Diagnostics;

namespace NS2.Verify
{
    public static class IntValidationExtension
	{

		[DebuggerHidden]
		public static Validation<int> NotLessThan(this Validation<int> item, int value)
		{
			if (item.Value < value)
				throw new ArgumentOutOfRangeException($"InputParam '{item.ParameterName}' cannot be less than '{value}'");

			return item;
		}

		[DebuggerHidden]
		public static Validation<int> NotGreaterThan(this Validation<int> item, int value)
		{
			if (item.Value > value)
				throw new ArgumentOutOfRangeException($"InputParam '{item.ParameterName}' cannot be greater than '{value}'");

			return item;
		}
	}
}