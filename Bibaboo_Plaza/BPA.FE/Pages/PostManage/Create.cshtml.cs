using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test.Models;

namespace BPA.FE.Pages.PostManage
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
        ViewData["staff_id"] = new SelectList(_context.Accounts, "id", "address");
            return Page();
        }

        [BindProperty]
        public Post Post { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
