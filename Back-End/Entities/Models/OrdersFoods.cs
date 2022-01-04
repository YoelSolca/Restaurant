using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("OrdersFoods", Schema = "dbo")]
    public class OrdersFoods
    {
        public int FK_OrderID { get; set; }
        public int FK_FoodID { get; set; }

        public Orders Orders { get; set; }
        public Foods Foods { get; set; }

    }
}

