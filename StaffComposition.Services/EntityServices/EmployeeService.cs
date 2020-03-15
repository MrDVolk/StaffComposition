using System;
using System.Collections.Generic;
using System.Linq;
using StaffComposition.DAL.Models;
using StaffComposition.Data.Models;
using StaffComposition.Services.MappingServices;

namespace StaffComposition.Services.EntityServices
{
    public class EmployeeService : EntityServiceBase<Employee, EmployeeDto>
    {
        public EmployeeService(Func<StaffDbContext> contextFactory, IMappingService<Employee, EmployeeDto> mappingService) : base(contextFactory, mappingService)
        {
        }

        protected override void ValidateCore(EmployeeDto dto, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(dto.FullName))
                errors.Add("Не указано имя сотрудника!");

            if (dto.Departments == null || !dto.Departments.Any())
                errors.Add("Сотрудник должен относиться хотя бы к одному департаменту!");
        }
    }
}