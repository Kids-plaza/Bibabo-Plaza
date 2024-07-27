using BPA.BusinessObject.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.BusinessObject.Entities
{
    [Table("Post")]
    public class Post : BaseEntity
    {
        [Column("title")]
        public string title { get; set; } = string.Empty;
        [Column("content")]
        public string content { get; set; } = string.Empty;
        [Column("staff_id")]
        [ForeignKey("staff")]
        public Guid staff_id { get; set; }
        public virtual Account staff { get; set; } = null!;
    }
}
