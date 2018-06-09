namespace UN2.EnsureThat
{
	public class Validation<T>
	{
		private readonly T _object;
		private readonly string _paramName;
	    private readonly string _callingAssemblyName;

		public Validation(ParamMember<T> paramMember)
		{
			_paramName = paramMember.MemberName;
			_object = paramMember.ParamValue;
		    _callingAssemblyName = paramMember.GetCallingAssembly;

		}

		public T Value
		{
			get { return _object; }
		}

		public string ParameterName
		{
			get { return _paramName; }
		}

        public string CallingAssemblyName
        {
            get { return _callingAssemblyName; }
        }

    }
}