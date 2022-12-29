using Business.Interop;
using Business.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/Gender")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderService _genderService;

        public GenderController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        [HttpGet, Route("GetAll")]
        public ActionResult<List<GenderDto>> GetAll()
        {
            return _genderService.GetAll().ToList();
        }

        [HttpPost, Route("GetById")]
        public ActionResult<GenderDto> GetById(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                return BadRequest("Переданы некорректные данные");
            GenderDto? result = _genderService.GetById(id);
            return result == null ? NotFound(id) : result;
        }
    }
}
