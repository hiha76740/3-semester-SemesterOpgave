using UserService.FacadeLib.Commands.DTOs;

namespace UserService.Api.Services
{
    public interface ICookieService
    {
        void SetTokenInsideCookie(TokenDto token, HttpContext context);
    }
}
