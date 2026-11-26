// Events exchanged by the authentication model and observed by monitors.
event eSubmitValidCredentials;
event eSubmitInvalidCredentials;
event eSubmitValidTOTP;
event eSubmitInvalidTOTP;
event eRequestProtectedResource;
event eSessionEnded;

// Observable security facts.
event eCredentialsAccepted;
event eCredentialRejected;
event eMFAAccepted;
event eMFARejected;
event eAuthenticationRejected;
event eAccessGranted;
event eAccessDenied;
event eAccountLocked;
