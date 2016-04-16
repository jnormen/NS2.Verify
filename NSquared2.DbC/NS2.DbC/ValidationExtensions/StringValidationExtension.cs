using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace NS2.DbC
{
    public static class StringValidationExtension
	{
		[DebuggerHidden]
		public static Validation<string> NotShorterThan(this Validation<string> item, int value)
		{
			if (item.Value.Length < value)
				throw new ArgumentOutOfRangeException($"InputParam '{item.ParameterName}' cannot be less than '{value}'");

			return item;
		}

		[DebuggerHidden]
		public static Validation<string> NotLongerThan(this Validation<string> item, int value)
		{
			if (item.Value.Length > value)
				throw new ArgumentOutOfRangeException($"InputParam '{item.ParameterName}' cannot be greater than '{value}'");

			return item;
		}

		[DebuggerHidden]
		public static Validation<string> NotNullOrEmpty(this Validation<string> item)
		{
			if (string.IsNullOrWhiteSpace(item.Value))
				throw  new ArgumentNullException($"Parameter '{item.ParameterName}' cannot be null or empty string!");
			return item;
		}

		[DebuggerHidden]
		public static Validation<string> StartsWith(this Validation<string> item, string pattern)
		{
			if (string.IsNullOrWhiteSpace(pattern))
				throw new ArgumentException("InputParam 'pattern' for StartsWith cannot be null or empty!");

			if (item.Value != null && !item.Value.StartsWith(pattern))
				throw new ArgumentException($"Parameter '{item.ParameterName}' must start with '{pattern}'!");
			return item;
		}

		[DebuggerHidden]
		public static Validation<string> EndsWith(this Validation<string> item, string pattern)
		{
			if (string.IsNullOrWhiteSpace(pattern))
				throw new ArgumentException("InputParam 'pattern' for EndsWith cannot be null or empty!");

			if (item.Value != null && !item.Value.EndsWith(pattern))
				throw new ArgumentOutOfRangeException($"Parameter '{item.ParameterName}' must end with '{pattern}'!");
			return item;
		}

		[DebuggerHidden]
		public static Validation<string> ISBasedOn(this Validation<string> item, string regularExpression)
		{
			if (string.IsNullOrWhiteSpace(regularExpression))
				throw new ArgumentException("NotBasedOn cannot have an empty or null regularExspression!");

			if (!Regex.IsMatch(item.Value, regularExpression))
				throw new ArgumentException(
				    $"The regualarExrpession '{regularExpression}' don't match with the string '{item.ParameterName}'!");
			return item;
		}

		[DebuggerHidden]
		public static Validation<string> IsUrl(this Validation<string> item)
		{
			return
				item.ISBasedOn(
					@"/((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)/");
		}
		
		[DebuggerHidden]
		public static Validation<string> IsEmail(this Validation<string> item)
		{
			return
				item.ISBasedOn(
					@"^(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([;.](([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+)*$");
		}
	}
}