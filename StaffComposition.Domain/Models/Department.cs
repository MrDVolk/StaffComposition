using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffComposition.Data.Models
{
    public class Department: IEntity
    {
        public Guid Id { get; set; }

        public string DepartmentName { get; set; }

        public ICollection<EmployeeToDepartment> EmployeeDepartments { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime RecordCreated { get; set; }

        public DateTime? RecordModified { get; set; }

        public DateTime? RecordDeleted { get; set; }
    }
}