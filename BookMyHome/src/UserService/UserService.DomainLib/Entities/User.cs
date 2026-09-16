using Shared.BookMyHome.SharedKernelLib.Exceptions;
using UserService.DomainLib.Enums;
using UserService.DomainLib.ValueObject;

namespace UserService.DomainLib.Entities
{
    public class User
    {
        public UserId Id { get; init; }
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public DateOnly Birthdate { get; init; }
        public Address Address { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Email Email { get; private set; }
        public UserRoles Role { get; private set; }

        public string Username { get; init; }
        public string PasswordHash { get; private set; } = string.Empty;



        public static User Create(
            string firstName,
            string lastName,
            DateOnly birthdate, 
            string street,
            string postalCode,
            string city, 
            string phoneNumber, 
            string email, 
            string passwordHash,
            UserRoles role
            )
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new DomainException("First name can not be empty");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new DomainException("Last name can not be empty");

            if (birthdate <= DateOnly.FromDateTime(DateTime.Today))
                throw new DomainException("Birth date has to be in the past");

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new DomainException("Password Hash can not be empty");

            var address = new Address(street, postalCode, city);
            var pNumber = new PhoneNumber(phoneNumber);
            var emailAddress = new Email(email);

            var user = new User(firstName, lastName, birthdate, address, pNumber, emailAddress, passwordHash, role);

            return user;

        }

        public void ChangeFirstName(string newFirstName)
        {
            if (string.IsNullOrWhiteSpace(newFirstName))
                throw new DomainException("New firstname can not be empty");

            if (newFirstName == FirstName)
                throw new DomainException("New and old first name can not be the same");

            FirstName = newFirstName;
        }

        public void ChangeLastName(string newLastName)
        {
            if (string.IsNullOrWhiteSpace(newLastName))
                throw new DomainException("New lastname can not be empty");

            if (newLastName == LastName)
                throw new DomainException("New and old lastname can not be the same");

            LastName = newLastName;
        }

        public void ChangeAddress(string street, string postalCode, string city)
        {
            var newAddress = new Address(street, postalCode, city);

            if (Address == newAddress)
                throw new DomainException("New and old address can not be the same");

            Address = newAddress;
        }

        public void ChangeEmail(string email)
        {
            var newEmail = new Email(email);

            if (Email == newEmail)
                throw new DomainException("New and old email can not be the same");

            Email = newEmail;
        }

        public void ChangePhoneNumber(string phoneNumber)
        {
            var newPhoneNumber = new PhoneNumber(phoneNumber);

            if (PhoneNumber == newPhoneNumber)
                throw new DomainException("new and old phone number can not be the same");

            PhoneNumber = newPhoneNumber;
        }

        private User(string firstName, string lastName, DateOnly birthdate, Address address, PhoneNumber phoneNumber, Email email, string passwordHash, UserRoles role)
        {
            Id = new UserId(Guid.NewGuid());
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            Username = email.EmailAddress;
            PasswordHash = passwordHash;
            Role = role;
        }

        // EF constructor
        private User() { }
    }
}
