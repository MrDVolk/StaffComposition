using Autofac;
using StaffComposition.DAL;
using StaffComposition.DAL.Models;
using StaffComposition.Data.Models;
using StaffComposition.Services.EntityServices;
using StaffComposition.Services.MappingServices;

namespace StaffComposition.Services
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeeService>().As<IService<EmployeeDto>>();
            builder.RegisterType<DepartmentService>().As<IService<DepartmentDto>>();

            builder.RegisterType<EmployeeMappingService>().As<IMappingService<Employee, EmployeeDto>>();
            builder.RegisterType<DepartmentMappingService>().As<IMappingService<Department, DepartmentDto>>();
        }
    }
}