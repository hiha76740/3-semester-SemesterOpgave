using Shared.BookMyHome.SharedKernelLib.Exceptions;
using UserService.ApplicationLib.Repositories;
using UserService.FacadeLib.Commands.DTOs;
using UserService.FacadeLib.Commands.Interfaces;

namespace UserService.ApplicationLib.Handlers
{
    internal class LoginHandler(IUserRepository userRepo) : ILoginHandler
    {
        async Task ILoginHandler.HandleAsync(LoginCommand command)
        {
            var user = await userRepo.GetUserByUsernameAsync(command.Username);

            if (user == null)
                throw new NotFoundException("User or password was incorrect");

            

            


        }
    }
}
