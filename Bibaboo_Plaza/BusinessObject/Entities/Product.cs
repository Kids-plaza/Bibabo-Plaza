using BPA.Domain.Common;
using BPA.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.Domain.Entities
{
    [Table("Product")]
    public class Product : BaseEntity
    {
        [Column("product_name")]
        [Required]
        public string ProductName { get; set; } = string.Empty;

        [Column("price")]
        [Required]
        public double Price { get; set; } = 0;

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("img_url")]
        public string ImageUrl { get; set; } = string.Empty;

        [Column("quantity")]
        [Required]
        public int Quantity { get; set; } = 0;

        [Column("status")]
        [EnumDataType(typeof(ProductStatus))]
        public ProductStatus Status { get; set; } = ProductStatus.OutOfStock;

        [Column("type_id")]
        [ForeignKey("type")]
        public Guid TypeId { get; set; }
        public virtual ProductType Type { get; set; }

        [Column("brand_id")]
        [ForeignKey("brand")]
        public Guid BrandId { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
