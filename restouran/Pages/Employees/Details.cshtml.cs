using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using restouran.Models;

namespace restouran.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly restouran.Models.restContext _context;

        public DetailsModel(restouran.Models.restContext context)
        {
            _context = context;
        }

        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employees
                .Include(e => e.Position).FirstOrDefaultAsync(m => m.EmployeeCode == id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
