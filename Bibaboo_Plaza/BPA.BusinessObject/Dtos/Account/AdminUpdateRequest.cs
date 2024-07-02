using BPA.BusinessObject.Enums;
using System.ComponentModel.DataAnnotations;

namespace BPA.BusinessObject.Dtos.Account
{
    public class AdminUpdateRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(1), MaxLength(50)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [MinLength(1), MaxLength(200)]
        public string Address { get; set; } = string.Empty;
        [Required]
        public RoleType Role { get; set; }
        [Required]
        public AccountStatus Status { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
