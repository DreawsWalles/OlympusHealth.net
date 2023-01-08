using AutoMapper.Internal;
using Business.Service.MedicModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/RoleMedic")]
    [ApiController]
    public class RoleMedicController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleMedicController(IRoleService roleService)
        {
            _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
        }

        [HttpPost, Route("GetRole")]
        public async Task<ActionResult<Guid>> GetRole(string name)
        {
            if (name == null)
                return BadRequest(name);
            return await _roleService.GetByNameAsync(name);   
        }
    }
}
