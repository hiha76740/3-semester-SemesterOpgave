using UserService.ApplicationLib.Authentication;
using UserService.ApplicationLib.Repositories;
using UserService.FacadeLib.Commands.DTOs;
using UserService.FacadeLib.Commands.Interfaces;

namespace UserService.ApplicationLib.Handlers
{
    public class LoginHandler(IUserRepository userRepo, IPasswordHashService passwordHashService, ITokenService tokenService, IRefreshTokenService refreshTokenService) : ILoginHandler
    {
        async Task<TokenDto?> ILoginHandler.HandleAsync(LoginCommand command)
        {
            var user = await userRepo.GetUserByUsernameAsync(command.Username);

            if (user == null)
                return null;

            if (passwordHashService.Verify(command.password, user.PasswordHash) == false)
                return null;


            string token = tokenService.CreateToken(user);
            
            string refreshToken = refreshTokenService.GenerateRefreshToken();

            user.SetRefreshToken(refreshToken);

            await userRepo.SaveAsync();

            var dto = new TokenDto(token, refreshToken);

            return dto;
        }
    }
}
