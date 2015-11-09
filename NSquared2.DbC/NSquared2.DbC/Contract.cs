using System;
using System.Diagnostics;

namespace NSquared2.DbC
{
    public static class Contract
	{
		[DebuggerHidden]
		public static Validation<T> Require<T>(T @object, string argumentName)
		{
			return GetValidation(@object, argumentName);
		}

		private static Validation<T> GetValidation<T>(T @object, string argumentName)
		{
			RequireT(@object);
			RequireArgumentName(argumentName);
			var paramMember = GetParamMember(@object, argumentName);
			return new Validation<T>(paramMember);
		}

		private static void RequireT<T>(T @object)
		{
			if (@object == null)
				throw new ArgumentNullException("@object", "input for contract cannot be null! You must specify some object for validation!");
		}

		private static void RequireArgumentName(string argumentName)
		{
			if (argumentName == null)
				throw new ArgumentNullException("argumentName", "inputparam argumentName cannot be null! You must specify a name, this name is udes for the contract exception restult!");
		}

		private static ParamMember<T> GetParamMember<T>(T @object, string argumentName)
		{
			var member = argumentName;
			return new ParamMember<T> { MemberName = member, ParamValue = @object };
		}
	}
}