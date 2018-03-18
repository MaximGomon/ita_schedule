using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;

namespace AspNet.Security.OAuth.Intita
{
    /// <summary>
    /// Defines a set of options used by <see cref="IntitaAuthenticationHandler"/>.
    /// </summary>
    public static class IntitaAuthenticationTicket
    {
        public static AuthenticationTicket Ticket { get; set; }
    }
}
