﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly EmployeeTracker.Data.EmployeeTrackerContext _context;

        public IndexModel(EmployeeTracker.Data.EmployeeTrackerContext context)
        {
            _context = context;
        }

        public IList<EmployeeTracker.Models.Employee> Employee { get;set; } = default!;

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            if (_context.Employee != null)
            {
                Employee = await _context.Employee.ToListAsync();
            }
        }
    }
}
