using BPA.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.Domain.Entities
{
    public class Report : BaseEntity
    {
        public string Content { get; set; } = string.Empty;

        [Column("account_id")]
        [ForeignKey("account")]
        public virtual Account Account { get; set; }
    }
}
