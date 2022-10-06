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
        public void Remove(CountryDto entity);
        public IEnumerable<CountryDto> GetAll();
        public CountryDto? GetById(Guid Id);
    }
}
