using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.BusinessObject.Dtos.Brand
{
    public class BrandRequest
    {
        [Required]
        [StringLength(50)]
        public string BrandName { get; set; } = string.Empty;
        [Required]
        [StringLength(200)]
        public string BrandAddress { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string BrandPhone { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
