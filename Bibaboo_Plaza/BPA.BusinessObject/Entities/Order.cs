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
    [Table("Order")]
    public class Order : BaseEntity
    {
        [Column("total_price")]
        public double TotalPrice { get; set; } = 0;

        [Column("total_quantity")]
        public int TotalQuantity { get; set; } = 0;

        [Column("order_status")]
        [EnumDataType(typeof(OrderStatus))]
        public OrderStatus OrderStatus { get; set; } = OrderStatus.InCart;

        [Column("customer_id")]
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public virtual Account Customer { get; set; } = null!;

        [InverseProperty("Order")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
