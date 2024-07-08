using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.BusinessObject.Dtos.Order
{
    public class UpdateOrderDetailRequest
    {
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double Price { get; set; }
        [Required]
        public Guid ProductId { get; set; }
    }
}
