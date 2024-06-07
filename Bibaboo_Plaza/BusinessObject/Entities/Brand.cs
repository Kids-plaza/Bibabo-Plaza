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
        [Table("Brand")]
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
            public string ImageUrl { get; set; } = string.Empty;
            public virtual Product Product { get; set; }
    }
}
