using Moq;
using UserService.ApplicationLib.Authentication;
using UserService.ApplicationLib.Handlers;
using UserService.ApplicationLib.Repositories;
using UserService.DomainLib.Entities;
using UserService.FacadeLib.Commands.DTOs;
using UserService.FacadeLib.Commands.Interfaces;

namespace UserService.ApplicationLib.Tests;

public class RegisterUserTests
{
    [Fact]
    public async Task Handle_GivenValidData_CallsRegisterAndSave()
    {
        // Arrange
        string firstName = "Tom";
        string lastName = "Felton";
        DateOnly birthdate = new DateOnly(1987, 9, 27);
        string street = "Vejlevej 42";
        string postalCode = "7100";
        string city = "Vejle";
        string phoneNumber = "12345678";
        string email = "Test@test.dk";
        string password = "Password";
        string role = "Guest";

        string hashedPassword = "hashedPassword";

        var mockUserRepo = new Mock<IUserRepository>();
        var mockPasswordHash = new Mock<IPasswordHashService>();

        mockUserRepo
            .Setup(r => r.UsernameExsistsAsync(It.IsAny<string>()))
            .ReturnsAsync(false);

        mockPasswordHash
            .Setup(s => s.Hash(It.IsAny<string>()))
            .Returns(hashedPassword);

        var command = new RegisterUserCommand(
            firstName,
            lastName,
            birthdate,
            street,
            postalCode,
            city,
            phoneNumber,
            email,
            password,
            role
            );

        var handler = new RegisterUserHandler(mockUserRepo.Object, mockPasswordHash.Object) as IRegisterUserHandler;

        // Act
        await handler.Handle(command);

        // Assert
        mockUserRepo.Verify(r => r.RegisterUserAsync(It.IsAny<User>()), Times.Once);
        mockUserRepo.Verify(r => r.SaveAsync(), Times.Once);

        

    }
}
