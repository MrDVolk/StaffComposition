using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StaffComposition.Data.Models;
using StaffComposition.Services;

namespace StaffComposition.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new DbContextOptionsBuilder<StaffDbContext>();
            builder.UseInMemoryDatabase("StaffDb");
            var context = new StaffDbContext(builder.Options);

            var department = new Department
            {
                Id = Guid.NewGuid(),
                DepartmentName = "Отдел кадров"
            };
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FullName = "Иванов И.И.",
                Department = department
            };

            context.Employees.Add(employee);
            context.SaveChanges();

            var departmentCount = context.Departments.Count();
        }
    }
}
