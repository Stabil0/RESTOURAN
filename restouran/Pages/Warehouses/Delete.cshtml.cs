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
    public class DeleteModel : PageModel
    {
        private readonly restouran.Models.restContext _context;

        public DeleteModel(restouran.Models.restContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Warehouse Warehouse { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Warehouse = await _context.Warehouses.FirstOrDefaultAsync(m => m.IngredientCode == id);

            if (Warehouse == null)
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

            Warehouse = await _context.Warehouses.FindAsync(id);

            if (Warehouse != null)
            {
                _context.Warehouses.Remove(Warehouse);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
