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
        public string email { get; set; } = string.Empty;

        [Column("password")]
        public string password { get; set; } = string.Empty;

        [Column("fullname")]
        public string fullname { get; set; } = string.Empty;

        [Column("phone_number")]
        public string phone_number { get; set; } = string.Empty;

        [Column("address")]
        public string address { get; set; } = string.Empty;

        [Column("status")]
        [EnumDataType(typeof(AccountStatus))]
        public AccountStatus status { get; set; } = AccountStatus.Active;

        [Column("role")]
        [EnumDataType(typeof(RoleType))]
        public RoleType role { get; set; } = RoleType.Customer;

        [InverseProperty("staff")]
        public ICollection<Post> StaffPosts{ get; set; } = new List<Post>();

        [InverseProperty("Customer")]
        public ICollection<Order> CustomerOrders { get; set; } = new List<Order>();
        [InverseProperty("Customer")]
        public ICollection<Report> CustomerReports { get; set; } = new List<Report>();
        [InverseProperty("Customer")]
        public ICollection<Feedback> CustomerFeedbacks { get; set; } = new List<Feedback>();
    }
}
