namespace BookMyHome.Web.Models
{
    public class UserInputModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateOnly Birthdate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
        public string Street { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string RepeatPassword { get; set; } = string.Empty;
        public string AccessRole { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
}
