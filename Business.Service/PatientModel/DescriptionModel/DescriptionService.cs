using AutoMapper;
using Business.Enties.PatientModel.DescriptionModel;
using Business.Interop.PatientModel.DescriptionModel;
using Business.Repository.DataRepository.PatientModel.DescriptionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel
{
    public class DescriptionService : IDescriptionService
    {
        private readonly IDescriptionRepository _descriptionRepository;
        private readonly IMapper _mapper;

        public DescriptionService(IDescriptionRepository descriptionRepository, IMapper mapper)
        {
            _descriptionRepository = descriptionRepository ?? throw new ArgumentNullException(nameof(descriptionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public DescriptionDto Create(DescriptionDto entity)
        {
            CheckEntity(entity);
            Description description = _mapper.Map<Description>(entity);
            _descriptionRepository.Create(description);
            return _mapper.Map<DescriptionDto>(description);
        }

        private static void CheckEntity(DescriptionDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.ResultIllness == null)
                throw new ArgumentNullException(nameof(entity.ResultIllness));
            if (entity.HeadOfDepartment == null)
                throw new ArgumentNullException(nameof(entity.HeadOfDepartment));
            if (entity.Doctor == null)
                throw new ArgumentNullException(nameof(entity.Doctor));
            if (entity.Device == null)
                throw new ArgumentNullException(nameof(entity.Device));
            if (entity.Method == null)
                throw new ArgumentNullException(nameof(entity.Method));
            if (entity.ProcessDynamics == null)
                throw new ArgumentNullException(nameof(entity.ProcessDynamics));
        }

        public ICollection<DescriptionDto> GetAll()
        {
            return _mapper.Map<List<Description>, ICollection<DescriptionDto>>(_descriptionRepository.Query());
        }

        public DescriptionDto GetById(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(id));
            return _mapper.Map<DescriptionDto>(_descriptionRepository.Query().FirstOrDefault(e => e.Id == id)); 
        }

        public void Remove(DescriptionDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            Description description = _mapper.Map<Description>(entity);
            _descriptionRepository.Delete(description);
        }

        public DescriptionDto Update(DescriptionDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            Description description = _mapper.Map<Description>(entity);
            _descriptionRepository.Update(description);
            return _mapper.Map<DescriptionDto>(description);
        }

        public async Task<DescriptionDto> CreateAsync(DescriptionDto entity)
        {
            CheckEntity(entity);
            Description description = _mapper.Map<Description>(entity);
            await _descriptionRepository.CreateAsync(description);
            return _mapper.Map<DescriptionDto>(description);
        }

        public async Task<DescriptionDto> UpdateAsync(DescriptionDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            Description description = _mapper.Map<Description>(entity);
            await _descriptionRepository.CreateOrUpdateAsync(description);
            return _mapper.Map<DescriptionDto>(description);
        }

        public async Task<ICollection<DescriptionDto>> GetAllAsync()
        {
            return _mapper.Map<List<Description>, ICollection<DescriptionDto>>(await _descriptionRepository.QueryAsync());
        }

        public async Task<DescriptionDto> GetByIdAsync(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(id));
            return _mapper.Map<DescriptionDto>((await _descriptionRepository.QueryAsync()).FirstOrDefault(e => e.Id == id));
        }
    }
}
