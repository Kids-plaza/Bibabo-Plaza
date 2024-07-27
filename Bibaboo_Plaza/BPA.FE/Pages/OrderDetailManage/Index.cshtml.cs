using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace BPA.FE.Pages.OrderDetailManage
{
    public class IndexModel : PageModel
    {
        private readonly Test.Models.BPADatabaseContext _context;

        public IndexModel(Test.Models.BPADatabaseContext context)
        {
            _context = context;
        }

        public IList<OrderDetail> OrderDetail { get;set; } = default!;

        public async Task OnGetAsync()
        {
            OrderDetail = await _context.OrderDetails
                .Include(o => o.order)
                .Include(o => o.product).ToListAsync();
        }
    }
}
