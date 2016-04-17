using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NS2.Verify
{
    public static class IEnumerableValidationExtension
	{
		[DebuggerHidden]
		public static Validation<IEnumerable<T>> NotNullOrEmpty<T>(this Validation<IEnumerable<T>> items) where T : class
		{
			if (items.Value == null || !items.Value.Any())
				throw new ArgumentNullException($"InputParam '{items.ParameterName}' cannot be null or Empty");

			return items;
		}
	}
}