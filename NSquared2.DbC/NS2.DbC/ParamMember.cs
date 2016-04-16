namespace NS2.DbC
{
	public struct ParamMember<T>
	{
		public string MemberName { get; set; }
		public T ParamValue { get; set; }
        public string GetCallingAssembly { get; set; } //Will be used as soon .net core let me get CalligAssembly 
	}
}