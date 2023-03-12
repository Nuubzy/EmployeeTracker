using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeTracker.Models;

namespace EmployeeTracker.Data
{
    public class EmployeeTrackerContext : DbContext
    {
        public EmployeeTrackerContext (DbContextOptions<EmployeeTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeTracker.Models.Employee> Employee { get; set; } = default!;

        public DbSet<EmployeeTracker.Models.Task> Task { get; set; }
    }
}
