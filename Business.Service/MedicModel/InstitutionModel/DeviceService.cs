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
            _deviceRepository = deviceRepository ?? throw new ArgumentNullException(nameof(deviceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private static void CheckEntity(DeviceDto entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            if(entity.Name == null || entity.Name.Trim() == "")
                throw new ArgumentException(nameof(entity.Name));
            if(entity.Corpus == null)
                throw new ArgumentNullException(nameof(entity.Corpus));
        }

        public DeviceDto Create(DeviceDto entity)
        {
            CheckEntity(entity);
            Device device = _mapper.Map<Device>(entity);
            _deviceRepository.Create(device);
            return _mapper.Map<DeviceDto>(device);
        }

        public async Task<DeviceDto> CreateAsync(DeviceDto entity)
        {
            CheckEntity(entity);
            Device device = _mapper.Map<Device>(entity);
            await _deviceRepository.CreateAsync(device);
            return _mapper.Map<DeviceDto>(device);
        }

        public ICollection<DeviceDto> GelAll()
        {
            return _mapper.Map<List<Device>, ICollection<DeviceDto>>(_deviceRepository.Query());
        }

        public async Task<ICollection<DeviceDto>> GelAllAsync()
        {
            return _mapper.Map<List<Device>, ICollection<DeviceDto>>(await _deviceRepository.QueryAsync());
        }

        public DeviceDto GetById(Guid id)
        {
            if(id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(id));
            return _mapper.Map<DeviceDto>(_deviceRepository.Query().FirstOrDefault(e => e.Id == id));
        }

        public async Task<DeviceDto> GetByIdAsync(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(id));
            return _mapper.Map<DeviceDto>((await _deviceRepository.QueryAsync()).FirstOrDefault(e => e.Id == id));
        }

        public void Remove(DeviceDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            Device device = _mapper.Map<Device>(entity);
            _deviceRepository.Delete(device);
        }

        public DeviceDto Update(DeviceDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            Device device = _mapper.Map<Device>(entity);
            _deviceRepository.Update(device);
            return _mapper.Map<DeviceDto>(device);
        }

        public async Task<DeviceDto> UpdateAsync(DeviceDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            Device device = _mapper.Map<Device>(entity);
            await _deviceRepository.CreateAsync(device);
            return _mapper.Map<DeviceDto>(device);
        }
    }
}
