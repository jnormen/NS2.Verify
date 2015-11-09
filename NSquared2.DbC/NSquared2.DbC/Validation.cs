namespace NSquared2.DbC
{
	public class Validation<T>
	{
		private readonly T _object;
		private readonly string _paramName = string.Empty;

		public Validation(ParamMember<T> paramMember)
		{
			_paramName = paramMember.MemberName;
			_object = paramMember.ParamValue;
		}

		public T Value
		{
			get { return _object; }
		}

		public string ParameterName
		{
			get { return _paramName; }
		}

	
	}
}