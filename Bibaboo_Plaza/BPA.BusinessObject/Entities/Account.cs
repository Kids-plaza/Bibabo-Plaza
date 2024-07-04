using BPA.BusinessObject.Common;
using BPA.BusinessObject.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.BusinessObject.Entities
{
    [Table("Account")]
    public class Account : BaseEntity
    {
        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("password")]
        public string Password { get; set; } = string.Empty;

        [Column("fullname")]
        public string FullName { get; set; } = string.Empty;

        [Column("phone_number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Column("address")]
        public string Address { get; set; } = string.Empty;

        [Column("status")]
        [EnumDataType(typeof(AccountStatus))]
        public AccountStatus Status { get; set; } = AccountStatus.Active;

        [Column("role")]
        [EnumDataType(typeof(RoleType))]
        public RoleType Role { get; set; } = RoleType.Customer;

        [InverseProperty("Staff")]
        public virtual ICollection<Post> StaffPosts{ get; set; } = new List<Post>();

        [InverseProperty("Customer")]
        public ICollection<Order> CustomerOrders { get; set; } = new List<Order>();
    }
}
