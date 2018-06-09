using System;
using System.Diagnostics;

namespace UN2.EnsureThat
{
    public static class DateTimeValidationExtension
	{
		[DebuggerHidden]
		public static Validation<DateTime> IsNotDefault(this Validation<DateTime> item)
		{
			if (item.Value == new DateTime())
				throw new ArgumentNullException($"InputParam '{item.ParameterName}' cannot deafult value: '{item.Value}'");

			return item;
		}

		[DebuggerHidden]
		public static Validation<DateTime?> IsNotNull(this Validation<DateTime?> item)
		{
			if (!item.Value.HasValue)
				throw new ArgumentNullException($"InputParam '{item.ParameterName}' cannot be null");

			return item;
		}
	}
}