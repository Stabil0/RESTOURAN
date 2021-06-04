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
    public class IndexModel : PageModel
    {
        private readonly restouran.Models.restContext _context;

        public IndexModel(restouran.Models.restContext context)
        {
            _context = context;
        }

        public IList<Menu> Menu { get;set; }

        public async Task OnGetAsync()
        {
            Menu = await _context.Menus
                .Include(m => m.IngredientCode1Navigation)
                .Include(m => m.IngredientCode2Navigation)
                .Include(m => m.IngredientCode3Navigation).ToListAsync();
        }
    }
}
