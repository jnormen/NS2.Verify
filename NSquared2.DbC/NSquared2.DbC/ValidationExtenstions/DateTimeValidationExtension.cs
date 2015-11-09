using System;
using System.Diagnostics;

namespace NSquared2.DbC.ValidationExtenstions
{
    public static class DateTimeValidationExtension
	{
		[DebuggerHidden]
		public static Validation<DateTime> IsNotDefault(this Validation<DateTime> item)
		{
			if (item.Value == new DateTime())
				throw new ArgumentNullException(string.Format("InputParam '{0}' cannot deafult value: '{1}'", item.ParameterName, item.Value));

			return item;
		}

		[DebuggerHidden]
		public static Validation<DateTime?> IsNotNull(this Validation<DateTime?> item)
		{
			if (!item.Value.HasValue)
				throw new ArgumentNullException(string.Format("InputParam '{0}' cannot be null", item.ParameterName, item.Value));

			return item;
		}
	}
}