using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using restouran.Models;

namespace restouran.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly restouran.Models.restContext _context;

        public IndexModel(restouran.Models.restContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.DishCode1Navigation)
                .Include(o => o.DishCode2Navigation)
                .Include(o => o.DishCode3Navigation).ToListAsync();
        }
    }
}
