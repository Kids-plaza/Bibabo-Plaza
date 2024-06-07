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
    [Table("post")]
    public class Post : BaseEntity
    {
        [Column("title")]
        [Required]
        public string Title { get; set; } = string.Empty;
        [Column("content")]
        [Required]
        public string Content { get; set; } = string.Empty;

        [Column("account_id")]
        [ForeignKey("account")]
        public virtual Account Account { get; set; }
    }
}
