using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace StaffComposition.DAL.Models
{
    [DataContract]
    public class EmployeeDto : IEntityDto
    {
        [DataMember]
        public Guid? Id { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public ICollection<DepartmentDto> Departments { get; set; }
    }
}