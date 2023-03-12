using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeTracker.Data;
using EmployeeTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTracker.Pages.Task
{
    public class CreateModel : PageModel
    {
        private readonly EmployeeTracker.Data.EmployeeTrackerContext _context;

        public List<EmployeeTracker.Models.Employee> Employees { get; private set; }
        public CreateModel(EmployeeTracker.Data.EmployeeTrackerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            await LoadinitialData();
            return Page();
        }

        [BindProperty]
        public EmployeeTracker.Models.Task Task { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            ModelState.Remove("Task.assignee.FullName");
            ModelState.Remove("Task.assignee.Email");
            ModelState.Remove("Task.assignee.Phone");

            if (!ModelState.IsValid)
            {
                await LoadinitialData();
                return Page();
            }

            EmployeeTracker.Models.Employee selectedEmpl = _context.Employee.Where(e => e.Id == Task.assignee.Id).FirstOrDefault();
            Task.assignee = selectedEmpl;
            _context.Task.Add(Task);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        private async System.Threading.Tasks.Task LoadinitialData()
        {
            Employees = _context.Employee.ToList();
        }
    }
}
