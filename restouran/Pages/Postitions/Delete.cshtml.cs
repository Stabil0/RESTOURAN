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
    public class DeleteModel : PageModel
    {
        private readonly restouran.Models.restContext _context;

        public DeleteModel(restouran.Models.restContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Position Position { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Position = await _context.Positions.FirstOrDefaultAsync(m => m.PositionId == id);

            if (Position == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Position = await _context.Positions.FindAsync(id);

            if (Position != null)
            {
                _context.Positions.Remove(Position);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
