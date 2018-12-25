using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.Pages.OrderBooks
{
    public class DetailsModel : PageModel
    {
        private readonly BookStore.Data.BookStoreContext _context;

        public DetailsModel(BookStore.Data.BookStoreContext context)
        {
            _context = context;
        }

        public OrderBook OrderBook { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderBook = await _context.OrderBook
                .Include(o => o.Book)
                .Include(o => o.Order).FirstOrDefaultAsync(m => m.OrderId == id);

            if (OrderBook == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
