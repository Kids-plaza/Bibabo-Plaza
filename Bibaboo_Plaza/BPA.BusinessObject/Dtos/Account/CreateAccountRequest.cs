using BPA.BusinessObject.Enums;

namespace BPA.BusinessObject.Account
{
    public class CreateAccountRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public RoleType Role { get; set; } = RoleType.Customer;
    }
}
