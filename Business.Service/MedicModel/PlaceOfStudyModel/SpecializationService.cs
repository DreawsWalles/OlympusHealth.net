using AutoMapper;
using Business.Enties.MedicModel.PlaceOfStudyModel;
using Business.Interop.PlaceOfStudyModel;
using Business.Repository.DataRepository.MedicModel.PlaceOfStudyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.MedicModel.PlaceOfStudyModel
{
    public class SpecializationService : ISpecializationService
    {
        private readonly ISpecializationRepository _specializationRepository;
        private readonly IMapper _mapper;

        public SpecializationService(ISpecializationRepository specializationRepository, IMapper mapper)
        {
            _specializationRepository = specializationRepository ?? throw new ArgumentNullException(nameof(specializationRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(specializationRepository));
        }

        private static void CheckEntity(SpecializationDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Name == null || entity.Name == "")
                throw new ArgumentNullException(nameof(entity));
        }

        public SpecializationDto Create(SpecializationDto entity)
        {
            CheckEntity(entity);
            Specialization specialization = _mapper.Map<Specialization>(entity);
            _specializationRepository.Create(specialization);
            return _mapper.Map<SpecializationDto>(specialization);
        }

        public async Task<SpecializationDto> CreateAsync(SpecializationDto entity)
        {
            CheckEntity(entity);
            Specialization specialization = _mapper.Map<Specialization>(entity);
            await _specializationRepository.CreateAsync(specialization);
            return _mapper.Map<SpecializationDto>(specialization);
        }

        public ICollection<SpecializationDto> GetAll()
        {
            return _mapper.Map<List<Specialization>, ICollection<SpecializationDto>>(_specializationRepository.Query());
        }

        public async Task<ICollection<SpecializationDto>> GetAllAsync()
        {
            return _mapper.Map<List<Specialization>, ICollection<SpecializationDto>>(await _specializationRepository.QueryAsync());
        }

        public SpecializationDto GetById(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(id));
            return _mapper.Map<SpecializationDto>(_specializationRepository.Query().FirstOrDefault(e => e.Id == id)); 
        }

        public async Task<SpecializationDto> GetByIdAsync(Guid id)
        {
            if (id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(id));
            var list = await _specializationRepository.QueryAsync();
            return _mapper.Map<SpecializationDto>(list.FirstOrDefault(e => e.Id == id));
        }

        public void Remove(SpecializationDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            Specialization specialization = _mapper.Map<Specialization>(entity);
            _specializationRepository.Delete(specialization);
        }

        public SpecializationDto Update(SpecializationDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            Specialization specialization = _mapper.Map<Specialization>(entity);
            _specializationRepository.Update(specialization);
            return _mapper.Map<SpecializationDto>(specialization);
        }

        public async Task<SpecializationDto> UpdateAsync(SpecializationDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            Specialization specialization = _mapper.Map<Specialization>(entity);
            await _specializationRepository.CreateOrUpdateAsync(specialization);
            return _mapper.Map<SpecializationDto>(specialization);
        }
    }
}
