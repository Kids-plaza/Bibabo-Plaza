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
    [Table("Product")]
    public class Product : BaseEntity
    {
        [Column("product_name")]
        public string ProductName { get; set; } = string.Empty;

        [Column("price")]
        public double Price { get; set; } = 0;

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("img_url")]
        public string ImageUrl { get; set; } = string.Empty;

        [Column("quantity")]
        public int Quantity { get; set; } = 0;

        [Column("status")]
        [EnumDataType(typeof(ProductStatus))]
        public ProductStatus Status { get; set; }

        [Column("brand_id")]
        [ForeignKey("brand")]
        public Guid BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        [InverseProperty("Product")]
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
