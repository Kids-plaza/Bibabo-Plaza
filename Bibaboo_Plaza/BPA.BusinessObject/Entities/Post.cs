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
        [Required]
        public string Title { get; set; } = string.Empty;
        [Column("content")]
        [Required]
        public string Content { get; set; } = string.Empty;

        [Column("staff_id")]
        [ForeignKey("Staff")]
        public Guid StaffId { get; set; }
        public virtual Account Staff { get; set; } = null!;
    }
}
