using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using restouran.Models;

namespace restouran.Pages.FilReq
{
    public class IndexModel : PageModel
    {

        private readonly restouran.Models.restContext _context;

        public IndexModel(restouran.Models.restContext context)
        {
            _context = context;
        }
        public List<SelectListItem> Position { get; set; }
        public IActionResult OnGet()
        {
            Position = _context.Positions.Select(p =>
                new SelectListItem
                {
                    Value = p.PositionId.ToString(),
                    Text = p.JobName
                }).ToList();
            return Page();
        }

    }
}
