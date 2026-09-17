using UserService.ApplicationLib.Authentication;
using UserService.ApplicationLib.Repositories;
using UserService.FacadeLib.Commands.DTOs;
using UserService.FacadeLib.Commands.Interfaces;

namespace UserService.ApplicationLib.Handlers
{
    public class LoginHandler(IUserRepository userRepo, IPasswordHashService passwordHashService, ITokenService tokenService) : ILoginHandler
    {
        async Task<string?> ILoginHandler.HandleAsync(LoginCommand command)
        {
            var user = await userRepo.GetUserByUsernameAsync(command.Username);

            if (user == null)
                return null;

            if (passwordHashService.Verify(command.password, user.PasswordHash) == false)
                return null;


            string token = tokenService.CreateToken(user);

            return token;
        }
    }
}
