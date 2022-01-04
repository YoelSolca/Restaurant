using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("TablesOrders", Schema = "dbo")]
    public class TablesOrders
    {
        public int FK_TableID { get; set; }

        public int FK_OrderID { get; set; }

        public Tables Tables { get; set; }
        public Orders Orders { get; set; }
    }
}
