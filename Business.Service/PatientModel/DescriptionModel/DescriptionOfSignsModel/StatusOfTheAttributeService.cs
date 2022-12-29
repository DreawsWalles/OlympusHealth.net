using AutoMapper;
using Business.Enties.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Business.Interop.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Business.Repository.DataRepository.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel.DescriptionOfSignsModel
{
    public class StatusOfTheAttributeService : IStatusOfTheAttributeService
    {
        private readonly IStatusOfTheAttributeRepository _statusOfTheAttributeRepository;
        private readonly IMapper _mapper;

        public StatusOfTheAttributeService(IStatusOfTheAttributeRepository statusOfTheAttributeRepository, IMapper mapper)
        {
            _statusOfTheAttributeRepository = statusOfTheAttributeRepository ?? throw new ArgumentNullException(nameof(statusOfTheAttributeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private static void CheckEntity(StatusOfTheAttributeDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Name == null || entity.Name.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Name));
            if (entity.DescriptionOfSigns == null)
                throw new ArgumentNullException(nameof(entity.DescriptionOfSigns));
        }

        public StatusOfTheAttributeDto Create(StatusOfTheAttributeDto entity)
        {
            CheckEntity(entity);
            StatusOfTheAttribute statusOfTheAttribute = _mapper.Map<StatusOfTheAttribute>(entity);
            _statusOfTheAttributeRepository.Create(statusOfTheAttribute);
            return _mapper.Map<StatusOfTheAttributeDto>(statusOfTheAttribute);
        }

        public async Task<StatusOfTheAttributeDto> CreateAsync(StatusOfTheAttributeDto entity)
        {
            CheckEntity(entity);
            StatusOfTheAttribute statusOfTheAttribute = _mapper.Map<StatusOfTheAttribute>(entity);
            await _statusOfTheAttributeRepository.CreateAsync(statusOfTheAttribute);
            return _mapper.Map<StatusOfTheAttributeDto>(statusOfTheAttribute);
        }

        public ICollection<StatusOfTheAttributeDto> GetAll()
        {
            return _mapper.Map<List<StatusOfTheAttribute>, ICollection<StatusOfTheAttributeDto>>(_statusOfTheAttributeRepository.Query());
        }

        public async Task<ICollection<StatusOfTheAttributeDto>> GetAllAsync()
        {
            return _mapper.Map<List<StatusOfTheAttribute>, ICollection<StatusOfTheAttributeDto>>(await _statusOfTheAttributeRepository.QueryAsync());
        }

        public StatusOfTheAttributeDto GetById(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(Id));
            return _mapper.Map<StatusOfTheAttributeDto>(_statusOfTheAttributeRepository.Query().FirstOrDefault(e => e.Id == Id));
        }

        public Task<StatusOfTheAttributeDto> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(StatusOfTheAttributeDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            StatusOfTheAttribute statusOfTheAttribute = _mapper.Map<StatusOfTheAttribute>(entity);
            _statusOfTheAttributeRepository.Delete(statusOfTheAttribute);
        }

        public StatusOfTheAttributeDto Update(StatusOfTheAttributeDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            StatusOfTheAttribute statusOfTheAttribute = _mapper.Map<StatusOfTheAttribute>(entity);
            _statusOfTheAttributeRepository.Update(statusOfTheAttribute);
            return _mapper.Map<StatusOfTheAttributeDto>(statusOfTheAttribute);
        }

        public async Task<StatusOfTheAttributeDto> UpdateAsync(StatusOfTheAttributeDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            StatusOfTheAttribute statusOfTheAttribute = _mapper.Map<StatusOfTheAttribute>(entity);
            await _statusOfTheAttributeRepository.CreateOrUpdateAsync(statusOfTheAttribute);
            return _mapper.Map<StatusOfTheAttributeDto>(statusOfTheAttribute);
        }
    }
}
