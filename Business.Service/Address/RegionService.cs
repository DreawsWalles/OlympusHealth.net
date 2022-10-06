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

        public RegionService(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        public RegionDto Create(RegionDto entity)
        {
            Region region = _mapper.Map<Region>(entity);
            _regionRepository.Create(region);
            return _mapper.Map<RegionDto>(region);
        }

        public IEnumerable<RegionDto> GetAll()
        {
            return _mapper.Map<List<Region>, IEnumerable<RegionDto>>(_regionRepository.Query());
        }

        public RegionDto? GetById(Guid Id)
        {
            return _mapper.Map<RegionDto>(_regionRepository.Query().FirstOrDefault(e => e.Id == Id)); //написать запрос
        }

        public void Remove(RegionDto entity)
        {
            Region region = _mapper.Map<Region>(entity);
            _regionRepository.Delete(region);
        }

        public RegionDto Update(RegionDto updateEntity)
        {
            Region region = _mapper.Map<Region>(updateEntity);
            _regionRepository.Update(region);
            return _mapper.Map<RegionDto>(region);
        }
    }
}
