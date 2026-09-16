using UserService.FacadeLib.Commands.DTOs;

namespace UserService.FacadeLib.Commands.Interfaces;

public interface IRegisterUserHandler
{
    Task Handle(RegisterUserCommand command);
}
