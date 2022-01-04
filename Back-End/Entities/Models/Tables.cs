using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Tables", Schema = "dbo")]
    public class Tables
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Number { get; set; }

        [Required]
        public Boolean State { get; set; }

        [ForeignKey("FK_TableID")]
        public ICollection<TablesWaiters> TablesWaiters { get; set; }

        [ForeignKey("FK_TableID")]
        public ICollection<TablesOrders> TablesOrders { get; set; }
    }
}

