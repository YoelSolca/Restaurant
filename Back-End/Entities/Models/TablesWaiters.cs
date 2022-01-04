using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("TablesWaiters", Schema = "dbo")]
    public class TablesWaiters
    {
        public int FK_TableID { get; set; }
        public int FK_WaiterID { get; set; }
        public Tables Tables { get; set; }
        public Waiters Waiters { get; set; }
    }
}
