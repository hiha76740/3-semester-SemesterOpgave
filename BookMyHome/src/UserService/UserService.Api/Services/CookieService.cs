using UserService.FacadeLib.Commands.DTOs;

namespace UserService.Api.Services
{
    public class CookieService : ICookieService
    {
        void ICookieService.SetTokenInsideCookie(TokenDto token, HttpContext context)
        {
            context.Response.Cookies.Append("accessToken", token.AccessToken,
               new CookieOptions
               {
                   Expires = DateTimeOffset.UtcNow.AddMinutes(5),
                   HttpOnly = true,
                   IsEssential = true,
                   Secure = false,
                   SameSite = SameSiteMode.None
               });

            context.Response.Cookies.Append("refreshToken", token.RefreshToken,
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(7),
                    HttpOnly = true,
                    IsEssential = true,
                    Secure = false,
                    SameSite = SameSiteMode.None
                });
        }
    }
}
