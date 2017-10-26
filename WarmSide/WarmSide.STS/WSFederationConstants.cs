using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarmSide.STS
{
    public static class WSFederationConstants
    {
        internal const string Namespace = "http://docs.oasis-open.org/wsfed/federation/200706";

        public static class Actions
        {
            internal const string Attribute = "wattr1.0";
            internal const string Pseudonym = "wpseudo1.0";
            internal const string SignIn = "wsignin1.0";
            internal const string SignOut = "wsignout1.0";
            internal const string SignOutCleanup = "wsignoutcleanup1.0";
        }

        public static class Parameters
        {
            internal const string Action = "wa";
            internal const string Attribute = "wattr";
            internal const string AttributePtr = "wattrptr";
            internal const string AuthenticationType = "wauth";
            internal const string Context = "wctx";
            internal const string CurrentTime = "wct";
            internal const string Encoding = "wencoding";
            internal const string Federation = "wfed";
            internal const string Freshness = "wfresh";
            internal const string HomeRealm = "whr";
            internal const string Policy = "wp";
            internal const string Pseudonym = "wpseudo";
            internal const string PseudonymPtr = "wpseudoptr";
            internal const string Realm = "wtrealm";
            internal const string Reply = "wreply";
            internal const string Request = "wreq";
            internal const string RequestPtr = "wreqptr";
            internal const string Resource = "wres";
            internal const string Result = "wresult";
            internal const string ResultPtr = "wresultptr";
        }

        public static class FaultCodeValues
        {
            internal const string AlreadySignedIn = "AlreadySignedIn";
            internal const string BadRequest = "BadRequest";
            internal const string IssuerNameNotSupported = "IssuerNameNotSupported";
            internal const string NeedFresherCredentials = "NeedFresherCredentials";
            internal const string NoMatchInScope = "NoMatchInScope";
            internal const string NoPseudonymInScope = "NoPseudonymInScope";
            internal const string NotSignedIn = "NotSignedIn";
            internal const string RstParameterNotAccepted = "RstParameterNotAccepted";
            internal const string SpecificPolicy = "SpecificPolicy";
            internal const string UnsupportedClaimsDialect = "UnsupportedClaimsDialect";
            internal const string UnsupportedEncoding = "UnsupportedEncoding";
        }
    }
}