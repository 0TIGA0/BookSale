using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookStore.Models
{
    public class OrderBook
    {
        [Key]
        public int OrderId { get; set; }
        [Key]
        public int BookId { get; set; }

        [Required]
        [Display(Name = "数量")]
        public int Count { get; set; }

        public Book Book { get; set; }
        public Order Order{ get; set; }
}
}
