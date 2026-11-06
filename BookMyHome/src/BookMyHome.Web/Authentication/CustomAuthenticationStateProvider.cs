using BookMyHome.Web.ServiceInterfaces;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net;
using System.Security.Claims;

namespace BookMyHome.Web.Authentication;

/// <summary>
/// 
/// </summary>
/// <param name="authService"></param>
public class CustomAuthenticationStateProvider(IAuthService authService) : AuthenticationStateProvider
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var authUser = await authService.GetAuthUserAsync();

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, authUser.Id.ToString()),
                new(ClaimTypes.Name, authUser.Username),
                new(ClaimTypes.GivenName, authUser.Firstname),
                new(ClaimTypes.Surname, authUser.Lastname),
                new(ClaimTypes.Role, authUser.Role)
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

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task RefreshAuthenticationState()
    {
        var state = await GetAuthenticationStateAsync();

        NotifyAuthenticationStateChanged(Task.FromResult(state));
    }
}
