namespace NSquared2.DbC
{
	public struct ParamMember<T>
	{
		public string MemberName { get; set; }
		public T ParamValue { get; set; }
	}
}