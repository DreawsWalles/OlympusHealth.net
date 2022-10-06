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
        public void Remove(StreetDto entity);
        public IEnumerable<StreetDto> GetAll();
        public StreetDto? GetById(Guid Id);
    }
}
