using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Orders", Schema = "dbo")]
    public class Orders
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public float Total { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [ForeignKey("FK_OrderID")]
        public ICollection<OrdersFoods> OrdersFoods { get; set; }
      
        [ForeignKey("FK_OrderID")]
        public ICollection<TablesOrders> TablesOrders { get; set; }

    }
}
