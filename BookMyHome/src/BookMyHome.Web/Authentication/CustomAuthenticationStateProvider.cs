using BookMyHome.Web.ServiceInterfaces;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net;
using System.Security.Claims;

namespace BookMyHome.Web.Authentication
{
    public class CustomAuthenticationStateProvider(IAuthService authService) : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var authUser = await authService.GetAuthUserAsync();

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, authUser.Id.ToString()),
                    new Claim(ClaimTypes.Name, authUser.Username),
                    new Claim(ClaimTypes.GivenName, authUser.Firstname),
                    new Claim(ClaimTypes.Surname, authUser.Lastname),
                    new Claim(ClaimTypes.Role, authUser.Role)
                };

                var identity = new ClaimsIdentity(claims, "ApiAuthentication");
                var user = new ClaimsPrincipal(identity);

                return new AuthenticationState(user);
            }
            catch (HttpRequestException ex)
            when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());

                return new AuthenticationState(anonymousUser);
            }
        }

        public async Task RefreshAuthenticationState()
        {
            var state = await GetAuthenticationStateAsync();

            NotifyAuthenticationStateChanged(Task.FromResult(state));
        }
    }
}
