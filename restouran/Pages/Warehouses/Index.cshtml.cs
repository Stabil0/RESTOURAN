using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using restouran.Models;

namespace restouran.Pages.Warehouses
{
    public class IndexModel : PageModel
    {
        private readonly restouran.Models.restContext _context;

        public IndexModel(restouran.Models.restContext context)
        {
            _context = context;
        }

        public IList<Warehouse> Warehouse { get;set; }

        public async Task OnGetAsync()
        {
            Warehouse = await _context.Warehouses.ToListAsync();
        }
    }
}
