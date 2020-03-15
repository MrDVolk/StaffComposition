using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffComposition.Data.Models
{
    public class EmployeeToDepartment
    {
        public Guid EmployeeId { get; set; }

        public Guid DepartmentId { get; set; }


        public Employee Employee { get; set; }

        public Department Department { get; set; }
    }
}