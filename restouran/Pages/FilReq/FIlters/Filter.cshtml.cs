using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using restouran.Models;
using Microsoft.EntityFrameworkCore;

namespace restouran.Pages.FilReq.FIlters
{
    public class FilterModel : PageModel
    {
        private readonly restouran.Models.restContext _context;

        public FilterModel(restouran.Models.restContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get; set; }
        public Position Position { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Position = _context.Positions.First(m => m.PositionId == id);

            if (Position == null)
            {
                return NotFound();
            }
            Employee = await _context.Employees
                .Include(e => e.Position).Where(m => m.PositionId == Position.PositionId).ToListAsync();
            return Page();
        }
    }
}
