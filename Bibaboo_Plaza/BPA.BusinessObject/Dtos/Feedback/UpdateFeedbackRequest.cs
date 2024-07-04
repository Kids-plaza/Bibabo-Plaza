using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.BusinessObject.Dtos.Feedback
{
    public class UpdateFeedbackRequest
    {
        [Required]
        public string Content { get; set; } = string.Empty;
    }
}
