using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CartId{ get; set; }
        [Display(Name ="用户")]
        public string UserId { get; set; }
        [Display(Name ="书籍")]
        public int BookId { get; set; }
        [Display(Name ="数量")]
        public int Count { get; set; }

        public Book  Book { get; set; }
        public User User { get; set; }
    }
}
