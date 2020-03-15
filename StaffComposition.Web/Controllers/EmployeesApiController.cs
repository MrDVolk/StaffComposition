using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StaffComposition.DAL;
using StaffComposition.DAL.Models;

namespace StaffComposition.Web.Controllers
{
    [ApiController]
    public class EmployeesController : BaseApiController<EmployeeDto>
    {
        public EmployeesController(
            IService<EmployeeDto> service,
            ILogger<EmployeesController> logger
            ) : base(service, logger)
        {
        }
    }
}