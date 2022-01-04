using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Waiters", Schema = "dbo")]
    public class Waiters
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("FK_WaiterID")]
        public ICollection<TablesWaiters> TablesWaiters { get; set; }
    }
}
