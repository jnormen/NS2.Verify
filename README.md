# NS2.Dbc
This is a Extensible fluent contract validation framework.<br> 
Made for .Net, the solution uses .Net Core <br>
It does not not have any support for invariant checks.<br>
Just inputs and outputs.<code>
```javascript
public void AddUsername(string username)
{
            Contract.Require(nameof(username), username)
            .NotNull()
            .IsEmail();
}
```
</code>You can simple extend it with your own validation rules for your objects. </br>
Just add an extension for:
<code>
```javascript
Validation<T>
```
</code>

Exmampel:</br>
public static Validation<DateTime> IsNotDefault(this Validation< DateTime> item)

This Contract framework will give you just that Validation< T > objects extension fluent validations methods. 
So int, string etc have their own validation methods. 
</br>

Sampelcode of the StringValidationExtention

<code>
```javascript
public static class StringValidationExtension
{
		[DebuggerHidden]
		public static Validation<string> NotShorterThan(this Validation<string> item, int value)
		{
			if (item.Value.Length < value)
				throw new ArgumentOutOfRangeException($"InputParam '{item.ParameterName}' cannot be less than '{value}'");

			return item;
		}

		[DebuggerHidden]
		public static Validation<string> NotLongerThan(this Validation<string> item, int value)
		{
			if (item.Value.Length > value)
				throw new ArgumentOutOfRangeException($"InputParam '{item.ParameterName}' cannot be greater than '{value}'");

			return item;
		}

		[DebuggerHidden]
		public static Validation<string> NotNullOrEmpty(this Validation<string> item)
		{
			if (string.IsNullOrWhiteSpace(item.Value))
				throw  new ArgumentNullException($"Parameter '{item.ParameterName}' cannot be null or empty string!");
			return item;
		}
}
```
</code>
		


