using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPA.BusinessObject.Common
{
    public abstract class BaseEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Column("created_on")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
