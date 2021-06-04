using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using restouran.Models;

namespace restouran.Pages.Menus
{
    public class DeleteModel : PageModel
    {
        private readonly restouran.Models.restContext _context;

        public DeleteModel(restouran.Models.restContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Menu Menu { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Menu = await _context.Menus
                .Include(m => m.IngredientCode1Navigation)
                .Include(m => m.IngredientCode2Navigation)
                .Include(m => m.IngredientCode3Navigation).FirstOrDefaultAsync(m => m.DishCode == id);

            if (Menu == null)
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

            Menu = await _context.Menus.FindAsync(id);

            if (Menu != null)
            {
                _context.Menus.Remove(Menu);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
