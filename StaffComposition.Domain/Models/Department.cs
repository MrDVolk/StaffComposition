using System;
using System.Collections.Generic;

namespace StaffComposition.Data.Models
{
    public class Department: IEntity
    {
        public Guid Id { get; set; }

        public string DepartmentName { get; set; }

        public ICollection<EmployeeToDepartment> EmployeeDepartments { get; set; }

        public DateTime RecordCreated { get; set; }

        public DateTime? RecordModified { get; set; }

        public DateTime? RecordDeleted { get; set; }
    }
}