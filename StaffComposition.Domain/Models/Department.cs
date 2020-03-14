using System;
using System.Collections.Generic;

namespace StaffComposition.Data.Models
{
    public class Department
    {
        public Guid Id { get; set; }

        public string DepartmentName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}