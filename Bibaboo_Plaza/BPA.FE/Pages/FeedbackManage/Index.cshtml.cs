using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace BPA.FE.Pages.FeedbackManage
{
    public class IndexModel : PageModel
    {
        private readonly Test.Models.BPADatabaseContext _context;

        public IndexModel(Test.Models.BPADatabaseContext context)
        {
            _context = context;
        }

        public IList<Feedback> Feedback { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Feedback = await _context.Feedbacks
                .Include(f => f.customer)
                .Include(f => f.product).ToListAsync();
        }
    }
}
