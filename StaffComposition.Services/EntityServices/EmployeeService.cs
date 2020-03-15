using System;

namespace StaffComposition.Services.EntityServices
{
    public class EmployeeService
    {
        private readonly Func<StaffDbContext> _contextFactory;

        public EmployeeService(Func<StaffDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}