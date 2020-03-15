using System;
using System.Collections.Generic;

namespace StaffComposition.Data.Models
{
    public class Employee : IEntity
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public ICollection<EmployeeToDepartment> EmployeeDepartments { get; set; }

        public DateTime RecordCreated { get; set; }

        public DateTime? RecordModified { get; set; }

        public DateTime? RecordDeleted { get; set; }
    }
}
