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
        public void Remove(RegionDto entity);
        public IEnumerable<RegionDto> GetAll();
        public RegionDto? GetById(Guid Id);
    }
}
