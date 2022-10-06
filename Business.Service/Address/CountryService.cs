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
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private IMapper _mapper;

        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public CountryDto Create(CountryDto entity)
        {
            Country country = _mapper.Map<Country>(entity);
            _countryRepository.Create(country);
            return _mapper.Map<CountryDto>(country);
        }

        public IEnumerable<CountryDto> GetAll()
        {
            return _mapper.Map<List<Country>, IEnumerable<CountryDto>>(_countryRepository.Query());
        }

        public CountryDto? GetById(Guid Id)
        {
            return _mapper.Map<CountryDto>(_countryRepository.Query().FirstOrDefault(x => x.Id == Id)); //написать запрос
        }

        public void Remove(CountryDto entity)
        {
            Country country = _mapper.Map<Country>(entity);
            _countryRepository.Delete(country);
        }

        public CountryDto Update(CountryDto updateEntity)
        {
            Country country = _mapper.Map<Country>(updateEntity);
            _countryRepository.Update(country);
            return _mapper.Map<CountryDto>(country);
        }
    }
}
