using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace NS2.DbC
{
    public static class PropertiesValidationExtension
	{
		[DebuggerHidden]
		public static Validation<T> AllPropertiesMusthaveValueButExclude<T>(this Validation<T> item, params string[] ignoreMembers) where T : class
        {
			if (!ignoreMembers.Any())
				throw new ArgumentException("Don't use parameterless 'Ignore', use 'All' instead to check All properties!");

			var propertyInfos = item.Value.GetType().GetProperties();
			foreach (PropertyInfo propertyInfo in propertyInfos)
			{
				if (!ignoreMembers.Contains(propertyInfo.Name))
				{
					if (propertyInfo.GetValue(item.Value, null) == null)
						throw new ArgumentNullException($"Property '{propertyInfo.Name}' in '{item.ParameterName}' cannot be null!");
				}
			}
			return item;
		}

		[DebuggerHidden]
        public static Validation<T> IncludePropertiesThatMusthaveValue<T>(this Validation<T> item, params string[] ignoreMembers) where T : class
        {
			if (!ignoreMembers.Any())
				throw new ArgumentException("Don't use parameterless 'Ignore', use 'All' instead to check All properties!");

			var propertyInfos = item.Value.GetType().GetProperties();
			foreach (var propertyInfo in propertyInfos)
			{
				if (!ignoreMembers.Contains(propertyInfo.Name)) continue;
				if (propertyInfo.GetValue(item.Value, null) == null)
					throw new ArgumentNullException($"Property '{propertyInfo.Name}' in '{item.ParameterName}' cannot be null!");
			}

			return item;
		}

	    [DebuggerHidden]
        public static Validation<T> AllPropertiesMusthaveValue<T>(this Validation<T> item) where T : class
        {
			var propertyInfos = item.Value.GetType().GetProperties();
			foreach (var propertyInfo in propertyInfos)
			{
				if (propertyInfo.GetValue(item.Value, null) == null)
					throw new ArgumentNullException($"Property '{propertyInfo.Name}' in '{item.ParameterName}' cannot be null!");
			}

			return item;
		}
    }
}