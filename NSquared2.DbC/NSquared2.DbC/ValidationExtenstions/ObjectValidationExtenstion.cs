using System;
using System.Diagnostics;

namespace NSquared2.DbC.ValidationExtenstions
{
    public static class ObjectValidationExtenstion
	{
		[DebuggerHidden]
		public static Validation<T> NotNull<T>(this Validation<T> item) where T : class
		{
			if (item.Value == null)
				throw new ArgumentNullException(string.Format("InputParam '{0}' cannot be null", item.ParameterName));

			return item;
		}

		[DebuggerHidden]
		public static Validation<T> IsOfType<T>(this Validation<T> item, Type type) where T : class
		{
			if (type.IsInstanceOfType(item))
				throw new ArgumentException(string.Format("InputParam '{0}' is not of type '{1}'", item.ParameterName, type));

			return item;
		}

		[DebuggerHidden]
		public static Validation<T> Must<T>(this Validation<T> item, Predicate<T> predicate) where T : class
		{
			if (predicate == null)
				throw new NullReferenceException(string.Format("Predicate for Must validation on item '{0}' cannot be null!", item.ParameterName));

			if (predicate.Invoke(item.Value))
				return item;

			throw new ArgumentException(string.Format("Validator '{0}' did not meet the expected validation cireteria for '{1}'", predicate.Method.Name, item.ParameterName));
		}
	}
}