using UserService.FacadeLib.Commands.DTOs;

namespace UserService.FacadeLib.Commands.Interfaces;

public interface IRefreshTokensHandler
{
    Task<TokenDto> HandleAsync(RefreshTokenCommand command);
}
