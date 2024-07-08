using BPA.BusinessObject.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.BusinessObject.Dtos.Order
{
    public class OrderRequest
    {
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double TotalPrice { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int TotalQuantity { get; set; }

        [Required]
        public Guid CustomerId { get; set; }
    }
}
