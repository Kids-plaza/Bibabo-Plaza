using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.BusinessObject.Dtos.Feedback
{
    public class FeedBackRequest
    {
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
    }
}
