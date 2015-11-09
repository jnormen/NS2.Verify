using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace NSquared2.DbC.ValidationExtenstions
{
    public class PropertiesValidation<T> where T : class, new()
	{
		private readonly Validation<T> _item;

		public PropertiesValidation(Validation<T> item)
		{
			_item = item;
		}

		[DebuggerHidden]
		public Validation<T> Exclude(params Expression<Func<T, object>>[] f)
		{
			if (f == null || f.Length == 0)
				throw new ArgumentException("Don't use parameterless 'Ignore', use 'All' instead to check All properties!");

			var ignoreMembers = GetIgnoreMembers(f);

			var propertyInfos = _item.Value.GetType().GetProperties();
			foreach (PropertyInfo propertyInfo in propertyInfos)
			{
				if (!ignoreMembers.Contains(propertyInfo.Name))
				{
					if (propertyInfo.GetValue(_item.Value, null) == null)
						throw new ArgumentNullException(string.Format("Property '{0}' in '{1}' cannot be null!", propertyInfo.Name, _item.ParameterName));
				}
			}

			return _item;
		}

		[DebuggerHidden]
		public Validation<T> Include(params Expression<Func<T, object>>[] f)
		{
			if (f == null || f.Length == 0)
				throw new ArgumentException("Don't use parameterless 'Include', use 'All' or 'Ignore' instead to check properties!");

			var ignoreMembers = GetIgnoreMembers(f);

			var propertyInfos = _item.Value.GetType().GetProperties();
			foreach (var propertyInfo in propertyInfos)
			{
				if (!ignoreMembers.Contains(propertyInfo.Name)) continue;
				if (propertyInfo.GetValue(_item.Value, null) == null)
					throw new ArgumentNullException(string.Format("Property '{0}' in '{1}' cannot be null!", propertyInfo.Name, _item.ParameterName));
			}

			return _item;
		}

		private IList<string> GetIgnoreMembers(IEnumerable<Expression<Func<T, object>>> f)
		{
			return (from expression in f
			        select (expression.Body) as MemberExpression
			        into memberExpression where memberExpression != null select memberExpression.Member.Name).ToList();
		}

		[DebuggerHidden]
		public Validation<T> All()
		{
			var propertyInfos = _item.Value.GetType().GetProperties();
			foreach (var propertyInfo in propertyInfos)
			{
				if (propertyInfo.GetValue(_item.Value, null) == null)
					throw new ArgumentNullException(string.Format("Property '{0}' in '{1}' cannot be null!", propertyInfo.Name, _item.ParameterName));
			}

			return _item;
		}
	}
}