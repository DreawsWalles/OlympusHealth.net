using Business.Interop.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Address
{
    public interface ICountryService
    {
        public CountryDto Create(CountryDto entity);
        public CountryDto Update(CountryDto updateEntity);
        public ICollection<CountryDto> GetByMatchName(string name);
        public void Remove(CountryDto entity);
        public ICollection<CountryDto> GetAll();
        public CountryDto? GetById(Guid Id);

        public Task<CountryDto> CreateAsync(CountryDto entity);
        public Task<CountryDto> UpdateAsync(CountryDto updateEntity);
        public Task<ICollection<CountryDto>> GetByMatchNameAsync(string name);
        public Task<ICollection<CountryDto>> GetAllAsync();
        public Task<CountryDto?> GetByIdAsync(Guid Id);
    }
}
