using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using restouran.Models;

namespace restouran.Pages.FilReq.Requests.PersonnelDepartment
{
    public class PersonnelDepartmentModel : PageModel
    {
        private readonly restouran.Models.restContext _context;

        public PersonnelDepartmentModel(restouran.Models.restContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get; set; }
        public IList<Position> Position { get; set; }
        public async Task OnGetAsync()
        {
            Employee = await _context.Employees.ToListAsync();
            Position = await _context.Positions.ToListAsync();
        }
    }
}
