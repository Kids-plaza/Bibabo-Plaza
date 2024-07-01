using BPA.BusinessObject.Enums;

namespace BPA.BusinessObject.Account
{
    public class UpdateAccountRequest
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;     
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public RoleType Role { get; set; } = RoleType.Customer;
        public AccountStatus Status { get; set; } = AccountStatus.Active;
        public bool IsDeleted { get; set; } = false;
    }
}
