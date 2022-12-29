using Business.Interop.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Address
{
    public interface ICityService
    {
        public CityDto Create(CityDto entity);
        public CityDto Update(CityDto updateEntity);
        public ICollection<CityDto> GetByMatchName(string name,string country, string region);
        public void Remove(CityDto entity);
        public ICollection<CityDto> GetAll();
        public CityDto? GetById(Guid Id);

        public Task<CityDto> CreateAsync(CityDto entity);
        public Task<CityDto> UpdateAsync(CityDto updateEntity);
        public Task<ICollection<CityDto>> GetByMatchNameAsync(string name, string country, string region);
        public Task<ICollection<CityDto>> GetAllAsync();
        public Task<CityDto?> GetByIdAsync(Guid Id);
    }
}
