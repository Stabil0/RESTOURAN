using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using restouran.Models;

namespace restouran.Pages.Orders
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
        ViewData["CustomerId"] = new SelectList(_context.Employees, "EmployeeCode", "Adress");
        ViewData["DishCode1"] = new SelectList(_context.Menus, "DishCode", "DishName");
        ViewData["DishCode2"] = new SelectList(_context.Menus, "DishCode", "DishName");
        ViewData["DishCode3"] = new SelectList(_context.Menus, "DishCode", "DishName");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
