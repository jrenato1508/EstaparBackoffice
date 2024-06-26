﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EstaparBackoffice.Extensions.ClaimsAuthorize
{
    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequisitoClaimFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        }
    }
}
