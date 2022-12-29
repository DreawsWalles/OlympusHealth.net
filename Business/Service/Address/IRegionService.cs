using Business.Interop.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Address
{
    public interface IRegionService
    {
        public RegionDto Create(RegionDto entity);
        public RegionDto Update(RegionDto updateEntity);
        public ICollection<RegionDto> GetByMatchName(string name, string country);
        public void Remove(RegionDto entity);
        public ICollection<RegionDto> GetAll();
        public RegionDto? GetById(Guid Id);

        public Task<RegionDto> CreateAsync(RegionDto entity);
        public Task<RegionDto> UpdateAsync(RegionDto updateEntity);
        public Task<ICollection<RegionDto>> GetByMatchNameAsync(string name, string country);
        public Task<ICollection<RegionDto>> GetAllAsync();
        public Task<RegionDto?> GetByIdAsync(Guid Id);
    }
}
