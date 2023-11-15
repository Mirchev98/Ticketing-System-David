using System.ComponentModel.DataAnnotations;
using TicketingSystem.Common;

namespace TicketingSystemDavid.ViewModels.User
{
    public class RegisterFormModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.PasswordLenMax, MinimumLength = DataConstants.PassowordLenMin,
            ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.UserFirstNameMaxLen, MinimumLength = DataConstants.UserFirstNameMinLen)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.UserLastNameMaxLen, MinimumLength = DataConstants.UserLastNameMinLen)]
        public string LastName { get; set; } = null!;
    }
}
