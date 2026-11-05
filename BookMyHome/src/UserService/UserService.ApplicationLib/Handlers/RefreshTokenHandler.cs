using UserService.ApplicationLib.Authentication;
using UserService.ApplicationLib.Repositories;
using UserService.FacadeLib.Commands.DTOs;
using UserService.FacadeLib.Commands.Interfaces;

namespace UserService.ApplicationLib.Handlers;

public class RefreshTokenHandler(IUserRepository userRepo, ITokenService tokenService, IRefreshTokenService refreshTokenService) : IRefreshTokensHandler
{
    async Task<TokenDto?> IRefreshTokensHandler.HandleAsync(RefreshTokenCommand command)
    {
        var principal = tokenService.GetPrincipalFromExpiredToken(command.ExpiredAccessToken);

        if (principal.Identity == null || principal.Identity.Name == null)
            throw new ArgumentNullException(nameof(principal));

        var user = await userRepo.GetUserByUsernameAsync(principal.Identity.Name);

        if (
            user == null
            || user.RefreshToken != command.RefreshToken
            || user.RefreshTokenExpiryTime <= DateTime.UtcNow
            )
            return null;

        var token = tokenService.CreateToken(user);
        var refreshToken = refreshTokenService.GenerateRefreshToken();

        user.SetRefreshToken(refreshToken, false);

        await userRepo.SaveAsync();

        var dto = new TokenDto(token, refreshToken);

        return dto;
    }
}
