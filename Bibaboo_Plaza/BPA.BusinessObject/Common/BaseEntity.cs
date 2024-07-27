using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPA.BusinessObject.Common
{
    public abstract class BaseEntity
    {
        [Key]
        [Column("id")]
        public Guid id { get; set; } = Guid.NewGuid();
        [Column("created_on")]
        public DateTime created_on { get; set; } = DateTime.Now;
        [Column("is_deleted")]
        public bool is_deleted { get; set; } = false;
    }
}
