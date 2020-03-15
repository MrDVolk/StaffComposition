using System;
using System.Collections.Generic;
using System.Linq;
using StaffComposition.DAL.Models;
using StaffComposition.Data.Models;

namespace StaffComposition.Services.MappingServices
{
    public class EmployeeMappingService : IMappingService<Employee, EmployeeDto>
    {
        public EmployeeDto Map(Employee entity)
        {
            return new EmployeeDto
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Departments = entity.EmployeeDepartments
                    .Where(x => !x.Department.RecordDeleted.HasValue)
                    .Select(x => new DepartmentDto
                    {
                        Id = x.DepartmentId,
                        DepartmentName = x.Department.DepartmentName
                    }).ToList()
            };
        }

        public Employee Map(EmployeeDto entityDto)
        {
            var entity = new Employee
            {
                Id = entityDto.Id ?? Guid.NewGuid(),
                FullName = entityDto.FullName
            };
            entity.EmployeeDepartments = GetEntityEmployeeDepartments(entityDto, entity);

            return entity;
        }

        public void Update(Employee dest, EmployeeDto source)
        {
            dest.FullName = source.FullName;
            dest.EmployeeDepartments = GetEntityEmployeeDepartments(source, dest);
        }

        private static List<EmployeeToDepartment> GetEntityEmployeeDepartments(EmployeeDto entityDto, Employee entity)
        {
            return new List<EmployeeToDepartment>(
                entityDto.Departments
                    .Where(x => x.Id.HasValue)
                    .Select(x => new EmployeeToDepartment
                    {
                        Employee = entity,
                        DepartmentId = x.Id.Value
                    })
            );
        }
    }
}