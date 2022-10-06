using AutoMapper;
using Business.Enties.Address;
using Business.Interop.Address;
using Business.Repository.DataRepository.Address;
using Business.Service.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Address
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public CityDto Create(CityDto entity)
        {
            City city = _mapper.Map<City>(entity);
            _cityRepository.Create(city);
            return _mapper.Map<CityDto>(city);
        }

        public IEnumerable<CityDto> GetAll()
        {
            return _mapper.Map<List<City>, IEnumerable<CityDto>>(_cityRepository.Query());
        }

        public CityDto? GetById(Guid Id)
        {
            return _mapper.Map<CityDto>(_cityRepository.Query().FirstOrDefault(x => x.Id == Id)); //Написать запрос
        }

        public void Remove(CityDto entity)
        {
            City city = _mapper.Map<City>(entity);
            _cityRepository.Delete(city);
        }

        public CityDto Update(CityDto updateEntity)
        {
            City city = _mapper.Map<City>(updateEntity);
            _cityRepository.Update(city);
            return _mapper.Map<CityDto>(city);
        }
    }
}
