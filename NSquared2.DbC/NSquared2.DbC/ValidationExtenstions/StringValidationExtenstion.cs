using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace NSquared2.DbC.ValidationExtenstions
{
    public static class StringValidationExtenstion
	{
		[DebuggerHidden]
		public static Validation<string> NotShorterThan(this Validation<string> item, int value)
		{
			if (item.Value.Length < value)
				throw new ArgumentOutOfRangeException(string.Format("InputParam '{0}' cannot be less than '{1}'", item.ParameterName, value));

			return item;
		}

		[DebuggerHidden]
		public static Validation<string> NotLongerThan(this Validation<string> item, int value)
		{
			if (item.Value.Length > value)
				throw new ArgumentOutOfRangeException(string.Format("InputParam '{0}' cannot be greater than '{1}'", item.ParameterName, value));

			return item;
		}

		[DebuggerHidden]
		public static Validation<string> NotNullOrEmpty(this Validation<string> item)
		{
			if (string.IsNullOrWhiteSpace(item.Value))
				throw  new ArgumentNullException(string.Format("Parameter '{0}' cannot be null or empty string!", item.ParameterName));
			return item;
		}

		[DebuggerHidden]
		public static Validation<string> StartsWith(this Validation<string> item, string pattern)
		{
			if (string.IsNullOrWhiteSpace(pattern))
				throw new ArgumentException("InputParam 'pattern' for StartsWith cannot be null or empty!");

			if (item.Value != null && !item.Value.StartsWith(pattern))
				throw new ArgumentException(string.Format("Parameter '{0}' must start with '{1}'!", item.ParameterName, pattern));
			return item;
		}

		[DebuggerHidden]
		public static Validation<string> EndsWith(this Validation<string> item, string pattern)
		{
			if (string.IsNullOrWhiteSpace(pattern))
				throw new ArgumentException("InputParam 'pattern' for EndsWith cannot be null or empty!");

			if (item.Value != null && !item.Value.EndsWith(pattern))
				throw new ArgumentOutOfRangeException(string.Format("Parameter '{0}' must end with '{1}'!", item.ParameterName, pattern));
			return item;
		}

		[DebuggerHidden]
		public static Validation<string> ISBasedOn(this Validation<string> item, string regularExpression)
		{
			if (string.IsNullOrWhiteSpace(regularExpression))
				throw new ArgumentException("NotBasedOn cannot have an empty or null regularExspression!");

			if (!Regex.IsMatch(item.Value, regularExpression))
				throw new ArgumentException(string.Format("The regualarExrpession '{0}' don't match with the string '{1}'!", regularExpression, item.ParameterName));
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