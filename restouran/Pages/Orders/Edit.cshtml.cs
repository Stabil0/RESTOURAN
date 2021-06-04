using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using restouran.Models;

namespace restouran.Pages.Orders
{
    public class EditModel : PageModel
    {
        private readonly restouran.Models.restContext _context;

        public EditModel(restouran.Models.restContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.DishCode1Navigation)
                .Include(o => o.DishCode2Navigation)
                .Include(o => o.DishCode3Navigation).FirstOrDefaultAsync(m => m.CustomersName == id);

            if (Order == null)
            {
                return NotFound();
            }
           ViewData["CustomerId"] = new SelectList(_context.Employees, "EmployeeCode", "Adress");
           ViewData["DishCode1"] = new SelectList(_context.Menus, "DishCode", "DishName");
           ViewData["DishCode2"] = new SelectList(_context.Menus, "DishCode", "DishName");
           ViewData["DishCode3"] = new SelectList(_context.Menus, "DishCode", "DishName");
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

            _context.Attach(Order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.CustomersName))
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

        private bool OrderExists(string id)
        {
            return _context.Orders.Any(e => e.CustomersName == id);
        }
    }
}
