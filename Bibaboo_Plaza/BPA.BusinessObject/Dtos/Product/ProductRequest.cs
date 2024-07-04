using BPA.BusinessObject.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.BusinessObject.Dtos.Product
{
    public class ProductRequest
    {
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double Price { get; set; } = 0;
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; } = 0;
        [Required]
        public Guid BrandId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
