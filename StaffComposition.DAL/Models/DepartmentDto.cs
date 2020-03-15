using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace StaffComposition.DAL.Models
{
    [DataContract]
    public class DepartmentDto : IEntityDto
    {
        public Guid Id { get; set; }

        public string DepartmentName { get; set; }

        public ICollection<EmployeeDto> Employees { get; set; }
    }
}