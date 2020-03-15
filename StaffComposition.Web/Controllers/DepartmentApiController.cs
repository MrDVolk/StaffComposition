using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StaffComposition.DAL;
using StaffComposition.DAL.Models;

namespace StaffComposition.Web.Controllers
{
    [ApiController]
    public class DepartmentsController : BaseApiController<DepartmentDto>
    {
        public DepartmentsController(
            IService<DepartmentDto> service,
            ILogger<DepartmentsController> logger
        ) : base(service, logger)
        {
        }
    }
}