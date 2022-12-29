using AutoMapper;
using Business.Enties.Address;
using Business.Interop.Address;
using Business.Repository.DataRepository.Address;
using Business.Service.Address;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Address
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        
        private static void CheckEntity(CityDto entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));
            if (entity.Name == null || entity.Name.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Name));
            if (entity.RegionId.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.RegionId));
        }

        public CityService(ICityRepository cityRepository, IMapper mapper, IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository ?? throw new ArgumentNullException(nameof(regionRepository));
            _cityRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public CityDto Create(CityDto entity)
        {
            CheckEntity(entity);
            City city = _mapper.Map<City>(entity);
            _cityRepository.Create(city);
            return _mapper.Map<CityDto>(city);
        }

        public ICollection<CityDto> GetAll()
        {
            return _mapper.Map<List<City>, ICollection<CityDto>>(_cityRepository.Query());
        }

        public CityDto? GetById(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(Id));
            return _mapper.Map<CityDto>(_cityRepository.Query().FirstOrDefault(x => x.Id == Id)); 
        }

        public void Remove(CityDto entity)
        {
            CheckEntity(entity);
            if(entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity));
            City city = _mapper.Map<City>(entity);
            _cityRepository.Delete(city);
        }

        public CityDto Update(CityDto updateEntity)
        {
            CheckEntity(updateEntity);
            if (updateEntity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(updateEntity));
            City city = _mapper.Map<City>(updateEntity);
            _cityRepository.Update(city);
            return _mapper.Map<CityDto>(city);
        }

        public ICollection<CityDto> GetByMatchName(string name, string country, string region)
        {
            if(name == null) 
                throw new ArgumentNullException(nameof(name));
            if (region == null)
                throw new ArgumentNullException(nameof(region));
            if (country == null)
                throw new ArgumentNullException(nameof(country));
            if (name.Trim() == "" || region.Trim() == "" || country.Trim() == "")
                return new List<CityDto>();
            var reg = _regionRepository.Query().FirstOrDefault(e => e.Country.Name == country && e.Name == region);
            if(reg == null)
                return new List<CityDto>();
            string s = name.Trim().ToLower();
            var result = reg.Citys.Where(e => e.Name.Trim().ToLower().Contains(s));
            return _mapper.Map<List<City>, ICollection<CityDto>>(result.ToList());
        }

        public async Task<CityDto> CreateAsync(CityDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            City city = _mapper.Map<City>(entity);
            await _cityRepository.CreateAsync(city);
            return _mapper.Map<CityDto>(city);
        }

        public async Task<CityDto> UpdateAsync(CityDto updateEntity)
        {
            CheckEntity(updateEntity);
            if (updateEntity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(updateEntity));
            City city = _mapper.Map<City>(updateEntity);
            await _cityRepository.CreateAsync(city);
            return _mapper.Map<CityDto>(city);
        }

        public async Task<ICollection<CityDto>> GetByMatchNameAsync(string name, string country, string region)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (region == null)
                throw new ArgumentNullException(nameof(region));
            if (country == null)
                throw new ArgumentNullException(nameof(country));
            if (name.Trim() == "" || region.Trim() == "" || country.Trim() == "")
                return new List<CityDto>();
            var regions = await _regionRepository.QueryAsync();
            var reg = regions.FirstOrDefault(e => e.Country.Name == country && e.Name == region);
            if (reg == null)
                return new List<CityDto>();
            var result = new List<City>();
            Parallel.ForEach(reg.Citys, element =>
            {
                if (element.Name.Trim().Contains(name.Trim().ToLower()))
                    result.Add(element);
            });
            return _mapper.Map<List<City>, ICollection<CityDto>>(result.ToList());
        }

        public async Task<ICollection<CityDto>> GetAllAsync()
        {
            return _mapper.Map<List<City>, ICollection<CityDto>>(await _cityRepository.QueryAsync());
        }

        public async Task<CityDto?> GetByIdAsync(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(Id));
            var result = await _cityRepository.QueryAsync();
            return _mapper.Map<CityDto>(result.FirstOrDefault(x => x.Id == Id));
        }
    }
}
