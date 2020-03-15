using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StaffComposition.DAL;
using StaffComposition.DAL.Models;

namespace StaffComposition.Web.Controllers
{
    [ApiController]
    public class DepartmentController : BaseApiController<DepartmentDto>
    {
        public DepartmentController(
            IService<DepartmentDto> service,
            ILogger<DepartmentController> logger
        ) : base(service, logger)
        {
        }
    }
}