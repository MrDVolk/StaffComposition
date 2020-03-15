using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StaffComposition.DAL;
using StaffComposition.DAL.Models;
using StaffComposition.Data.Models;
using StaffComposition.Services.MappingServices;

namespace StaffComposition.Services.EntityServices
{
    public class DepartmentService : EntityServiceBase<Department, DepartmentDto>
    {
        private readonly IService<EmployeeDto> _employeeService;

        public DepartmentService(
            Func<StaffDbContext> contextFactory,
            IMappingService<Department, DepartmentDto> mappingService,
            IService<EmployeeDto> employeeService)
            : base(contextFactory, mappingService)
        {
            _employeeService = employeeService;
        }

        public override async Task Delete(Guid id)
        {
            using (var db = _contextFactory())
            {
                var query =
                    from e in db.Set<Department>()
                    where !e.RecordDeleted.HasValue
                    where e.Id == id
                    select e;

                LoadDependencies(query);
                var entity = await query.SingleOrDefaultAsync();
                if (entity == null)
                    throw new ArgumentException($"Сущность с Id={id} не найдена!");

                entity.RecordDeleted = DateTime.Now;
                await db.SaveChangesAsync();

                var tasks = entity.EmployeeDepartments.Select(x => _employeeService.Delete(x.EmployeeId)).ToArray();
                Task.WaitAll(tasks);
            }
        }

        protected override void ValidateCore(DepartmentDto dto, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(dto.DepartmentName))
                errors.Add("Не указано название отдела!");
        }

        protected override IQueryable<Department> LoadDependencies(IQueryable<Department> query)
        {
            query.Select(x => x.EmployeeDepartments).Load();
            query.SelectMany(x => x.EmployeeDepartments.Select(y => y.Department)).Load();
            query.SelectMany(x => x.EmployeeDepartments.Select(y => y.Employee)).Load();

            return base.LoadDependencies(query);
        }
    }
}