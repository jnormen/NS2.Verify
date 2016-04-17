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
				throw new ArgumentException($"InputParam '{item.ParameterName}' cannot be an Empty guid '{item.Value}'");

			return item;
		}
	}
}