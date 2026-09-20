using System.ComponentModel.DataAnnotations;

namespace BookMyHome.Web.Models
{
    public class UserModel
    {
        [Required]
        public string FirstName { get; set; } = "Harry";
        [Required]
        public string LastName { get; set; } = "Potter";
        [Required]
        public DateOnly Birthdate { get; set; } = new DateOnly(1987,07,30);
        [Required]
        public string Street { get; set; } = "Legustervænget 7";
        [Required]
        public string PostalCode { get; set; } = "7100";
        [Required]
        public string City { get; set; } = "Vejle";
        [Required]
        public string PhoneNumber { get; set; } = "95175382";
        [Required]
        public string Email { get; set; } = "HarryPotter@Hogwarts.test";
        [Required]
        public string Password { get; set; } = "Hedwig";
        [Required]
        public string Role { get; set; } = "Guest";
    }
}
