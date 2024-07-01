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
        [Required]
        public string Content {  get; set; } = string.Empty;

        [Column("account_id")]
        [ForeignKey("account")]
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }

        [Column("product_id")]
        [ForeignKey("product")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
