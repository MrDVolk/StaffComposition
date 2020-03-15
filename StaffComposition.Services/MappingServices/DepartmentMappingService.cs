using System;
using System.Collections.Generic;
using System.Linq;
using StaffComposition.DAL.Models;
using StaffComposition.Data.Models;

namespace StaffComposition.Services.MappingServices
{
    public class DepartmentMappingService : IMappingService<Department, DepartmentDto>
    {
        public DepartmentDto Map(Department entity)
        {
            return new DepartmentDto
            {
                Id = entity.Id,
                DepartmentName = entity.DepartmentName,
                Employees = entity.EmployeeDepartments
                    .Where(x => !x.Employee.RecordDeleted.HasValue)
                    .Select(x => new EmployeeDto
                    {
                        Id = x.EmployeeId,
                        FullName = x.Employee.FullName
                    }).ToList()
            };
        }

        public Department Map(DepartmentDto entityDto)
        {
            var entity = new Department
            {
                Id = entityDto.Id ?? Guid.NewGuid(),
                DepartmentName = entityDto.DepartmentName
            };
            entity.EmployeeDepartments = GetEntityEmployeeDepartments(entityDto, entity);

            return entity;
        }

        public void Update(Department dest, DepartmentDto source)
        {
            dest.DepartmentName = source.DepartmentName;
            dest.EmployeeDepartments = GetEntityEmployeeDepartments(source, dest);
        }

        private static List<EmployeeToDepartment> GetEntityEmployeeDepartments(DepartmentDto entityDto, Department entity)
        {
            return new List<EmployeeToDepartment>(
                entityDto.Employees.Where(x => x.Id.HasValue)
                    .Select(x => new EmployeeToDepartment
                    {
                        Department = entity,
                        EmployeeId = x.Id.Value
                    })
            );
        }
    }
}