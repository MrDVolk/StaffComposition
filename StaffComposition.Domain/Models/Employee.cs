using System;

namespace StaffComposition.Data.Models
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
