// Safety property: access is granted only after valid credentials and MFA.
// This monitor observes facts announced by AuthenticationServer.
spec AccessControlSafety observes
    eCredentialsAccepted,
    eMFAAccepted,
    eAccessGranted,
    eSessionEnded
{
    var credentialsOK: bool;
    var mfaOK: bool;

    start state Init
    {
        entry
        {
            credentialsOK = false;
            mfaOK = false;
        }

        on eCredentialsAccepted do
        {
            credentialsOK = true;
            mfaOK = false;
        }

        on eMFAAccepted do
        {
            mfaOK = true;
        }

        on eAccessGranted do
        {
            assert credentialsOK && mfaOK,
                "SECURITY VIOLATION: protected access granted without valid credentials and MFA.";
        }

        on eSessionEnded do
        {
            credentialsOK = false;
            mfaOK = false;
        }
    }
}
