using BPA.BusinessObject.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.BusinessObject.Entities
{
    [Table("Feedback")]
    public class Feedback : BaseEntity
    {
        [Column("content")]
        public string Content {  get; set; } = string.Empty;

        [Column("customer_id")]
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public virtual Account Customer { get; set; }

        [Column("product_id")]
        [ForeignKey("product")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
