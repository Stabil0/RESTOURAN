using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using restouran.Models;

namespace restouran.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly restouran.Models.restContext _context;

        public CreateModel(restouran.Models.restContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PositionId"] = new SelectList(_context.Positions, "PositionId", "JobName");
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
