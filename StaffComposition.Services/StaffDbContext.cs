using System;
using Microsoft.EntityFrameworkCore;
using StaffComposition.Data.Models;

namespace StaffComposition.Services
{
    public class StaffDbContext : DbContext
    {
        public StaffDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeToDepartment>().HasKey(x => new {x.EmployeeId, x.DepartmentId});
        }
    }
}
