using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.IdentityModel.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Services;
using System.IdentityModel.Tokens;
using System.Security.Claims;


namespace WarmSide.STS
{
    public class WarmSideSecurityTokenService : SecurityTokenService
    {
        public WarmSideSecurityTokenService(SecurityTokenServiceConfiguration config)
            : base(config)
        {
        }

        // Returns information about the target of the token issuance

        protected override Scope GetScope(ClaimsPrincipal principal, RequestSecurityToken request)
        {
            if (request.AppliesTo == null)
            {
                throw new InvalidRequestException("The AppliesTo is null.");
            }
            Scope scope = new Scope(request.AppliesTo.Uri.OriginalString, SecurityTokenServiceConfiguration.SigningCredentials)
            {
                TokenEncryptionRequired = false,
                AppliesToAddress = request.AppliesTo.Uri.ToString(),
                SymmetricKeyEncryptionRequired = false,
                EncryptingCredentials = null,
                SigningCredentials = null,
                
            };

            if (string.IsNullOrEmpty(request.ReplyTo))
            {
                scope.ReplyToAddress = scope.AppliesToAddress;
            }
            else
            {
                scope.ReplyToAddress = request.ReplyTo;
            }

            return scope;
        }

        protected override ClaimsIdentity GetOutputClaimsIdentity(ClaimsPrincipal principal, RequestSecurityToken request, Scope scope)
        {
            if (principal == null)
                throw new InvalidRequestException("The caller's principal is null.");


            ((ClaimsIdentity)principal.Identity).AddClaim(new Claim("IdP/Claim1", "Hello from the Idp"));
 
            return principal.Identity as ClaimsIdentity;
        }

        public override RequestSecurityTokenResponse Issue(ClaimsPrincipal principal, RequestSecurityToken request)
        {
            return base.Issue(principal, request);
        }
    }

}