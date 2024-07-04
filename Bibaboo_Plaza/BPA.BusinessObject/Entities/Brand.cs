using BPA.BusinessObject.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.BusinessObject.Entities
{
        [Table("Brand")]
        public class Brand : BaseEntity
        {
            [Column("brand_name")]
            public string BrandName { get; set; } = string.Empty;

            [Column("brand_address")]
            public string BrandAddress { get; set; } = string.Empty;

            [Column("brand_phone")]
            public string BrandPhone { get; set; } = string.Empty;

            [Column("description")]
            public string Description { get; set; } = string.Empty;
    }
}
