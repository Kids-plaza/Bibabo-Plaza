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
    [Table("Type")]
    public class ProductType : BaseEntity
    {
        [Column("type_name")]
        [Required]
        public string TypeName { get; set; } = string.Empty;

        [Column("description")]
        [Required]
        public string Description { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; }
    }
}
