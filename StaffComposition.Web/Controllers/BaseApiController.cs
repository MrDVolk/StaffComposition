using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StaffComposition.DAL;
using StaffComposition.DAL.Models;

namespace StaffComposition.Web.Controllers
{
    [Route("[controller]")]
    public abstract class BaseApiController<TEntityDto> : ControllerBase
        where TEntityDto: class, IEntityDto
    {
        private readonly IService<TEntityDto> _service;
        private readonly ILogger<BaseApiController<TEntityDto>> _logger;

        protected BaseApiController(
            IService<TEntityDto> service,
            ILogger<BaseApiController<TEntityDto>> logger
        )
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetList()
        {
            var result = await _service.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _service.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TEntityDto dto)
        {
            var result = await _service.Create(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(TEntityDto dto)
        {
            var result = await _service.Create(dto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}