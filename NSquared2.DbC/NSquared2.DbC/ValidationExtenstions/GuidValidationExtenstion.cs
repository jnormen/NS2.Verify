using System;
using System.Diagnostics;

namespace NSquared2.DbC.ValidationExtenstions
{
    public static class GuidValidationExtenstion
	{
		[DebuggerHidden]
		public static Validation<Guid> NotEmpty(this Validation<Guid> item)
		{
			if (item.Value == Guid.Empty)
				throw new ArgumentException(string.Format("InputParam '{0}' cannot be an Empty guid '{1}'", item.ParameterName, item.Value));

			return item;
		}
	}
}