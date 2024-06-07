using BPA.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.Domain.Entities
{
    [Table("Report")]
    public class Report : BaseEntity
    {
        [Column("content")]
        [Required]
        public string Content { get; set; } = string.Empty;

        [Column("account_id")]
        [ForeignKey("account")]
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
