using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeTracker.Data;
using EmployeeTracker.Models;

namespace EmployeeTracker.Pages.Task
{
    public class DeleteModel : PageModel
    {
        private readonly EmployeeTracker.Data.EmployeeTrackerContext _context;

        public DeleteModel(EmployeeTracker.Data.EmployeeTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
      public EmployeeTracker.Models.Task Task { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }

            var task = await _context.Task.FirstOrDefaultAsync(m => m.Id == id);

            if (task == null)
            {
                return NotFound();
            }
            else 
            {
                Task = task;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }
            var task = await _context.Task.FindAsync(id);

            if (task != null)
            {
                Task = task;
                _context.Task.Remove(Task);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
