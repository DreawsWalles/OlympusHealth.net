using Business.Interop.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Address
{
    public interface IStreetService
    {
        public StreetDto Create(StreetDto entity);
        public StreetDto Update(StreetDto updateEntity);
        public ICollection<StreetDto> GetByMatchName(string name, string country, string region, string city);
        public ICollection<string> GetHousesMatchName(string name, string country, string region, string city, string street);
        public void Remove(StreetDto entity);
        public ICollection<StreetDto> GetAll();
        public StreetDto? GetById(Guid Id);

        public Task<StreetDto> CreateAsync(StreetDto entity);
        public Task<StreetDto> UpdateAsync(StreetDto updateEntity);
        public Task<ICollection<StreetDto>> GetByMatchNameAsync(string name, string country, string region, string city);
        public Task<ICollection<string>> GetHousesMatchNameAsync(string name, string country, string region, string city, string street);
        public Task<ICollection<StreetDto>> GetAllAsync();
        public Task<StreetDto?> GetByIdAsync(Guid Id);
    }
}
