//// Created first as a part of Contact.Require framework 2005 and
//// got renamed to a more fluent friendly naming convention
//// Created by Johan Normén based on a POC by Roger Alsing (Johansson), Fredrik Normén and Johan Normén
using System;
using System.Diagnostics;

namespace UN2.EnsureThat
{
    public static class Ensure
	{
        [DebuggerHidden]
		public static Validation<T> That<T>(string argumentName,T @object)
		{
			return GetValidation(@object, argumentName);
		}

		private static Validation<T> GetValidation<T>(T @object, string argumentName)
		{
			RequireArgumentName(argumentName);
			var paramMember = GetParamMember(@object, argumentName);
			return new Validation<T>(paramMember);
		}
		
		private static void RequireArgumentName(string argumentName)
		{
			if (argumentName == null)
				throw new ArgumentNullException(nameof(argumentName), $"inputparam {nameof(argumentName)} cannot be null! You must specify a name, this name is used for the contract exception restult!");
		}

		private static ParamMember<T> GetParamMember<T>(T @object, string argumentName)
		{
			var member = argumentName;
			return new ParamMember<T> { MemberName = member, ParamValue = @object};
		}
	}
}