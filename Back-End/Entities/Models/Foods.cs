using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Foods", Schema = "dbo")]
    public class Foods
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Photo { get; set; }

        [Required]
        public Boolean State { get; set; }

        [ForeignKey("FK_FoodID")]
        public ICollection<OrdersFoods> OrdersFoods { get; set; }
    }
}
