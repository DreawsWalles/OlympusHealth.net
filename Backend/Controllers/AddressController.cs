using Business.Interop.Address;
using Business.Service.Address;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/Address")]
    [ApiController]
    public class AddressController : ControllerBase 
    {
        private readonly ICountryService _countryService;
        private readonly IRegionService _regionService;
        private readonly ICityService _cityService;
        private readonly IStreetService _streetService;
        public AddressController(ICountryService countryService, IRegionService regionService, ICityService cityService, IStreetService streetService)
        {
            _countryService = countryService;
            _regionService = regionService;
            _cityService = cityService;
            _streetService = streetService;
        }

        [HttpPost, Route("Country")]
        public async Task<ActionResult<List<CountryDto>>> GetCountrys(string name)
        {
            if (name == null)
                return BadRequest("Переданы некореектные параметры");
            var list = await _countryService.GetByMatchNameAsync(name);
           return list.ToList();
        }

        [HttpPost, Route("Region")]
        public async Task<ActionResult<List<RegionDto>>> GetRegions(string name, string country)
        {
            if (name == null || country == null)
                return BadRequest("Переданы некорректные параметры");
            var list = await _regionService.GetByMatchNameAsync(name, country);
            return list.ToList();
        }

        [HttpPost, Route("City")]
        public async Task<ActionResult<List<CityDto>>> GetCities(string name, string country, string region)
        {
            if (name == null || country == null || region == null)
                return BadRequest("Переданы некорректные параметры");
            var list = await _cityService.GetByMatchNameAsync(name, country, region);
            return list.ToList();
        }

        [HttpPost, Route("Street")]
        public async Task<ActionResult<List<StreetDto>>> GetStreets(string name, string country, string region, string city)
        {
            if (name == null || country == null || region == null || city == null)
                return BadRequest("Переданы некорректные параментры");
            var list = await _streetService.GetByMatchNameAsync(name, country, region, city);
            return list.ToList();
        }

        [HttpPost, Route("House")]
        public async Task<ActionResult<List<string>>> GetHouses(string name, string country, string region, string city, string street)
        {
            if (name == null || country == null || region == null || city == null || street == null)
                return BadRequest("Переданы некорректные параметры");
            var list = await _streetService.GetHousesMatchNameAsync(name, country, region, city, street);
            return list.ToList();
        }

        [HttpGet, Route("Country")]
        public async Task<ActionResult<List<CountryDto>>> GetlAllCountries()
        {
            var list = await _countryService.GetAllAsync();
            return list.ToList();
        }
    }
}
