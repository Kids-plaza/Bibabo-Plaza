using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.BusinessObject.Dtos.Report
{
    public class ReportRequest
    {
        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        public Guid CustomerId { get; set; }
    }
}
