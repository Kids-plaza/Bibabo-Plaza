using BPA.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.Domain.Entities
{
    [Table("type")]
    public class ProductType : BaseEntity
    {
        [Column("type_name")]
        [Required]
        public string TypeName { get; set; } = string.Empty;

        [Column("description")]
        [Required]
        public string Description { get; set; } = string.Empty;

        [Column("product_id")]
        [ForeignKey("product")]
        public ICollection<Product> Products { get; set; }
    }
}
