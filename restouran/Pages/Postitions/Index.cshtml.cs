using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using restouran.Models;

namespace restouran.Pages.Postitions
{
    public class IndexModel : PageModel
    {
        private readonly restouran.Models.restContext _context;

        public IndexModel(restouran.Models.restContext context)
        {
            _context = context;
        }

        public IList<Position> Position { get;set; }

        public async Task OnGetAsync()
        {
            Position = await _context.Positions.ToListAsync();
        }
    }
}
