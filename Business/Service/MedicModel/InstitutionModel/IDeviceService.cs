using Business.Interop.InstitutionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel.InstitutionModel
{
    public interface IDeviceService
    {
        public DeviceDto Create(DeviceDto entity);
        public DeviceDto Update(DeviceDto entity);
        public void Remove(DeviceDto entity);

        public IEnumerable<DeviceDto> GelAll();
        public DeviceDto GetById(Guid id);
    }
}
