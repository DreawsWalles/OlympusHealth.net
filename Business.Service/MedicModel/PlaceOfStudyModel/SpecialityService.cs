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
    public class SpecialityService : ISpecialityService
    {
        private readonly ISpecialityRepository _specialityRepository;
        private readonly IMapper _mapper;

        public SpecialityService(ISpecialityRepository specialityRepository, IMapper mapper)
        {
            _specialityRepository = specialityRepository ?? throw new ArgumentNullException(nameof(specialityRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private static void CheckEntity(SpecialityDto entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (entity.Name == null || entity.Name.Trim() == "") ;
                throw new ArgumentNullException(nameof(entity.Name));
        }

        public SpecialityDto Create(SpecialityDto entity)
        {
            CheckEntity(entity);
            Speciality speciality = _mapper.Map<Speciality>(entity);
            _specialityRepository.Create(speciality);
            return _mapper.Map<SpecialityDto>(speciality);
        }

        public async Task<SpecialityDto> CreateAsync(SpecialityDto entity)
        {
            CheckEntity(entity);
            Speciality speciality = _mapper.Map<Speciality>(entity);
            await _specialityRepository.CreateAsync(speciality);
            return _mapper.Map<SpecialityDto>(speciality);
        }

        public ICollection<SpecialityDto> GetAll()
        {
            return _mapper.Map<List<Speciality>, ICollection<SpecialityDto>>(_specialityRepository.Query());
        }

        public async Task<ICollection<SpecialityDto>> GetAllAsync()
        {
            return _mapper.Map<List<Speciality>, ICollection<SpecialityDto>>(await _specialityRepository.QueryAsync());
        }

        public SpecialityDto GetById(Guid Id)
        {
            return _mapper.Map<SpecialityDto>(_specialityRepository.Query().FirstOrDefault(e => e.Id == Id));
        }

        public async Task<SpecialityDto> GetByIdAsync(Guid Id)
        {
            var list = await _specialityRepository.QueryAsync();
            return _mapper.Map<SpecialityDto>(list.FirstOrDefault(e => e.Id == Id));
        }

        public void Remove(SpecialityDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            Speciality speciality = _mapper.Map<Speciality>(entity);
            _specialityRepository.Delete(speciality);
        }

        public SpecialityDto Update(SpecialityDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            Speciality speciality = _mapper.Map<Speciality>(entity);
            _specialityRepository.Update(speciality);
            return _mapper.Map<SpecialityDto>(speciality);
        }

        public async Task<SpecialityDto> UpdateAsync(SpecialityDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentNullException(nameof(entity.Id));
            Speciality speciality = _mapper.Map<Speciality>(entity);
            await _specialityRepository.CreateOrUpdateAsync(speciality);
            return _mapper.Map<SpecialityDto>(speciality);
        }
    }
}
