using UserService.FacadeLib.Commands.DTOs;

namespace UserService.FacadeLib.Commands.Interfaces;

public interface ILoginHandler
{
    Task<string?> HandleAsync(LoginCommand command);
}
