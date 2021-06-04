using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using restouran.Models;

namespace restouran.Pages.Menus
{
    public class EditModel : PageModel
    {
        private readonly restouran.Models.restContext _context;

        public EditModel(restouran.Models.restContext context)
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
           ViewData["IngredientCode1"] = new SelectList(_context.Warehouses, "IngredientCode", "IngredientName");
           ViewData["IngredientCode2"] = new SelectList(_context.Warehouses, "IngredientCode", "IngredientName");
           ViewData["IngredientCode3"] = new SelectList(_context.Warehouses, "IngredientCode", "IngredientName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Menu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(Menu.DishCode))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MenuExists(long id)
        {
            return _context.Menus.Any(e => e.DishCode == id);
        }
    }
}
