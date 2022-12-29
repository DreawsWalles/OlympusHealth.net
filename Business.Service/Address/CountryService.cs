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
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private static void CheckEntity(CountryDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Name == null || entity.Name.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Name));
        }

        public CountryDto Create(CountryDto entity)
        {
            CheckEntity(entity);
            Country country = _mapper.Map<Country>(entity);
            _countryRepository.Create(country);
            return _mapper.Map<CountryDto>(country);
        }

        public ICollection<CountryDto> GetByMatchName(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if(name.Trim() == "")
                return new List<CountryDto>();
            return _mapper.Map<List<Country>, ICollection<CountryDto>>(_countryRepository.Query().Where(e => e.Name.Trim().ToLower().Contains(name.Trim().ToLower())).ToList());
        }
        public ICollection<CountryDto> GetAll()
        {
            return _mapper.Map<List<Country>, ICollection<CountryDto>>(_countryRepository.Query());
        }

        public CountryDto? GetById(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(Id));
            return _mapper.Map<CountryDto>(_countryRepository.Query().FirstOrDefault(x => x.Id == Id));
        }

        public void Remove(CountryDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            Country country = _mapper.Map<Country>(entity);
            _countryRepository.Delete(country);
        }

        public CountryDto Update(CountryDto updateEntity)
        {
            CheckEntity(updateEntity);
            if (updateEntity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(updateEntity.Id));
            Country country = _mapper.Map<Country>(updateEntity);
            _countryRepository.Update(country);
            return _mapper.Map<CountryDto>(country);
        }

        public async Task<CountryDto> CreateAsync(CountryDto entity)
        {
            CheckEntity(entity);
            Country country = _mapper.Map<Country>(entity);
            await _countryRepository.CreateAsync(country);
            return _mapper.Map<CountryDto>(country);
        }

        public async Task<CountryDto> UpdateAsync(CountryDto updateEntity)
        {
            CheckEntity(updateEntity);
            if(updateEntity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(updateEntity.Id));
            Country country = _mapper.Map<Country>(updateEntity);
            await _countryRepository.CreateOrUpdateAsync(country);
            return _mapper.Map<CountryDto>(country);
        }

        public async Task<ICollection<CountryDto>> GetByMatchNameAsync(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            var list = await _countryRepository.QueryAsync();
            var result = new List<Country>();
            string s = name.Trim().ToLower();
            Parallel.ForEach(list, element =>
            {
                if (element.Name.Trim().ToLower().Contains(s))
                    result.Add(element);
            });
            return _mapper.Map<List<Country>, ICollection<CountryDto>>(result.ToList());
        }

        public async Task<ICollection<CountryDto>> GetAllAsync()
        {
            return _mapper.Map<List<Country>, ICollection<CountryDto>>( await _countryRepository.QueryAsync());
        }

        public async Task<CountryDto?> GetByIdAsync(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(Id));
            var list = await _countryRepository.QueryAsync();
            return _mapper.Map<CountryDto>(list.FirstOrDefault(x => x.Id == Id));
        }
    }
}
