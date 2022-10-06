using AutoMapper;
using Business.Enties.MedicModel.InstitutionModel;
using Business.Interop.InstitutionModel;
using Business.Repository.DataRepository.MedicModel.InstitutionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel.InstitutionModel
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        public DeviceService(IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }

        public DeviceDto Create(DeviceDto entity)
        {
            Device device = _mapper.Map<Device>(entity);
            _deviceRepository.Create(device);
            return _mapper.Map<DeviceDto>(device);
        }

        public IEnumerable<DeviceDto> GelAll()
        {
            return _mapper.Map<List<Device>, IEnumerable<DeviceDto>>(_deviceRepository.Query());
        }

        public DeviceDto GetById(Guid id)
        {
            return _mapper.Map<DeviceDto>(_deviceRepository.Query().FirstOrDefault(e => e.Id == id)); //Написать запрос
        }

        public void Remove(DeviceDto entity)
        {
            Device device = _mapper.Map<Device>(entity);
            _deviceRepository.Delete(device);
        }

        public DeviceDto Update(DeviceDto entity)
        {
            Device device = _mapper.Map<Device>(entity);
            _deviceRepository.Update(device);
            return _mapper.Map<DeviceDto>(device);
        }
    }
}
