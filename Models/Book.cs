using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "书籍名称")]
        [StringLength(300)]
        public string BookName { get; set; }
        
        [Display(Name = "出版社")]
        [StringLength(300)]
        public string Publisher{ get; set; }

        [Required]
        [Display(Name = "价格")]
        public float Price { get; set; }
        
        [Display(Name = "封面")]
        [StringLength(300)]
        public string Img { get; set; }

        [Display(Name = "作者")]
        [StringLength(300)]
        public string Author { get; set; }

        [Display(Name ="类型")]
        [StringLength (30)]
        public string Type { get; set; }

        public ICollection<Cart> Carts { get; set; }
        public ICollection<OrderBook> OrderBooks { get; set; }
    }
}
