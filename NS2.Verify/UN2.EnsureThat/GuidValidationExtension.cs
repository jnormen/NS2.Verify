using System;
using System.Diagnostics;

namespace UN2.EnsureThat
{
    public static class GuidValidationExtension
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