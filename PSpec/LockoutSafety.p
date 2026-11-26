// Safety property: after account lockout, no access may be granted.
spec LockoutSafety observes eAccountLocked, eAccessGranted
{
    var accountLocked: bool;

    start state Init
    {
        entry
        {
            accountLocked = false;
        }

        on eAccountLocked do
        {
            accountLocked = true;
        }

        on eAccessGranted do
        {
            assert !accountLocked,
                "SECURITY VIOLATION: access granted after the account was locked.";
        }
    }
}
