using System.ComponentModel.DataAnnotations;

namespace BPA.BusinessObject.Dtos.Account
{
    public class UpdateAccountRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        [MinLength(1), MaxLength(50)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [MinLength(1), MaxLength(200)]
        public string Address { get; set; } = string.Empty;
    }
}
