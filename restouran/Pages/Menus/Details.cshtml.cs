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
    public class DetailsModel : PageModel
    {
        private readonly restouran.Models.restContext _context;

        public DetailsModel(restouran.Models.restContext context)
        {
            _context = context;
        }

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
    }
}
