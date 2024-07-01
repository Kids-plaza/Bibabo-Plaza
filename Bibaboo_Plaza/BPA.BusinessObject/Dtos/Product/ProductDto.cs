using BPA.BusinessObject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.BusinessObject.Dtos.Product
{
    public class ProductDto
    {
        public string ProductName { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public int TotalQuantity { get; set; } = 0;
        public ProductStatus Status { get; set; } = ProductStatus.ComingSoon;
    }
}
