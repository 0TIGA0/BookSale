using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId { get; set; }
        [Display(Name = "用户")]
        public string UserId { get; set; }
        //[Display(Name = "书籍")]
        //public int BookId { get; set; }

        //[Required]
        //[Display(Name = "数量")]
        //public int Count { get; set; }

        [Timestamp]
        [Display(Name = "创建时间")]
        public DateTime Time { get; set; }

        public ICollection<OrderBook> OrderBooks { get; set; }
        public User User { get; set; }
    }
}
