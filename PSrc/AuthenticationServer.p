machine AuthenticationServer
{
    var failedAttempts: int;

    start state WaitingCredentials
    {
        entry
        {
            failedAttempts = 0;
        }

        on eSubmitValidCredentials do
        {
            announce eCredentialsAccepted;
            goto WaitingTOTP;
        }

        on eSubmitInvalidCredentials do
        {
            failedAttempts = failedAttempts + 1;
            announce eCredentialRejected;

            if (failedAttempts >= 3)
            {
                announce eAccountLocked;
                goto Locked;
            }
        }

        on eRequestProtectedResource do
        {
            announce eAccessDenied;
        }

        on eSubmitValidTOTP do
        {
            announce eAuthenticationRejected;
        }

        on eSubmitInvalidTOTP do
        {
            announce eAuthenticationRejected;
        }

        on eSessionEnded do
        {
            // No authenticated session exists to terminate.
            announce eAccessDenied;
        }
    }

    state WaitingTOTP
    {
        on eSubmitValidTOTP do
        {
            announce eMFAAccepted;
            goto Authenticated;
        }

        on eSubmitInvalidTOTP do
        {
            announce eMFARejected;
            goto Denied;
        }

        on eRequestProtectedResource do
        {
            announce eAccessDenied;
        }

        on eSubmitValidCredentials do
        {
            announce eAuthenticationRejected;
        }

        on eSubmitInvalidCredentials do
        {
            announce eAuthenticationRejected;
        }

        on eSessionEnded do
        {
            announce eSessionEnded;
            goto WaitingCredentials;
        }
    }

    state Authenticated
    {
        on eRequestProtectedResource do
        {
            announce eAccessGranted;
        }

        on eSessionEnded do
        {
            announce eSessionEnded;
            goto WaitingCredentials;
        }

        on eSubmitValidCredentials do
        {
            announce eAuthenticationRejected;
        }

        on eSubmitInvalidCredentials do
        {
            announce eAuthenticationRejected;
        }

        on eSubmitValidTOTP do
        {
            announce eAuthenticationRejected;
        }

        on eSubmitInvalidTOTP do
        {
            announce eAuthenticationRejected;
        }
    }

    state Denied
    {
        on eRequestProtectedResource do
        {
            announce eAccessDenied;
        }

        on eSubmitValidCredentials do
        {
            announce eAuthenticationRejected;
        }

        on eSubmitInvalidCredentials do
        {
            announce eAuthenticationRejected;
        }

        on eSubmitValidTOTP do
        {
            announce eAuthenticationRejected;
        }

        on eSubmitInvalidTOTP do
        {
            announce eAuthenticationRejected;
        }

        on eSessionEnded do
        {
            announce eSessionEnded;
            goto WaitingCredentials;
        }
    }

    state Locked
    {
        on eRequestProtectedResource do
        {
            announce eAccessDenied;
        }

        on eSubmitValidCredentials do
        {
            announce eAuthenticationRejected;
        }

        on eSubmitInvalidCredentials do
        {
            announce eAuthenticationRejected;
        }

        on eSubmitValidTOTP do
        {
            announce eAuthenticationRejected;
        }

        on eSubmitInvalidTOTP do
        {
            announce eAuthenticationRejected;
        }

        on eSessionEnded do
        {
            announce eSessionEnded;
        }
    }
}
