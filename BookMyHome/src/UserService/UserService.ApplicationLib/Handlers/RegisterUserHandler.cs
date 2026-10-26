using BookMyHome.BuildingBlocksLib.Messaging;
using BookMyHome.ContractsLib.Events;
using Microsoft.Extensions.Logging;
using UserService.ApplicationLib.Authentication;
using UserService.ApplicationLib.Repositories;
using UserService.DomainLib.Entities;
using UserService.DomainLib.Enums;
using UserService.FacadeLib.Commands.DTOs;
using UserService.FacadeLib.Commands.Interfaces;

namespace UserService.ApplicationLib.Handlers;

public class RegisterUserHandler(
    IUserRepository userRepo,
    IPasswordHashService passwordHashService,
    IIntegrationEventPublisher eventPublisher,
    ILogger<RegisterUserHandler> logger
    ) : IRegisterUserHandler
{
    async Task IRegisterUserHandler.Handle(RegisterUserCommand command)
    {
        try
        {
            logger.LogInformation("Beginning to register user with name {firstname} {lastname}", command.FirstName, command.LastName);

            var normalizedEmail = command.Email.ToLower();

            var usernameExsist = await userRepo.UsernameExsistsAsync(normalizedEmail);

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

            logger.LogInformation("User created with id: {userId}", user.Id);

            await userRepo.RegisterUserAsync(user);

            await userRepo.SaveAsync();

            var integrationEvent = new UserRegisteredIntegrationEvent(
                user.FirstName,
                user.LastName,
                user.Email.Value,
                user.Username
                );

            logger.LogInformation("Starting to publish event");

            await eventPublisher.PublishAsync("user-registered", integrationEvent);

            logger.LogInformation("Event has been published");
        }
        catch (Exception ex)
        {
            logger.LogError("Error {errorMessage}",ex.Message);
            throw;
        }
    }
}
