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
    public class StreetService : IStreetService
    {
        private readonly IStreetRepository _streetRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public StreetService(IStreetRepository streetRepository, IMapper mapper, ICityRepository cityRepository, IRegionRepository regionRepository)
        {
            _streetRepository = streetRepository ?? throw new ArgumentNullException(nameof(streetRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _cityRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
            _regionRepository = regionRepository ?? throw new ArgumentNullException(nameof(regionRepository));
        }

        private static void CheckEntity(StreetDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Name == null || entity.Name.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Name));
            if (entity.CityId.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.CityId));
        }

        public StreetDto Create(StreetDto entity)
        {
            CheckEntity(entity);
            Street street = _mapper.Map<Street>(entity);
            _streetRepository.Create(street);
            return _mapper.Map<StreetDto>(street);
        }

        public async Task<StreetDto> CreateAsync(StreetDto entity)
        {
            CheckEntity(entity);
            Street street = _mapper.Map<Street>(entity);
            await _streetRepository.CreateAsync(street);
            return _mapper.Map<StreetDto>(street);
        }

        public ICollection<StreetDto> GetAll()
        {
            return _mapper.Map<List<Street>, ICollection<StreetDto>>(_streetRepository.Query());
        }

        public async Task<ICollection<StreetDto>> GetAllAsync()
        {
            return _mapper.Map<List<Street>, ICollection<StreetDto>>(await _streetRepository.QueryAsync());
        }

        public StreetDto? GetById(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(Id));
            return _mapper.Map<StreetDto>(_streetRepository.Query().FirstOrDefault(e => e.Id == Id));
        }

        public async Task<StreetDto?> GetByIdAsync(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(Id));
            var list = await _streetRepository.QueryAsync();
            return _mapper.Map<StreetDto>(list.FirstOrDefault(e => e.Id == Id));
        }

        public ICollection<StreetDto> GetByMatchName(string name, string country, string region, string city)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (region == null)
                throw new ArgumentNullException(nameof(region));
            if (country == null)
                throw new ArgumentNullException(nameof(country));
            if(city == null)
                throw new ArgumentNullException(nameof(city));
            if (name.Trim() == "" || region.Trim() == "" || country.Trim() == "" || city.Trim() == "")
                return new List<StreetDto>();
            var reg = _regionRepository.Query().FirstOrDefault(e => e.Country.Name == country && e.Name == region);
            if (reg == null)
                return new List<StreetDto>();
            var c = _cityRepository.Query().FirstOrDefault(e => e.Name == city);
            if (c == null)
                return new List<StreetDto>();
            string s = name.Trim().ToLower();
            var result = c.Streets.Where(e => e.Name.Trim().ToLower().Contains(s));
            return _mapper.Map<List<Street>, ICollection<StreetDto>>(result.ToList());
        }

        public async Task<ICollection<StreetDto>> GetByMatchNameAsync(string name, string country, string region, string city)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (region == null)
                throw new ArgumentNullException(nameof(region));
            if (country == null)
                throw new ArgumentNullException(nameof(country));
            if (city == null)
                throw new ArgumentNullException(nameof(city));
            if (name.Trim() == "" || region.Trim() == "" || country.Trim() == "" || city.Trim() == "")
                return new List<StreetDto>();
            var regions = await _regionRepository.QueryAsync();
            var reg = regions.FirstOrDefault(e => e.Country.Name == country && e.Name == region);
            if (reg == null)
                return new List<StreetDto>();
            var cities = await _cityRepository.QueryAsync();
            var c = cities.FirstOrDefault(e => e.Name == city);
            if (c == null) 
                return new List<StreetDto>();
            string s = name.Trim().ToLower();
            var result = new List<Street>();
            Parallel.ForEach(c.Streets, element =>
            {
                if (element.Name.Trim().Contains(s))
                    result.Add(element);
            });
            return _mapper.Map<List<Street>, ICollection<StreetDto>>(result.ToList());
        }

        public ICollection<string> GetHousesMatchName(string name, string country, string region, string city, string street)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (region == null)
                throw new ArgumentNullException(nameof(region));
            if (country == null)
                throw new ArgumentNullException(nameof(country));
            if (city == null)
                throw new ArgumentNullException(nameof(city));
            if(street == null)
                throw new ArgumentNullException(nameof(street));
            if (name.Trim() == "" || region.Trim() == "" || country.Trim() == "" || city.Trim() == "" || street.Trim() == "")
                return new List<string>();
            var reg = _regionRepository.Query().FirstOrDefault(e => e.Country.Name == country && e.Name == region);
            if (reg == null)
                return new List<string>();
            var c = _cityRepository.Query().FirstOrDefault(e => e.Name == city);
            if (c == null)
                return new List<string>();
            var str = _streetRepository.Query().Where(e => e.Name == street);
            string s = name.Trim().ToLower();
            var result = new List<string>();
            foreach (var e in str)
                if (e.NumberOfHouse != null && e.NumberOfHouse.Contains(s))
                    result.Add(e.NumberOfHouse);
            return _mapper.Map<List<string>, ICollection<string>>(result.ToList());
        }

        public async Task<ICollection<string>> GetHousesMatchNameAsync(string name, string country, string region, string city, string street)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (region == null)
                throw new ArgumentNullException(nameof(region));
            if (country == null)
                throw new ArgumentNullException(nameof(country));
            if (city == null)
                throw new ArgumentNullException(nameof(city));
            if (street == null)
                throw new ArgumentNullException(nameof(street));
            if (name.Trim() == "" || region.Trim() == "" || country.Trim() == "" || city.Trim() == "" || street.Trim() == "")
                return new List<string>();
            var regions = await _regionRepository.QueryAsync();
            var reg = regions.FirstOrDefault(e => e.Country.Name == country && e.Name == region);
            if (reg == null)
                return new List<string>();
            var cities = await _cityRepository.QueryAsync();
            var c = cities.FirstOrDefault(e => e.Name == city);
            if (c == null)
                return new List<string>();
            var streets = await _streetRepository.QueryAsync();
            var str = streets.Where(e => e.Name == street);
            string s = name.Trim().ToLower();
            var result = new List<string>();
            Parallel.ForEach(str, element =>
            {
                if (element.NumberOfHouse != null && element.NumberOfHouse.Contains(s))
                    result.Add(element.NumberOfHouse);
            });
            return _mapper.Map<List<string>, ICollection<string>>(result.ToList());
        }

        public void Remove(StreetDto entity)
        {
            CheckEntity(entity);
            if(entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            Street street = _mapper.Map<Street>(entity);
            _streetRepository.Delete(street);
        }

        public StreetDto Update(StreetDto updateEntity)
        {
            CheckEntity(updateEntity);
            if (updateEntity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(updateEntity.Id));
            Street street = _mapper.Map<Street>(updateEntity);
            _streetRepository.Update(street);
            return _mapper.Map<StreetDto>(street);
        }

        public async Task<StreetDto> UpdateAsync(StreetDto updateEntity)
        {
            CheckEntity(updateEntity);
            if (updateEntity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(updateEntity.Id));
            Street street = _mapper.Map<Street>(updateEntity);
            await _streetRepository.CreateOrUpdateAsync(street);
            return _mapper.Map<StreetDto>(street);
        }
    }
}
