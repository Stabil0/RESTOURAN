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
    public class DetailsModel : PageModel
    {
        private readonly restouran.Models.restContext _context;

        public DetailsModel(restouran.Models.restContext context)
        {
            _context = context;
        }

        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.DishCode1Navigation)
                .Include(o => o.DishCode2Navigation)
                .Include(o => o.DishCode3Navigation).FirstOrDefaultAsync(m => m.CustomersName == id);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
