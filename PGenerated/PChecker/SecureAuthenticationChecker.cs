using PChecker;
using PChecker.Runtime;
using PChecker.Runtime.StateMachines;
using PChecker.Runtime.Events;
using PChecker.Runtime.Exceptions;
using PChecker.Runtime.Logging;
using PChecker.Runtime.Values;
using PChecker.Runtime.Specifications;
using Monitor = PChecker.Runtime.Specifications.Monitor;
using System;
using PChecker.SystematicTesting;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable 162, 219, 414, 1998
namespace PImplementation
{
}
namespace PImplementation
{
    public static class GlobalConfig
    {
    }
}
namespace PImplementation
{
    internal partial class eSubmitValidCredentials : Event
    {
        public eSubmitValidCredentials() : base() {}
        public eSubmitValidCredentials (IPValue payload): base(payload){ }
        public override IPValue Clone() { return new eSubmitValidCredentials();}
    }
}
namespace PImplementation
{
    internal partial class eSubmitInvalidCredentials : Event
    {
        public eSubmitInvalidCredentials() : base() {}
        public eSubmitInvalidCredentials (IPValue payload): base(payload){ }
        public override IPValue Clone() { return new eSubmitInvalidCredentials();}
    }
}
namespace PImplementation
{
    internal partial class eSubmitValidTOTP : Event
    {
        public eSubmitValidTOTP() : base() {}
        public eSubmitValidTOTP (IPValue payload): base(payload){ }
        public override IPValue Clone() { return new eSubmitValidTOTP();}
    }
}
namespace PImplementation
{
    internal partial class eSubmitInvalidTOTP : Event
    {
        public eSubmitInvalidTOTP() : base() {}
        public eSubmitInvalidTOTP (IPValue payload): base(payload){ }
        public override IPValue Clone() { return new eSubmitInvalidTOTP();}
    }
}
namespace PImplementation
{
    internal partial class eRequestProtectedResource : Event
    {
        public eRequestProtectedResource() : base() {}
        public eRequestProtectedResource (IPValue payload): base(payload){ }
        public override IPValue Clone() { return new eRequestProtectedResource();}
    }
}
namespace PImplementation
{
    internal partial class eSessionEnded : Event
    {
        public eSessionEnded() : base() {}
        public eSessionEnded (IPValue payload): base(payload){ }
        public override IPValue Clone() { return new eSessionEnded();}
    }
}
namespace PImplementation
{
    internal partial class eCredentialsAccepted : Event
    {
        public eCredentialsAccepted() : base() {}
        public eCredentialsAccepted (IPValue payload): base(payload){ }
        public override IPValue Clone() { return new eCredentialsAccepted();}
    }
}
namespace PImplementation
{
    internal partial class eCredentialRejected : Event
    {
        public eCredentialRejected() : base() {}
        public eCredentialRejected (IPValue payload): base(payload){ }
        public override IPValue Clone() { return new eCredentialRejected();}
    }
}
namespace PImplementation
{
    internal partial class eMFAAccepted : Event
    {
        public eMFAAccepted() : base() {}
        public eMFAAccepted (IPValue payload): base(payload){ }
        public override IPValue Clone() { return new eMFAAccepted();}
    }
}
namespace PImplementation
{
    internal partial class eMFARejected : Event
    {
        public eMFARejected() : base() {}
        public eMFARejected (IPValue payload): base(payload){ }
        public override IPValue Clone() { return new eMFARejected();}
    }
}
namespace PImplementation
{
    internal partial class eAuthenticationRejected : Event
    {
        public eAuthenticationRejected() : base() {}
        public eAuthenticationRejected (IPValue payload): base(payload){ }
        public override IPValue Clone() { return new eAuthenticationRejected();}
    }
}
namespace PImplementation
{
    internal partial class eAccessGranted : Event
    {
        public eAccessGranted() : base() {}
        public eAccessGranted (IPValue payload): base(payload){ }
        public override IPValue Clone() { return new eAccessGranted();}
    }
}
namespace PImplementation
{
    internal partial class eAccessDenied : Event
    {
        public eAccessDenied() : base() {}
        public eAccessDenied (IPValue payload): base(payload){ }
        public override IPValue Clone() { return new eAccessDenied();}
    }
}
namespace PImplementation
{
    internal partial class eAccountLocked : Event
    {
        public eAccountLocked() : base() {}
        public eAccountLocked (IPValue payload): base(payload){ }
        public override IPValue Clone() { return new eAccountLocked();}
    }
}
namespace PImplementation
{
    internal partial class AuthenticationServer : StateMachine
    {
        private PInt failedAttempts = ((PInt)0);
        public class ConstructorEvent : Event{public ConstructorEvent(IPValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPValue value) { return new ConstructorEvent((IPValue)value); }
        public AuthenticationServer() {
            this.sends.Add(nameof(eAccessDenied));
            this.sends.Add(nameof(eAccessGranted));
            this.sends.Add(nameof(eAccountLocked));
            this.sends.Add(nameof(eAuthenticationRejected));
            this.sends.Add(nameof(eCredentialRejected));
            this.sends.Add(nameof(eCredentialsAccepted));
            this.sends.Add(nameof(eMFAAccepted));
            this.sends.Add(nameof(eMFARejected));
            this.sends.Add(nameof(eRequestProtectedResource));
            this.sends.Add(nameof(eSessionEnded));
            this.sends.Add(nameof(eSubmitInvalidCredentials));
            this.sends.Add(nameof(eSubmitInvalidTOTP));
            this.sends.Add(nameof(eSubmitValidCredentials));
            this.sends.Add(nameof(eSubmitValidTOTP));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eAccessDenied));
            this.receives.Add(nameof(eAccessGranted));
            this.receives.Add(nameof(eAccountLocked));
            this.receives.Add(nameof(eAuthenticationRejected));
            this.receives.Add(nameof(eCredentialRejected));
            this.receives.Add(nameof(eCredentialsAccepted));
            this.receives.Add(nameof(eMFAAccepted));
            this.receives.Add(nameof(eMFARejected));
            this.receives.Add(nameof(eRequestProtectedResource));
            this.receives.Add(nameof(eSessionEnded));
            this.receives.Add(nameof(eSubmitInvalidCredentials));
            this.receives.Add(nameof(eSubmitInvalidTOTP));
            this.receives.Add(nameof(eSubmitValidCredentials));
            this.receives.Add(nameof(eSubmitValidTOTP));
            this.receives.Add(nameof(PHalt));
        }
        
        public void Anon(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            failedAttempts = (PInt)(((PInt)(0)));
        }
        public void Anon_1(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eCredentialsAccepted(null));
            currentMachine.RaiseGotoStateEvent<WaitingTOTP>();
            return;
        }
        public void Anon_2(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            PInt TMP_tmp0 = ((PInt)0);
            PBool TMP_tmp1 = ((PBool)false);
            TMP_tmp0 = (PInt)((failedAttempts) + (((PInt)(1))));
            failedAttempts = TMP_tmp0;
            currentMachine.Announce((Event)new eCredentialRejected(null));
            TMP_tmp1 = (PBool)((failedAttempts) >= (((PInt)(3))));
            if (TMP_tmp1)
            {
                currentMachine.Announce((Event)new eAccountLocked(null));
                currentMachine.RaiseGotoStateEvent<Locked>();
                return;
            }
        }
        public void Anon_3(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eAccessDenied(null));
        }
        public void Anon_4(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eAuthenticationRejected(null));
        }
        public void Anon_5(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eAuthenticationRejected(null));
        }
        public void Anon_6(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eAccessDenied(null));
        }
        public void Anon_7(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eMFAAccepted(null));
            currentMachine.RaiseGotoStateEvent<Authenticated>();
            return;
        }
        public void Anon_8(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eMFARejected(null));
            currentMachine.RaiseGotoStateEvent<Denied>();
            return;
        }
        public void Anon_9(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eAccessDenied(null));
        }
        public void Anon_10(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eAuthenticationRejected(null));
        }
        public void Anon_11(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eAuthenticationRejected(null));
        }
        public void Anon_12(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eSessionEnded(null));
            currentMachine.RaiseGotoStateEvent<WaitingCredentials>();
            return;
        }
        public void Anon_13(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eAccessGranted(null));
        }
        public void Anon_14(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eSessionEnded(null));
            currentMachine.RaiseGotoStateEvent<WaitingCredentials>();
            return;
        }
        public void Anon_15(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eAuthenticationRejected(null));
        }
        public void Anon_16(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eAuthenticationRejected(null));
        }
        public void Anon_17(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eAuthenticationRejected(null));
        }
        public void Anon_18(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eAuthenticationRejected(null));
        }
        public void Anon_19(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eAccessDenied(null));
        }
        public void Anon_20(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eAuthenticationRejected(null));
        }
        public void Anon_21(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eAuthenticationRejected(null));
        }
        public void Anon_22(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eAuthenticationRejected(null));
        }
        public void Anon_23(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eAuthenticationRejected(null));
        }
        public void Anon_24(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eSessionEnded(null));
            currentMachine.RaiseGotoStateEvent<WaitingCredentials>();
            return;
        }
        public void Anon_25(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eAccessDenied(null));
        }
        public void Anon_26(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eAuthenticationRejected(null));
        }
        public void Anon_27(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eAuthenticationRejected(null));
        }
        public void Anon_28(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eAuthenticationRejected(null));
        }
        public void Anon_29(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eAuthenticationRejected(null));
        }
        public void Anon_30(Event currentMachine_dequeuedEvent)
        {
            AuthenticationServer currentMachine = this;
            currentMachine.Announce((Event)new eSessionEnded(null));
        }
        [Start]
        [OnEntry(nameof(Anon))]
        [OnEventDoAction(typeof(eSubmitValidCredentials), nameof(Anon_1))]
        [OnEventDoAction(typeof(eSubmitInvalidCredentials), nameof(Anon_2))]
        [OnEventDoAction(typeof(eRequestProtectedResource), nameof(Anon_3))]
        [OnEventDoAction(typeof(eSubmitValidTOTP), nameof(Anon_4))]
        [OnEventDoAction(typeof(eSubmitInvalidTOTP), nameof(Anon_5))]
        [OnEventDoAction(typeof(eSessionEnded), nameof(Anon_6))]
        class WaitingCredentials : State
        {
        }
        [OnEventDoAction(typeof(eSubmitValidTOTP), nameof(Anon_7))]
        [OnEventDoAction(typeof(eSubmitInvalidTOTP), nameof(Anon_8))]
        [OnEventDoAction(typeof(eRequestProtectedResource), nameof(Anon_9))]
        [OnEventDoAction(typeof(eSubmitValidCredentials), nameof(Anon_10))]
        [OnEventDoAction(typeof(eSubmitInvalidCredentials), nameof(Anon_11))]
        [OnEventDoAction(typeof(eSessionEnded), nameof(Anon_12))]
        class WaitingTOTP : State
        {
        }
        [OnEventDoAction(typeof(eRequestProtectedResource), nameof(Anon_13))]
        [OnEventDoAction(typeof(eSessionEnded), nameof(Anon_14))]
        [OnEventDoAction(typeof(eSubmitValidCredentials), nameof(Anon_15))]
        [OnEventDoAction(typeof(eSubmitInvalidCredentials), nameof(Anon_16))]
        [OnEventDoAction(typeof(eSubmitValidTOTP), nameof(Anon_17))]
        [OnEventDoAction(typeof(eSubmitInvalidTOTP), nameof(Anon_18))]
        class Authenticated : State
        {
        }
        [OnEventDoAction(typeof(eRequestProtectedResource), nameof(Anon_19))]
        [OnEventDoAction(typeof(eSubmitValidCredentials), nameof(Anon_20))]
        [OnEventDoAction(typeof(eSubmitInvalidCredentials), nameof(Anon_21))]
        [OnEventDoAction(typeof(eSubmitValidTOTP), nameof(Anon_22))]
        [OnEventDoAction(typeof(eSubmitInvalidTOTP), nameof(Anon_23))]
        [OnEventDoAction(typeof(eSessionEnded), nameof(Anon_24))]
        class Denied : State
        {
        }
        [OnEventDoAction(typeof(eRequestProtectedResource), nameof(Anon_25))]
        [OnEventDoAction(typeof(eSubmitValidCredentials), nameof(Anon_26))]
        [OnEventDoAction(typeof(eSubmitInvalidCredentials), nameof(Anon_27))]
        [OnEventDoAction(typeof(eSubmitValidTOTP), nameof(Anon_28))]
        [OnEventDoAction(typeof(eSubmitInvalidTOTP), nameof(Anon_29))]
        [OnEventDoAction(typeof(eSessionEnded), nameof(Anon_30))]
        class Locked : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class AccessControlSafety : Monitor
    {
        private PBool credentialsOK = ((PBool)false);
        private PBool mfaOK = ((PBool)false);
        static AccessControlSafety() {
            observes.Add(nameof(eAccessGranted));
            observes.Add(nameof(eCredentialsAccepted));
            observes.Add(nameof(eMFAAccepted));
            observes.Add(nameof(eSessionEnded));
        }
        
        public void Anon_31(Event currentMachine_dequeuedEvent)
        {
            AccessControlSafety currentMachine = this;
            credentialsOK = (PBool)(((PBool)false));
            mfaOK = (PBool)(((PBool)false));
        }
        public void Anon_32(Event currentMachine_dequeuedEvent)
        {
            AccessControlSafety currentMachine = this;
            credentialsOK = (PBool)(((PBool)true));
            mfaOK = (PBool)(((PBool)false));
        }
        public void Anon_33(Event currentMachine_dequeuedEvent)
        {
            AccessControlSafety currentMachine = this;
            mfaOK = (PBool)(((PBool)true));
        }
        public void Anon_34(Event currentMachine_dequeuedEvent)
        {
            AccessControlSafety currentMachine = this;
            PBool TMP_tmp0_1 = ((PBool)false);
            PString TMP_tmp1_1 = ((PString)"");
            PString TMP_tmp2 = ((PString)"");
            PString TMP_tmp3 = ((PString)"");
            TMP_tmp0_1 = (PBool)(((PBool)((IPValue)credentialsOK)?.Clone()));
            if (TMP_tmp0_1)
            {
                TMP_tmp0_1 = (PBool)(((PBool)((IPValue)mfaOK)?.Clone()));
            }
            if (TMP_tmp0_1)
            {
            }
            else
            {
                TMP_tmp1_1 = (PString)(((PString) String.Format("PSpec\\AccessControlSafety.p:33:13")));
                TMP_tmp2 = (PString)(((PString) String.Format("SECURITY VIOLATION: protected access granted without valid credentials and MFA.")));
                TMP_tmp3 = (PString)(((PString) String.Format("{0} {1}",TMP_tmp1_1,TMP_tmp2)));
                currentMachine.Assert(TMP_tmp0_1,"Assertion Failed: " + TMP_tmp3);
            }
        }
        public void Anon_35(Event currentMachine_dequeuedEvent)
        {
            AccessControlSafety currentMachine = this;
            credentialsOK = (PBool)(((PBool)false));
            mfaOK = (PBool)(((PBool)false));
        }
        [Start]
        [OnEntry(nameof(Anon_31))]
        [OnEventDoAction(typeof(eCredentialsAccepted), nameof(Anon_32))]
        [OnEventDoAction(typeof(eMFAAccepted), nameof(Anon_33))]
        [OnEventDoAction(typeof(eAccessGranted), nameof(Anon_34))]
        [OnEventDoAction(typeof(eSessionEnded), nameof(Anon_35))]
        class Init : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class LockoutSafety : Monitor
    {
        private PBool accountLocked = ((PBool)false);
        static LockoutSafety() {
            observes.Add(nameof(eAccessGranted));
            observes.Add(nameof(eAccountLocked));
        }
        
        public void Anon_36(Event currentMachine_dequeuedEvent)
        {
            LockoutSafety currentMachine = this;
            accountLocked = (PBool)(((PBool)false));
        }
        public void Anon_37(Event currentMachine_dequeuedEvent)
        {
            LockoutSafety currentMachine = this;
            accountLocked = (PBool)(((PBool)true));
        }
        public void Anon_38(Event currentMachine_dequeuedEvent)
        {
            LockoutSafety currentMachine = this;
            PBool TMP_tmp0_2 = ((PBool)false);
            PString TMP_tmp1_2 = ((PString)"");
            PString TMP_tmp2_1 = ((PString)"");
            PString TMP_tmp3_1 = ((PString)"");
            TMP_tmp0_2 = (PBool)(!(accountLocked));
            if (TMP_tmp0_2)
            {
            }
            else
            {
                TMP_tmp1_2 = (PString)(((PString) String.Format("PSpec\\LockoutSafety.p:20:13")));
                TMP_tmp2_1 = (PString)(((PString) String.Format("SECURITY VIOLATION: access granted after the account was locked.")));
                TMP_tmp3_1 = (PString)(((PString) String.Format("{0} {1}",TMP_tmp1_2,TMP_tmp2_1)));
                currentMachine.Assert(TMP_tmp0_2,"Assertion Failed: " + TMP_tmp3_1);
            }
        }
        [Start]
        [OnEntry(nameof(Anon_36))]
        [OnEventDoAction(typeof(eAccountLocked), nameof(Anon_37))]
        [OnEventDoAction(typeof(eAccessGranted), nameof(Anon_38))]
        class Init : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class TestValidLogin : StateMachine
    {
        private PMachineValue auth = null;
        public class ConstructorEvent : Event{public ConstructorEvent(IPValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPValue value) { return new ConstructorEvent((IPValue)value); }
        public TestValidLogin() {
            this.sends.Add(nameof(eAccessDenied));
            this.sends.Add(nameof(eAccessGranted));
            this.sends.Add(nameof(eAccountLocked));
            this.sends.Add(nameof(eAuthenticationRejected));
            this.sends.Add(nameof(eCredentialRejected));
            this.sends.Add(nameof(eCredentialsAccepted));
            this.sends.Add(nameof(eMFAAccepted));
            this.sends.Add(nameof(eMFARejected));
            this.sends.Add(nameof(eRequestProtectedResource));
            this.sends.Add(nameof(eSessionEnded));
            this.sends.Add(nameof(eSubmitInvalidCredentials));
            this.sends.Add(nameof(eSubmitInvalidTOTP));
            this.sends.Add(nameof(eSubmitValidCredentials));
            this.sends.Add(nameof(eSubmitValidTOTP));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eAccessDenied));
            this.receives.Add(nameof(eAccessGranted));
            this.receives.Add(nameof(eAccountLocked));
            this.receives.Add(nameof(eAuthenticationRejected));
            this.receives.Add(nameof(eCredentialRejected));
            this.receives.Add(nameof(eCredentialsAccepted));
            this.receives.Add(nameof(eMFAAccepted));
            this.receives.Add(nameof(eMFARejected));
            this.receives.Add(nameof(eRequestProtectedResource));
            this.receives.Add(nameof(eSessionEnded));
            this.receives.Add(nameof(eSubmitInvalidCredentials));
            this.receives.Add(nameof(eSubmitInvalidTOTP));
            this.receives.Add(nameof(eSubmitValidCredentials));
            this.receives.Add(nameof(eSubmitValidTOTP));
            this.receives.Add(nameof(PHalt));
            this.creates.Add(nameof(I_AuthenticationServer));
        }
        
        public void Anon_39(Event currentMachine_dequeuedEvent)
        {
            TestValidLogin currentMachine = this;
            PMachineValue TMP_tmp0_3 = null;
            PMachineValue TMP_tmp1_3 = null;
            Event TMP_tmp2_2 = null;
            PMachineValue TMP_tmp3_2 = null;
            Event TMP_tmp4 = null;
            PMachineValue TMP_tmp5 = null;
            Event TMP_tmp6 = null;
            TMP_tmp0_3 = (PMachineValue)(currentMachine.CreateInterface<I_AuthenticationServer>( currentMachine));
            auth = TMP_tmp0_3;
            TMP_tmp1_3 = (PMachineValue)(((PMachineValue)((IPValue)auth)?.Clone()));
            TMP_tmp2_2 = (Event)(new eSubmitValidCredentials(null));
            currentMachine.SendEvent(TMP_tmp1_3, (Event)TMP_tmp2_2);
            TMP_tmp3_2 = (PMachineValue)(((PMachineValue)((IPValue)auth)?.Clone()));
            TMP_tmp4 = (Event)(new eSubmitValidTOTP(null));
            currentMachine.SendEvent(TMP_tmp3_2, (Event)TMP_tmp4);
            TMP_tmp5 = (PMachineValue)(((PMachineValue)((IPValue)auth)?.Clone()));
            TMP_tmp6 = (Event)(new eRequestProtectedResource(null));
            currentMachine.SendEvent(TMP_tmp5, (Event)TMP_tmp6);
        }
        [Start]
        [OnEntry(nameof(Anon_39))]
        class Init : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class TestUnauthenticatedAccess : StateMachine
    {
        private PMachineValue auth_1 = null;
        public class ConstructorEvent : Event{public ConstructorEvent(IPValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPValue value) { return new ConstructorEvent((IPValue)value); }
        public TestUnauthenticatedAccess() {
            this.sends.Add(nameof(eAccessDenied));
            this.sends.Add(nameof(eAccessGranted));
            this.sends.Add(nameof(eAccountLocked));
            this.sends.Add(nameof(eAuthenticationRejected));
            this.sends.Add(nameof(eCredentialRejected));
            this.sends.Add(nameof(eCredentialsAccepted));
            this.sends.Add(nameof(eMFAAccepted));
            this.sends.Add(nameof(eMFARejected));
            this.sends.Add(nameof(eRequestProtectedResource));
            this.sends.Add(nameof(eSessionEnded));
            this.sends.Add(nameof(eSubmitInvalidCredentials));
            this.sends.Add(nameof(eSubmitInvalidTOTP));
            this.sends.Add(nameof(eSubmitValidCredentials));
            this.sends.Add(nameof(eSubmitValidTOTP));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eAccessDenied));
            this.receives.Add(nameof(eAccessGranted));
            this.receives.Add(nameof(eAccountLocked));
            this.receives.Add(nameof(eAuthenticationRejected));
            this.receives.Add(nameof(eCredentialRejected));
            this.receives.Add(nameof(eCredentialsAccepted));
            this.receives.Add(nameof(eMFAAccepted));
            this.receives.Add(nameof(eMFARejected));
            this.receives.Add(nameof(eRequestProtectedResource));
            this.receives.Add(nameof(eSessionEnded));
            this.receives.Add(nameof(eSubmitInvalidCredentials));
            this.receives.Add(nameof(eSubmitInvalidTOTP));
            this.receives.Add(nameof(eSubmitValidCredentials));
            this.receives.Add(nameof(eSubmitValidTOTP));
            this.receives.Add(nameof(PHalt));
            this.creates.Add(nameof(I_AuthenticationServer));
        }
        
        public void Anon_40(Event currentMachine_dequeuedEvent)
        {
            TestUnauthenticatedAccess currentMachine = this;
            PMachineValue TMP_tmp0_4 = null;
            PMachineValue TMP_tmp1_4 = null;
            Event TMP_tmp2_3 = null;
            TMP_tmp0_4 = (PMachineValue)(currentMachine.CreateInterface<I_AuthenticationServer>( currentMachine));
            auth_1 = TMP_tmp0_4;
            TMP_tmp1_4 = (PMachineValue)(((PMachineValue)((IPValue)auth_1)?.Clone()));
            TMP_tmp2_3 = (Event)(new eRequestProtectedResource(null));
            currentMachine.SendEvent(TMP_tmp1_4, (Event)TMP_tmp2_3);
        }
        [Start]
        [OnEntry(nameof(Anon_40))]
        class Init : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class TestInvalidTOTP : StateMachine
    {
        private PMachineValue auth_2 = null;
        public class ConstructorEvent : Event{public ConstructorEvent(IPValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPValue value) { return new ConstructorEvent((IPValue)value); }
        public TestInvalidTOTP() {
            this.sends.Add(nameof(eAccessDenied));
            this.sends.Add(nameof(eAccessGranted));
            this.sends.Add(nameof(eAccountLocked));
            this.sends.Add(nameof(eAuthenticationRejected));
            this.sends.Add(nameof(eCredentialRejected));
            this.sends.Add(nameof(eCredentialsAccepted));
            this.sends.Add(nameof(eMFAAccepted));
            this.sends.Add(nameof(eMFARejected));
            this.sends.Add(nameof(eRequestProtectedResource));
            this.sends.Add(nameof(eSessionEnded));
            this.sends.Add(nameof(eSubmitInvalidCredentials));
            this.sends.Add(nameof(eSubmitInvalidTOTP));
            this.sends.Add(nameof(eSubmitValidCredentials));
            this.sends.Add(nameof(eSubmitValidTOTP));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eAccessDenied));
            this.receives.Add(nameof(eAccessGranted));
            this.receives.Add(nameof(eAccountLocked));
            this.receives.Add(nameof(eAuthenticationRejected));
            this.receives.Add(nameof(eCredentialRejected));
            this.receives.Add(nameof(eCredentialsAccepted));
            this.receives.Add(nameof(eMFAAccepted));
            this.receives.Add(nameof(eMFARejected));
            this.receives.Add(nameof(eRequestProtectedResource));
            this.receives.Add(nameof(eSessionEnded));
            this.receives.Add(nameof(eSubmitInvalidCredentials));
            this.receives.Add(nameof(eSubmitInvalidTOTP));
            this.receives.Add(nameof(eSubmitValidCredentials));
            this.receives.Add(nameof(eSubmitValidTOTP));
            this.receives.Add(nameof(PHalt));
            this.creates.Add(nameof(I_AuthenticationServer));
        }
        
        public void Anon_41(Event currentMachine_dequeuedEvent)
        {
            TestInvalidTOTP currentMachine = this;
            PMachineValue TMP_tmp0_5 = null;
            PMachineValue TMP_tmp1_5 = null;
            Event TMP_tmp2_4 = null;
            PMachineValue TMP_tmp3_3 = null;
            Event TMP_tmp4_1 = null;
            PMachineValue TMP_tmp5_1 = null;
            Event TMP_tmp6_1 = null;
            TMP_tmp0_5 = (PMachineValue)(currentMachine.CreateInterface<I_AuthenticationServer>( currentMachine));
            auth_2 = TMP_tmp0_5;
            TMP_tmp1_5 = (PMachineValue)(((PMachineValue)((IPValue)auth_2)?.Clone()));
            TMP_tmp2_4 = (Event)(new eSubmitValidCredentials(null));
            currentMachine.SendEvent(TMP_tmp1_5, (Event)TMP_tmp2_4);
            TMP_tmp3_3 = (PMachineValue)(((PMachineValue)((IPValue)auth_2)?.Clone()));
            TMP_tmp4_1 = (Event)(new eSubmitInvalidTOTP(null));
            currentMachine.SendEvent(TMP_tmp3_3, (Event)TMP_tmp4_1);
            TMP_tmp5_1 = (PMachineValue)(((PMachineValue)((IPValue)auth_2)?.Clone()));
            TMP_tmp6_1 = (Event)(new eRequestProtectedResource(null));
            currentMachine.SendEvent(TMP_tmp5_1, (Event)TMP_tmp6_1);
        }
        [Start]
        [OnEntry(nameof(Anon_41))]
        class Init : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class TestAccountLockout : StateMachine
    {
        private PMachineValue auth_3 = null;
        public class ConstructorEvent : Event{public ConstructorEvent(IPValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPValue value) { return new ConstructorEvent((IPValue)value); }
        public TestAccountLockout() {
            this.sends.Add(nameof(eAccessDenied));
            this.sends.Add(nameof(eAccessGranted));
            this.sends.Add(nameof(eAccountLocked));
            this.sends.Add(nameof(eAuthenticationRejected));
            this.sends.Add(nameof(eCredentialRejected));
            this.sends.Add(nameof(eCredentialsAccepted));
            this.sends.Add(nameof(eMFAAccepted));
            this.sends.Add(nameof(eMFARejected));
            this.sends.Add(nameof(eRequestProtectedResource));
            this.sends.Add(nameof(eSessionEnded));
            this.sends.Add(nameof(eSubmitInvalidCredentials));
            this.sends.Add(nameof(eSubmitInvalidTOTP));
            this.sends.Add(nameof(eSubmitValidCredentials));
            this.sends.Add(nameof(eSubmitValidTOTP));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eAccessDenied));
            this.receives.Add(nameof(eAccessGranted));
            this.receives.Add(nameof(eAccountLocked));
            this.receives.Add(nameof(eAuthenticationRejected));
            this.receives.Add(nameof(eCredentialRejected));
            this.receives.Add(nameof(eCredentialsAccepted));
            this.receives.Add(nameof(eMFAAccepted));
            this.receives.Add(nameof(eMFARejected));
            this.receives.Add(nameof(eRequestProtectedResource));
            this.receives.Add(nameof(eSessionEnded));
            this.receives.Add(nameof(eSubmitInvalidCredentials));
            this.receives.Add(nameof(eSubmitInvalidTOTP));
            this.receives.Add(nameof(eSubmitValidCredentials));
            this.receives.Add(nameof(eSubmitValidTOTP));
            this.receives.Add(nameof(PHalt));
            this.creates.Add(nameof(I_AuthenticationServer));
        }
        
        public void Anon_42(Event currentMachine_dequeuedEvent)
        {
            TestAccountLockout currentMachine = this;
            PMachineValue TMP_tmp0_6 = null;
            PMachineValue TMP_tmp1_6 = null;
            Event TMP_tmp2_5 = null;
            PMachineValue TMP_tmp3_4 = null;
            Event TMP_tmp4_2 = null;
            PMachineValue TMP_tmp5_2 = null;
            Event TMP_tmp6_2 = null;
            PMachineValue TMP_tmp7 = null;
            Event TMP_tmp8 = null;
            PMachineValue TMP_tmp9 = null;
            Event TMP_tmp10 = null;
            TMP_tmp0_6 = (PMachineValue)(currentMachine.CreateInterface<I_AuthenticationServer>( currentMachine));
            auth_3 = TMP_tmp0_6;
            TMP_tmp1_6 = (PMachineValue)(((PMachineValue)((IPValue)auth_3)?.Clone()));
            TMP_tmp2_5 = (Event)(new eSubmitInvalidCredentials(null));
            currentMachine.SendEvent(TMP_tmp1_6, (Event)TMP_tmp2_5);
            TMP_tmp3_4 = (PMachineValue)(((PMachineValue)((IPValue)auth_3)?.Clone()));
            TMP_tmp4_2 = (Event)(new eSubmitInvalidCredentials(null));
            currentMachine.SendEvent(TMP_tmp3_4, (Event)TMP_tmp4_2);
            TMP_tmp5_2 = (PMachineValue)(((PMachineValue)((IPValue)auth_3)?.Clone()));
            TMP_tmp6_2 = (Event)(new eSubmitInvalidCredentials(null));
            currentMachine.SendEvent(TMP_tmp5_2, (Event)TMP_tmp6_2);
            TMP_tmp7 = (PMachineValue)(((PMachineValue)((IPValue)auth_3)?.Clone()));
            TMP_tmp8 = (Event)(new eSubmitValidCredentials(null));
            currentMachine.SendEvent(TMP_tmp7, (Event)TMP_tmp8);
            TMP_tmp9 = (PMachineValue)(((PMachineValue)((IPValue)auth_3)?.Clone()));
            TMP_tmp10 = (Event)(new eRequestProtectedResource(null));
            currentMachine.SendEvent(TMP_tmp9, (Event)TMP_tmp10);
        }
        [Start]
        [OnEntry(nameof(Anon_42))]
        class Init : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class TestSessionTermination : StateMachine
    {
        private PMachineValue auth_4 = null;
        public class ConstructorEvent : Event{public ConstructorEvent(IPValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPValue value) { return new ConstructorEvent((IPValue)value); }
        public TestSessionTermination() {
            this.sends.Add(nameof(eAccessDenied));
            this.sends.Add(nameof(eAccessGranted));
            this.sends.Add(nameof(eAccountLocked));
            this.sends.Add(nameof(eAuthenticationRejected));
            this.sends.Add(nameof(eCredentialRejected));
            this.sends.Add(nameof(eCredentialsAccepted));
            this.sends.Add(nameof(eMFAAccepted));
            this.sends.Add(nameof(eMFARejected));
            this.sends.Add(nameof(eRequestProtectedResource));
            this.sends.Add(nameof(eSessionEnded));
            this.sends.Add(nameof(eSubmitInvalidCredentials));
            this.sends.Add(nameof(eSubmitInvalidTOTP));
            this.sends.Add(nameof(eSubmitValidCredentials));
            this.sends.Add(nameof(eSubmitValidTOTP));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eAccessDenied));
            this.receives.Add(nameof(eAccessGranted));
            this.receives.Add(nameof(eAccountLocked));
            this.receives.Add(nameof(eAuthenticationRejected));
            this.receives.Add(nameof(eCredentialRejected));
            this.receives.Add(nameof(eCredentialsAccepted));
            this.receives.Add(nameof(eMFAAccepted));
            this.receives.Add(nameof(eMFARejected));
            this.receives.Add(nameof(eRequestProtectedResource));
            this.receives.Add(nameof(eSessionEnded));
            this.receives.Add(nameof(eSubmitInvalidCredentials));
            this.receives.Add(nameof(eSubmitInvalidTOTP));
            this.receives.Add(nameof(eSubmitValidCredentials));
            this.receives.Add(nameof(eSubmitValidTOTP));
            this.receives.Add(nameof(PHalt));
            this.creates.Add(nameof(I_AuthenticationServer));
        }
        
        public void Anon_43(Event currentMachine_dequeuedEvent)
        {
            TestSessionTermination currentMachine = this;
            PMachineValue TMP_tmp0_7 = null;
            PMachineValue TMP_tmp1_7 = null;
            Event TMP_tmp2_6 = null;
            PMachineValue TMP_tmp3_5 = null;
            Event TMP_tmp4_3 = null;
            PMachineValue TMP_tmp5_3 = null;
            Event TMP_tmp6_3 = null;
            PMachineValue TMP_tmp7_1 = null;
            Event TMP_tmp8_1 = null;
            TMP_tmp0_7 = (PMachineValue)(currentMachine.CreateInterface<I_AuthenticationServer>( currentMachine));
            auth_4 = TMP_tmp0_7;
            TMP_tmp1_7 = (PMachineValue)(((PMachineValue)((IPValue)auth_4)?.Clone()));
            TMP_tmp2_6 = (Event)(new eSubmitValidCredentials(null));
            currentMachine.SendEvent(TMP_tmp1_7, (Event)TMP_tmp2_6);
            TMP_tmp3_5 = (PMachineValue)(((PMachineValue)((IPValue)auth_4)?.Clone()));
            TMP_tmp4_3 = (Event)(new eSubmitValidTOTP(null));
            currentMachine.SendEvent(TMP_tmp3_5, (Event)TMP_tmp4_3);
            TMP_tmp5_3 = (PMachineValue)(((PMachineValue)((IPValue)auth_4)?.Clone()));
            TMP_tmp6_3 = (Event)(new eSessionEnded(null));
            currentMachine.SendEvent(TMP_tmp5_3, (Event)TMP_tmp6_3);
            TMP_tmp7_1 = (PMachineValue)(((PMachineValue)((IPValue)auth_4)?.Clone()));
            TMP_tmp8_1 = (Event)(new eRequestProtectedResource(null));
            currentMachine.SendEvent(TMP_tmp7_1, (Event)TMP_tmp8_1);
        }
        [Start]
        [OnEntry(nameof(Anon_43))]
        class Init : State
        {
        }
    }
}
namespace PImplementation
{
    public class tcValidLogin {
        public static void InitializeGlobalParams() {
        }
        public static void InitializeLinkMap() {
            PModule.linkMap.Clear();
            PModule.linkMap[nameof(I_AuthenticationServer)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_TestValidLogin)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_TestValidLogin)].Add(nameof(I_AuthenticationServer), nameof(I_AuthenticationServer));
        }
        
        public static void InitializeInterfaceDefMap() {
            PModule.interfaceDefinitionMap.Clear();
            PModule.interfaceDefinitionMap.Add(nameof(I_AuthenticationServer), typeof(AuthenticationServer));
            PModule.interfaceDefinitionMap.Add(nameof(I_TestValidLogin), typeof(TestValidLogin));
        }
        
        public static void InitializeMonitorObserves() {
            PModule.monitorObserves.Clear();
            PModule.monitorObserves[nameof(AccessControlSafety)] = new List<string>();
            PModule.monitorObserves[nameof(AccessControlSafety)].Add(nameof(eAccessGranted));
            PModule.monitorObserves[nameof(AccessControlSafety)].Add(nameof(eCredentialsAccepted));
            PModule.monitorObserves[nameof(AccessControlSafety)].Add(nameof(eMFAAccepted));
            PModule.monitorObserves[nameof(AccessControlSafety)].Add(nameof(eSessionEnded));
            PModule.monitorObserves[nameof(LockoutSafety)] = new List<string>();
            PModule.monitorObserves[nameof(LockoutSafety)].Add(nameof(eAccessGranted));
            PModule.monitorObserves[nameof(LockoutSafety)].Add(nameof(eAccountLocked));
        }
        
        public static void InitializeMonitorMap(ControlledRuntime runtime) {
            PModule.monitorMap.Clear();
            PModule.monitorMap[nameof(I_AuthenticationServer)] = new List<Type>();
            PModule.monitorMap[nameof(I_AuthenticationServer)].Add(typeof(AccessControlSafety));
            PModule.monitorMap[nameof(I_AuthenticationServer)].Add(typeof(LockoutSafety));
            PModule.monitorMap[nameof(I_TestValidLogin)] = new List<Type>();
            PModule.monitorMap[nameof(I_TestValidLogin)].Add(typeof(AccessControlSafety));
            PModule.monitorMap[nameof(I_TestValidLogin)].Add(typeof(LockoutSafety));
            runtime.RegisterMonitor<AccessControlSafety>();
            runtime.RegisterMonitor<LockoutSafety>();
        }
        
        
        [PChecker.SystematicTesting.Test]
        public static void Execute(ControlledRuntime runtime) {
            InitializeGlobalParams();
            runtime.RegisterLog(new PCheckerLogTextFormatter());
            runtime.RegisterLog(new PCheckerLogJsonFormatter());
            PModule.runtime = runtime;
            PHelper.InitializeInterfaces();
            PHelper.InitializeEnums();
            InitializeLinkMap();
            InitializeInterfaceDefMap();
            InitializeMonitorMap(runtime);
            InitializeMonitorObserves();
            runtime.CreateStateMachine(typeof(TestValidLogin), "TestValidLogin");
        }
    }
}
namespace PImplementation
{
    public class tcUnauthenticatedAccess {
        public static void InitializeGlobalParams() {
        }
        public static void InitializeLinkMap() {
            PModule.linkMap.Clear();
            PModule.linkMap[nameof(I_AuthenticationServer)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_TestUnauthenticatedAccess)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_TestUnauthenticatedAccess)].Add(nameof(I_AuthenticationServer), nameof(I_AuthenticationServer));
        }
        
        public static void InitializeInterfaceDefMap() {
            PModule.interfaceDefinitionMap.Clear();
            PModule.interfaceDefinitionMap.Add(nameof(I_AuthenticationServer), typeof(AuthenticationServer));
            PModule.interfaceDefinitionMap.Add(nameof(I_TestUnauthenticatedAccess), typeof(TestUnauthenticatedAccess));
        }
        
        public static void InitializeMonitorObserves() {
            PModule.monitorObserves.Clear();
            PModule.monitorObserves[nameof(AccessControlSafety)] = new List<string>();
            PModule.monitorObserves[nameof(AccessControlSafety)].Add(nameof(eAccessGranted));
            PModule.monitorObserves[nameof(AccessControlSafety)].Add(nameof(eCredentialsAccepted));
            PModule.monitorObserves[nameof(AccessControlSafety)].Add(nameof(eMFAAccepted));
            PModule.monitorObserves[nameof(AccessControlSafety)].Add(nameof(eSessionEnded));
            PModule.monitorObserves[nameof(LockoutSafety)] = new List<string>();
            PModule.monitorObserves[nameof(LockoutSafety)].Add(nameof(eAccessGranted));
            PModule.monitorObserves[nameof(LockoutSafety)].Add(nameof(eAccountLocked));
        }
        
        public static void InitializeMonitorMap(ControlledRuntime runtime) {
            PModule.monitorMap.Clear();
            PModule.monitorMap[nameof(I_AuthenticationServer)] = new List<Type>();
            PModule.monitorMap[nameof(I_AuthenticationServer)].Add(typeof(AccessControlSafety));
            PModule.monitorMap[nameof(I_AuthenticationServer)].Add(typeof(LockoutSafety));
            PModule.monitorMap[nameof(I_TestUnauthenticatedAccess)] = new List<Type>();
            PModule.monitorMap[nameof(I_TestUnauthenticatedAccess)].Add(typeof(AccessControlSafety));
            PModule.monitorMap[nameof(I_TestUnauthenticatedAccess)].Add(typeof(LockoutSafety));
            runtime.RegisterMonitor<AccessControlSafety>();
            runtime.RegisterMonitor<LockoutSafety>();
        }
        
        
        [PChecker.SystematicTesting.Test]
        public static void Execute(ControlledRuntime runtime) {
            InitializeGlobalParams();
            runtime.RegisterLog(new PCheckerLogTextFormatter());
            runtime.RegisterLog(new PCheckerLogJsonFormatter());
            PModule.runtime = runtime;
            PHelper.InitializeInterfaces();
            PHelper.InitializeEnums();
            InitializeLinkMap();
            InitializeInterfaceDefMap();
            InitializeMonitorMap(runtime);
            InitializeMonitorObserves();
            runtime.CreateStateMachine(typeof(TestUnauthenticatedAccess), "TestUnauthenticatedAccess");
        }
    }
}
namespace PImplementation
{
    public class tcInvalidTOTP {
        public static void InitializeGlobalParams() {
        }
        public static void InitializeLinkMap() {
            PModule.linkMap.Clear();
            PModule.linkMap[nameof(I_AuthenticationServer)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_TestInvalidTOTP)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_TestInvalidTOTP)].Add(nameof(I_AuthenticationServer), nameof(I_AuthenticationServer));
        }
        
        public static void InitializeInterfaceDefMap() {
            PModule.interfaceDefinitionMap.Clear();
            PModule.interfaceDefinitionMap.Add(nameof(I_AuthenticationServer), typeof(AuthenticationServer));
            PModule.interfaceDefinitionMap.Add(nameof(I_TestInvalidTOTP), typeof(TestInvalidTOTP));
        }
        
        public static void InitializeMonitorObserves() {
            PModule.monitorObserves.Clear();
            PModule.monitorObserves[nameof(AccessControlSafety)] = new List<string>();
            PModule.monitorObserves[nameof(AccessControlSafety)].Add(nameof(eAccessGranted));
            PModule.monitorObserves[nameof(AccessControlSafety)].Add(nameof(eCredentialsAccepted));
            PModule.monitorObserves[nameof(AccessControlSafety)].Add(nameof(eMFAAccepted));
            PModule.monitorObserves[nameof(AccessControlSafety)].Add(nameof(eSessionEnded));
            PModule.monitorObserves[nameof(LockoutSafety)] = new List<string>();
            PModule.monitorObserves[nameof(LockoutSafety)].Add(nameof(eAccessGranted));
            PModule.monitorObserves[nameof(LockoutSafety)].Add(nameof(eAccountLocked));
        }
        
        public static void InitializeMonitorMap(ControlledRuntime runtime) {
            PModule.monitorMap.Clear();
            PModule.monitorMap[nameof(I_AuthenticationServer)] = new List<Type>();
            PModule.monitorMap[nameof(I_AuthenticationServer)].Add(typeof(AccessControlSafety));
            PModule.monitorMap[nameof(I_AuthenticationServer)].Add(typeof(LockoutSafety));
            PModule.monitorMap[nameof(I_TestInvalidTOTP)] = new List<Type>();
            PModule.monitorMap[nameof(I_TestInvalidTOTP)].Add(typeof(AccessControlSafety));
            PModule.monitorMap[nameof(I_TestInvalidTOTP)].Add(typeof(LockoutSafety));
            runtime.RegisterMonitor<AccessControlSafety>();
            runtime.RegisterMonitor<LockoutSafety>();
        }
        
        
        [PChecker.SystematicTesting.Test]
        public static void Execute(ControlledRuntime runtime) {
            InitializeGlobalParams();
            runtime.RegisterLog(new PCheckerLogTextFormatter());
            runtime.RegisterLog(new PCheckerLogJsonFormatter());
            PModule.runtime = runtime;
            PHelper.InitializeInterfaces();
            PHelper.InitializeEnums();
            InitializeLinkMap();
            InitializeInterfaceDefMap();
            InitializeMonitorMap(runtime);
            InitializeMonitorObserves();
            runtime.CreateStateMachine(typeof(TestInvalidTOTP), "TestInvalidTOTP");
        }
    }
}
namespace PImplementation
{
    public class tcAccountLockout {
        public static void InitializeGlobalParams() {
        }
        public static void InitializeLinkMap() {
            PModule.linkMap.Clear();
            PModule.linkMap[nameof(I_AuthenticationServer)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_TestAccountLockout)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_TestAccountLockout)].Add(nameof(I_AuthenticationServer), nameof(I_AuthenticationServer));
        }
        
        public static void InitializeInterfaceDefMap() {
            PModule.interfaceDefinitionMap.Clear();
            PModule.interfaceDefinitionMap.Add(nameof(I_AuthenticationServer), typeof(AuthenticationServer));
            PModule.interfaceDefinitionMap.Add(nameof(I_TestAccountLockout), typeof(TestAccountLockout));
        }
        
        public static void InitializeMonitorObserves() {
            PModule.monitorObserves.Clear();
            PModule.monitorObserves[nameof(AccessControlSafety)] = new List<string>();
            PModule.monitorObserves[nameof(AccessControlSafety)].Add(nameof(eAccessGranted));
            PModule.monitorObserves[nameof(AccessControlSafety)].Add(nameof(eCredentialsAccepted));
            PModule.monitorObserves[nameof(AccessControlSafety)].Add(nameof(eMFAAccepted));
            PModule.monitorObserves[nameof(AccessControlSafety)].Add(nameof(eSessionEnded));
            PModule.monitorObserves[nameof(LockoutSafety)] = new List<string>();
            PModule.monitorObserves[nameof(LockoutSafety)].Add(nameof(eAccessGranted));
            PModule.monitorObserves[nameof(LockoutSafety)].Add(nameof(eAccountLocked));
        }
        
        public static void InitializeMonitorMap(ControlledRuntime runtime) {
            PModule.monitorMap.Clear();
            PModule.monitorMap[nameof(I_AuthenticationServer)] = new List<Type>();
            PModule.monitorMap[nameof(I_AuthenticationServer)].Add(typeof(AccessControlSafety));
            PModule.monitorMap[nameof(I_AuthenticationServer)].Add(typeof(LockoutSafety));
            PModule.monitorMap[nameof(I_TestAccountLockout)] = new List<Type>();
            PModule.monitorMap[nameof(I_TestAccountLockout)].Add(typeof(AccessControlSafety));
            PModule.monitorMap[nameof(I_TestAccountLockout)].Add(typeof(LockoutSafety));
            runtime.RegisterMonitor<AccessControlSafety>();
            runtime.RegisterMonitor<LockoutSafety>();
        }
        
        
        [PChecker.SystematicTesting.Test]
        public static void Execute(ControlledRuntime runtime) {
            InitializeGlobalParams();
            runtime.RegisterLog(new PCheckerLogTextFormatter());
            runtime.RegisterLog(new PCheckerLogJsonFormatter());
            PModule.runtime = runtime;
            PHelper.InitializeInterfaces();
            PHelper.InitializeEnums();
            InitializeLinkMap();
            InitializeInterfaceDefMap();
            InitializeMonitorMap(runtime);
            InitializeMonitorObserves();
            runtime.CreateStateMachine(typeof(TestAccountLockout), "TestAccountLockout");
        }
    }
}
namespace PImplementation
{
    public class tcSessionTermination {
        public static void InitializeGlobalParams() {
        }
        public static void InitializeLinkMap() {
            PModule.linkMap.Clear();
            PModule.linkMap[nameof(I_AuthenticationServer)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_TestSessionTermination)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_TestSessionTermination)].Add(nameof(I_AuthenticationServer), nameof(I_AuthenticationServer));
        }
        
        public static void InitializeInterfaceDefMap() {
            PModule.interfaceDefinitionMap.Clear();
            PModule.interfaceDefinitionMap.Add(nameof(I_AuthenticationServer), typeof(AuthenticationServer));
            PModule.interfaceDefinitionMap.Add(nameof(I_TestSessionTermination), typeof(TestSessionTermination));
        }
        
        public static void InitializeMonitorObserves() {
            PModule.monitorObserves.Clear();
            PModule.monitorObserves[nameof(AccessControlSafety)] = new List<string>();
            PModule.monitorObserves[nameof(AccessControlSafety)].Add(nameof(eAccessGranted));
            PModule.monitorObserves[nameof(AccessControlSafety)].Add(nameof(eCredentialsAccepted));
            PModule.monitorObserves[nameof(AccessControlSafety)].Add(nameof(eMFAAccepted));
            PModule.monitorObserves[nameof(AccessControlSafety)].Add(nameof(eSessionEnded));
            PModule.monitorObserves[nameof(LockoutSafety)] = new List<string>();
            PModule.monitorObserves[nameof(LockoutSafety)].Add(nameof(eAccessGranted));
            PModule.monitorObserves[nameof(LockoutSafety)].Add(nameof(eAccountLocked));
        }
        
        public static void InitializeMonitorMap(ControlledRuntime runtime) {
            PModule.monitorMap.Clear();
            PModule.monitorMap[nameof(I_AuthenticationServer)] = new List<Type>();
            PModule.monitorMap[nameof(I_AuthenticationServer)].Add(typeof(AccessControlSafety));
            PModule.monitorMap[nameof(I_AuthenticationServer)].Add(typeof(LockoutSafety));
            PModule.monitorMap[nameof(I_TestSessionTermination)] = new List<Type>();
            PModule.monitorMap[nameof(I_TestSessionTermination)].Add(typeof(AccessControlSafety));
            PModule.monitorMap[nameof(I_TestSessionTermination)].Add(typeof(LockoutSafety));
            runtime.RegisterMonitor<AccessControlSafety>();
            runtime.RegisterMonitor<LockoutSafety>();
        }
        
        
        [PChecker.SystematicTesting.Test]
        public static void Execute(ControlledRuntime runtime) {
            InitializeGlobalParams();
            runtime.RegisterLog(new PCheckerLogTextFormatter());
            runtime.RegisterLog(new PCheckerLogJsonFormatter());
            PModule.runtime = runtime;
            PHelper.InitializeInterfaces();
            PHelper.InitializeEnums();
            InitializeLinkMap();
            InitializeInterfaceDefMap();
            InitializeMonitorMap(runtime);
            InitializeMonitorObserves();
            runtime.CreateStateMachine(typeof(TestSessionTermination), "TestSessionTermination");
        }
    }
}
// TODO: NamedModule AuthenticationSystem
namespace PImplementation
{
    public class I_AuthenticationServer : PMachineValue {
        public I_AuthenticationServer (StateMachineId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public class I_TestValidLogin : PMachineValue {
        public I_TestValidLogin (StateMachineId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public class I_TestUnauthenticatedAccess : PMachineValue {
        public I_TestUnauthenticatedAccess (StateMachineId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public class I_TestInvalidTOTP : PMachineValue {
        public I_TestInvalidTOTP (StateMachineId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public class I_TestAccountLockout : PMachineValue {
        public I_TestAccountLockout (StateMachineId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public class I_TestSessionTermination : PMachineValue {
        public I_TestSessionTermination (StateMachineId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public partial class PHelper {
        public static void InitializeInterfaces() {
            PInterfaces.Clear();
            PInterfaces.AddInterface(nameof(I_AuthenticationServer), nameof(eAccessDenied), nameof(eAccessGranted), nameof(eAccountLocked), nameof(eAuthenticationRejected), nameof(eCredentialRejected), nameof(eCredentialsAccepted), nameof(eMFAAccepted), nameof(eMFARejected), nameof(eRequestProtectedResource), nameof(eSessionEnded), nameof(eSubmitInvalidCredentials), nameof(eSubmitInvalidTOTP), nameof(eSubmitValidCredentials), nameof(eSubmitValidTOTP), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_TestValidLogin), nameof(eAccessDenied), nameof(eAccessGranted), nameof(eAccountLocked), nameof(eAuthenticationRejected), nameof(eCredentialRejected), nameof(eCredentialsAccepted), nameof(eMFAAccepted), nameof(eMFARejected), nameof(eRequestProtectedResource), nameof(eSessionEnded), nameof(eSubmitInvalidCredentials), nameof(eSubmitInvalidTOTP), nameof(eSubmitValidCredentials), nameof(eSubmitValidTOTP), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_TestUnauthenticatedAccess), nameof(eAccessDenied), nameof(eAccessGranted), nameof(eAccountLocked), nameof(eAuthenticationRejected), nameof(eCredentialRejected), nameof(eCredentialsAccepted), nameof(eMFAAccepted), nameof(eMFARejected), nameof(eRequestProtectedResource), nameof(eSessionEnded), nameof(eSubmitInvalidCredentials), nameof(eSubmitInvalidTOTP), nameof(eSubmitValidCredentials), nameof(eSubmitValidTOTP), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_TestInvalidTOTP), nameof(eAccessDenied), nameof(eAccessGranted), nameof(eAccountLocked), nameof(eAuthenticationRejected), nameof(eCredentialRejected), nameof(eCredentialsAccepted), nameof(eMFAAccepted), nameof(eMFARejected), nameof(eRequestProtectedResource), nameof(eSessionEnded), nameof(eSubmitInvalidCredentials), nameof(eSubmitInvalidTOTP), nameof(eSubmitValidCredentials), nameof(eSubmitValidTOTP), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_TestAccountLockout), nameof(eAccessDenied), nameof(eAccessGranted), nameof(eAccountLocked), nameof(eAuthenticationRejected), nameof(eCredentialRejected), nameof(eCredentialsAccepted), nameof(eMFAAccepted), nameof(eMFARejected), nameof(eRequestProtectedResource), nameof(eSessionEnded), nameof(eSubmitInvalidCredentials), nameof(eSubmitInvalidTOTP), nameof(eSubmitValidCredentials), nameof(eSubmitValidTOTP), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_TestSessionTermination), nameof(eAccessDenied), nameof(eAccessGranted), nameof(eAccountLocked), nameof(eAuthenticationRejected), nameof(eCredentialRejected), nameof(eCredentialsAccepted), nameof(eMFAAccepted), nameof(eMFARejected), nameof(eRequestProtectedResource), nameof(eSessionEnded), nameof(eSubmitInvalidCredentials), nameof(eSubmitInvalidTOTP), nameof(eSubmitValidCredentials), nameof(eSubmitValidTOTP), nameof(PHalt));
        }
    }
    
}
namespace PImplementation
{
    public partial class PHelper {
        public static void InitializeEnums() {
            PEnum.Clear();
        }
    }
    
}
#pragma warning restore 162, 219, 414
