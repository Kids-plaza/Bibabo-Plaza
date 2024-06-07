using BPA.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.Domain.Entities
{
        [Table("brand")]
        public class Brand : BaseEntity
        {
            [Column("brand_name")]
            [Required]
            public string BrandName { get; set; } = string.Empty;

            [Column("brand_address")]
            [Required]
            public string BrandAddress { get; set; } = string.Empty;

            [Column("brand_phone")]
            [Required]
            public string BrandPhone { get; set; } = string.Empty;

            [Column("description")]
            [Required]
            public string Description { get; set; } = string.Empty;

            [Column("image_url")]
            [StringLength(500)]
            public string ImageUrl { get; set; } = string.Empty;

            [Column("product_id")]
            [ForeignKey("product")]
            public ICollection<Product> Products { get; set; }
    }
}
