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
        public void Remove(CityDto entity);
        public IEnumerable<CityDto> GetAll();
        public CityDto? GetById(Guid Id);
    }
}
