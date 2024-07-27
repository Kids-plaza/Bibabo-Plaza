using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test.Models;

namespace BPA.FE.Pages.OrderDetailManage
{
    public class CreateModel : PageModel
    {
        private readonly Test.Models.BPADatabaseContext _context;

        public CreateModel(Test.Models.BPADatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["order_id"] = new SelectList(_context.Orders, "id", "id");
        ViewData["product_id"] = new SelectList(_context.Products, "id", "description");
            return Page();
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OrderDetails.Add(OrderDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
