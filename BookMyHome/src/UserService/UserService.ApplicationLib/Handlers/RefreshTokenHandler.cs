using UserService.ApplicationLib.Authentication;
using UserService.ApplicationLib.Repositories;
using UserService.DomainLib.Entities;
using UserService.FacadeLib.Commands.DTOs;
using UserService.FacadeLib.Commands.Interfaces;

namespace UserService.ApplicationLib.Handlers;

public class RefreshTokenHandler(IUserRepository userRepo, ITokenService tokenService, IRefreshTokenService refreshTokenService) : IRefreshTokensHandler
{
    async Task<TokenDto?> IRefreshTokensHandler.HandleAsync(RefreshTokenCommand command)
    {
        var userId = new UserId(command.id);

        var user = await userRepo.GetUserById(userId);

        if (
            user == null 
            || user.RefreshToken != command.RefreshToken 
            || user.RefreshTokenExpiryTime <= DateTime.UtcNow
            )
            return null;

        var token = tokenService.CreateToken(user);
        var refreshToken = refreshTokenService.GenerateRefreshToken();

        user.SetRefreshToken(refreshToken);

        await userRepo.SaveAsync();

        var dto = new TokenDto(token, refreshToken);

        return dto;
    }
}
