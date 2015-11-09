# NSquared2.Dbc

This is a Extensible flunet contract validation framework. It does not not have any support for invariant checks.
Just inputs and outputs... 

public void AddUsername(Email username)
{
    Contract.Require(nameof(username), username)
            .NotNull()
            .IsEmail()
            
}

