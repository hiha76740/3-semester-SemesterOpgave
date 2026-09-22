using UserService.ApplicationLib.Authentication;
using UserService.ApplicationLib.Repositories;
using UserService.DomainLib.Entities;
using UserService.DomainLib.Enums;
using UserService.FacadeLib.Commands.DTOs;
using UserService.FacadeLib.Commands.Interfaces;

namespace UserService.ApplicationLib.Handlers;

public class RegisterUserHandler(
    IUserRepository userRepo,
    IPasswordHashService passwordHashService
    ) : IRegisterUserHandler
{
    async Task IRegisterUserHandler.Handle(RegisterUserCommand command)
    {
        var normalizedEmail = command.Email.ToLower();

        var usernameExsist =  await userRepo.UsernameExsistsAsync(normalizedEmail);   

        if (usernameExsist == true)
            throw new ArgumentException("User already exsist");

        if (Enum.TryParse<AccessRoles>(command.Role, ignoreCase: true, out var role) == false)
            throw new ArgumentException($"Invalid role: {command.Role}");

        var hashPassword = passwordHashService.Hash(command.Password);

        var user = User.Create(
            command.FirstName,
            command.LastName,
            command.Birthdate,
            command.Street,
            command.PostalCode,
            command.City,
            command.PhoneNumber,
            command.Email,
            hashPassword,
            role
            );

        await userRepo.RegisterUserAsync(user);

        await userRepo.SaveAsync();
    }
}
