using AutoMapper;
using Business.Enties.Address;
using Business.Interop.Address;
using Business.Repository.DataRepository.Address;
using Business.Service.Address;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Address
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        private static void CheckEntity(RegionDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Name == null || entity.Name.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Name));
            if (entity.CountryId.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.CountryId));
        }
        public RegionService(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository ?? throw new ArgumentNullException(nameof(regionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public RegionDto Create(RegionDto entity)
        {
            CheckEntity(entity);
            Region region = _mapper.Map<Region>(entity);
            _regionRepository.Create(region);
            return _mapper.Map<RegionDto>(region);
        }

        public ICollection<RegionDto> GetAll()
        {
            return _mapper.Map<List<Region>, ICollection<RegionDto>>(_regionRepository.Query());
        }

        public RegionDto? GetById(Guid Id)
        {
            if(Id.CompareTo(new Guid()) == 0) 
                throw new ArgumentException(nameof(Id));
            return _mapper.Map<RegionDto>(_regionRepository.Query().FirstOrDefault(e => e.Id == Id)); 
        }

        public void Remove(RegionDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            Region region = _mapper.Map<Region>(entity);
            _regionRepository.Delete(region);
        }

        public RegionDto Update(RegionDto updateEntity)
        {
            CheckEntity(updateEntity);
            if (updateEntity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(updateEntity.Id));
            Region region = _mapper.Map<Region>(updateEntity);
            _regionRepository.Update(region);
            return _mapper.Map<RegionDto>(region);
        }

        public ICollection<RegionDto> GetByMatchName(string name, string country)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (country == null)
                throw new ArgumentNullException(nameof(country));
            if (name.Trim() == "" || country.Trim() == "")
                return new List<RegionDto>();
            var list = _regionRepository.Query().Where(e => e.Country.Name == country);
            string s = name.Trim().ToLower();
            list.Where(e => e.Name.Trim().ToLower().Contains(s));
            return _mapper.Map<List<Region>, ICollection<RegionDto>>(list.ToList());
        }

        public async Task<RegionDto> CreateAsync(RegionDto entity)
        {
            CheckEntity(entity);
            Region region = _mapper.Map<Region>(entity);
            await _regionRepository.CreateAsync(region);
            return _mapper.Map<RegionDto>(region);
        }

        public async Task<RegionDto> UpdateAsync(RegionDto updateEntity)
        {
            CheckEntity(updateEntity);
            if (updateEntity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(updateEntity.Id));
            Region region = _mapper.Map<Region>(updateEntity);
            await _regionRepository.CreateOrUpdateAsync(region);
            return _mapper.Map<RegionDto>(region);
        }

        public async Task<ICollection<RegionDto>> GetByMatchNameAsync(string name, string country)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (country == null)
                throw new ArgumentNullException(nameof(country));
            if (name.Trim() == "" || country.Trim() == "")
                return new List<RegionDto>();
            var list = await _regionRepository.QueryAsync();
            var listCitySortRegion = new List<Region>();
            Parallel.ForEach(list, element =>
            {
                if (element.Country.Name == country)
                    listCitySortRegion.Add(element);
            });
            var result = new List<Region>();
            string s = name.Trim().ToLower();
            Parallel.ForEach(listCitySortRegion, element =>
            {
                if (element.Name.Trim().ToLower().Contains(s))
                    result.Add(element);
            });
            return _mapper.Map<List<Region>, ICollection<RegionDto>>(result.ToList());
        }

        public async Task<ICollection<RegionDto>> GetAllAsync()
        {
            return _mapper.Map<List<Region>, ICollection<RegionDto>>(await _regionRepository.QueryAsync());
        }

        public async Task<RegionDto?> GetByIdAsync(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(Id));
            var list  = await _regionRepository.QueryAsync();
            return _mapper.Map<RegionDto>(list.FirstOrDefault(e => e.Id == Id));
        }
    }
}
