using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AspNet.Security.OAuth.Intita
{
    public class IntitaAuthenticationHandler : OAuthHandler<IntitaAuthenticationOptions>
    {
        public IntitaAuthenticationHandler(
            [NotNull] IOptionsMonitor<IntitaAuthenticationOptions> options,
            [NotNull] ILoggerFactory logger,
            [NotNull] UrlEncoder encoder,
            [NotNull] ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override Task<object> CreateEventsAsync() => Task.FromResult<object>(new OAuthEvents());

        //protected override async Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
        //{
        //    var context = new OAuthCreatingTicketContext(new ClaimsPrincipal(identity), properties, Context, Scheme, Options, Backchannel, tokens);
        //    await Events.CreatingTicket(context);
        //    return new AuthenticationTicket(context.Principal, context.Properties, Scheme.Name);
        //}


        //protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
        //{
        //    if (string.IsNullOrEmpty(properties.RedirectUri))
        //    {
        //        properties.RedirectUri = CurrentUri;
        //    }

        //    // OAuth2 10.12 CSRF
        //    GenerateCorrelationId(properties);

        //    var authorizationEndpoint = BuildChallengeUrl(properties, BuildRedirectUri(Options.CallbackPath));
        //    var redirectContext = new RedirectContext<OAuthOptions>(
        //        Context, Scheme, Options,
        //        properties, authorizationEndpoint);
        //    await Events.RedirectToAuthorizationEndpoint(redirectContext);
        //}

        //protected override string BuildChallengeUrl(AuthenticationProperties properties, string redirectUri)
        //{
        //    var scope = FormatScope();

        //    var state = Options.StateDataFormat.Protect(properties);
        //    var parameters = new Dictionary<string, string>
        //    {
        //        { "client_id", Options.ClientId },
        //        { "scope", scope },
        //        { "response_type", "code" },
        //        { "redirect_uri", redirectUri },
        //        { "state", state },
        //    };
        //    return QueryHelpers.AddQueryString(Options.AuthorizationEndpoint, parameters);
        //}

        protected override string FormatScope()
        {
            // OAuth2 3.3 space separated
            return string.Join(" ", Options.Scope);
        }
        
        protected override async Task<HandleRequestResult> HandleRemoteAuthenticateAsync()
        {
            if (Request.Cookies.ContainsKey("IntitaKey"))
            {
                return HandleRequestResult.Success(IntitaAuthenticationTicket.Ticket);
            }
            var query = Request.Query;
            
            var state = query["state"];
            var properties = Options.StateDataFormat.Unprotect(state);

            if (properties == null)
            {
                return HandleRequestResult.Fail("The oauth state was missing or invalid.");
            }

            
            // OAuth2 10.12 CSRF
            //if (!ValidateCorrelationId(properties))
            //{
            //    return HandleRequestResult.Fail("Correlation failed.");
            //}

            var error = query["error"];
            if (!StringValues.IsNullOrEmpty(error))
            {
                var failureMessage = new StringBuilder();
                failureMessage.Append(error);
                var errorDescription = query["error_description"];
                if (!StringValues.IsNullOrEmpty(errorDescription))
                {
                    failureMessage.Append(";Description=").Append(errorDescription);
                }
                var errorUri = query["error_uri"];
                if (!StringValues.IsNullOrEmpty(errorUri))
                {
                    failureMessage.Append(";Uri=").Append(errorUri);
                }

                return HandleRequestResult.Fail(failureMessage.ToString());
            }

            var code = query["code"];

            if (StringValues.IsNullOrEmpty(code))
            {
                return HandleRequestResult.Fail("Code was not found.");
            }

            var tokens = await ExchangeCodeAsync(code, BuildRedirectUri(Options.CallbackPath));

            if (tokens.Error != null)
            {
                return HandleRequestResult.Fail(tokens.Error);
            }

            if (string.IsNullOrEmpty(tokens.AccessToken))
            {
                return HandleRequestResult.Fail("Failed to retrieve access token.");
            }

            var identity = new ClaimsIdentity(ClaimsIssuer);

            if (Options.SaveTokens)
            {
                var authTokens = new List<AuthenticationToken>();

                authTokens.Add(new AuthenticationToken { Name = "access_token", Value = tokens.AccessToken });
                if (!string.IsNullOrEmpty(tokens.RefreshToken))
                {
                    authTokens.Add(new AuthenticationToken { Name = "refresh_token", Value = tokens.RefreshToken });
                }

                if (!string.IsNullOrEmpty(tokens.TokenType))
                {
                    authTokens.Add(new AuthenticationToken { Name = "token_type", Value = tokens.TokenType });
                }

                if (!string.IsNullOrEmpty(tokens.ExpiresIn))
                {
                    int value;
                    if (int.TryParse(tokens.ExpiresIn, NumberStyles.Integer, CultureInfo.InvariantCulture, out value))
                    {
                        var expiresAt = Clock.UtcNow + TimeSpan.FromSeconds(value);
                        authTokens.Add(new AuthenticationToken
                        {
                            Name = "expires_at",
                            Value = expiresAt.ToString("o", CultureInfo.InvariantCulture)
                        });
                    }
                }

                properties.StoreTokens(authTokens);
            }
            
            var ticket = await CreateTicketAsync(identity, properties, tokens);
            if (ticket != null)
            {
                IntitaAuthenticationTicket.Ticket = ticket;
                Response.Cookies.Append("IntitaKey", tokens.AccessToken);
                return HandleRequestResult.Success(ticket);
                
            }
            else
            {
                return HandleRequestResult.Fail("Failed to retrieve user information from remote server.");
            }
        }
        
        //protected override async Task<OAuthTokenResponse> ExchangeCodeAsync(string code, string redirectUri)
        //{
        //    var tokenRequestParameters = new Dictionary<string, string>()
        //    {
        //        { "client_id", Options.ClientId },
        //        { "redirect_uri", redirectUri },
        //        { "client_secret", Options.ClientSecret },
        //        { "code", code },
        //        { "grant_type", "authorization_code" },
        //    };

        //    var requestContent = new FormUrlEncodedContent(tokenRequestParameters);

        //    var requestMessage = new HttpRequestMessage(HttpMethod.Post, Options.TokenEndpoint);
        //    requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    requestMessage.Content = requestContent;
        //    var response = await Backchannel.SendAsync(requestMessage, Context.RequestAborted);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var payload = JObject.Parse(await response.Content.ReadAsStringAsync());
        //        return OAuthTokenResponse.Success(payload);
        //    }
        //    else
        //    {
        //        var error = "OAuth token endpoint failure: " + await Display(response);
        //        return OAuthTokenResponse.Failed(new Exception(error));
        //    }
        //}
        //private static async Task<string> Display(HttpResponseMessage response)
        //{
        //    var output = new StringBuilder();
        //    output.Append("Status: " + response.StatusCode + ";");
        //    output.Append("Headers: " + response.Headers.ToString() + ";");
        //    output.Append("Body: " + await response.Content.ReadAsStringAsync() + ";");
        //    return output.ToString();
        //}
    }
}
