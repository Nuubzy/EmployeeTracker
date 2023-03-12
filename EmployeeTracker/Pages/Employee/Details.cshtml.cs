using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeTracker.Data;
using EmployeeTracker.Models;

namespace EmployeeTracker.Pages.Employee
{
    public class DetailsModel : PageModel
    {
        private readonly EmployeeTracker.Data.EmployeeTrackerContext _context;

        public DetailsModel(EmployeeTracker.Data.EmployeeTrackerContext context)
        {
            _context = context;
        }

      public EmployeeTracker.Models.Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            else 
            {
                Employee = employee;
            }
            return Page();
        }
    }
}
