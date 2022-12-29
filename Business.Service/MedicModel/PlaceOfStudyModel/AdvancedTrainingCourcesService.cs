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
    public class AdvancedTrainingCourcesService : IAdvancedTrainingCourcesService
    {
        private readonly IAdvancedTrainingCoursesRepository _advancedTrainingCoursesRepository;
        private readonly IMapper _mapper;

        public AdvancedTrainingCourcesService(IAdvancedTrainingCoursesRepository advancedTrainingCoursesRepository, IMapper mapper)
        {
            _advancedTrainingCoursesRepository = advancedTrainingCoursesRepository ?? throw new ArgumentNullException(nameof(advancedTrainingCoursesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private static void CheckEntity(AdvancedTrainingCoursesDto entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));
            if (entity.Name == null || entity.Name.Trim() == "")
                throw new ArgumentNullException(nameof(entity.Name));
            if (entity.Street == null)
                throw new ArgumentNullException(nameof(entity.Street));
        }

        public AdvancedTrainingCoursesDto Create(AdvancedTrainingCoursesDto entity)
        {
            CheckEntity(entity);
            AdvancedTrainingCourses advancedTrainingCourses = _mapper.Map<AdvancedTrainingCourses>(entity);
            _advancedTrainingCoursesRepository.Create(advancedTrainingCourses);
            return _mapper.Map<AdvancedTrainingCoursesDto>(advancedTrainingCourses);
        }

        public async Task<AdvancedTrainingCoursesDto> CreateAsync(AdvancedTrainingCoursesDto entity)
        {
            CheckEntity(entity);
            AdvancedTrainingCourses advancedTrainingCourses = _mapper.Map<AdvancedTrainingCourses>(entity);
            await _advancedTrainingCoursesRepository.CreateAsync(advancedTrainingCourses);
            return _mapper.Map<AdvancedTrainingCoursesDto>(advancedTrainingCourses);
        }

        public ICollection<AdvancedTrainingCoursesDto> GetAll()
        {
            return _mapper.Map<List<AdvancedTrainingCourses>, ICollection<AdvancedTrainingCoursesDto>>(_advancedTrainingCoursesRepository.Query());
        }

        public async Task<ICollection<AdvancedTrainingCoursesDto>> GetAllAsync()
        {
            return _mapper.Map<List<AdvancedTrainingCourses>, ICollection<AdvancedTrainingCoursesDto>>(await _advancedTrainingCoursesRepository.QueryAsync());
        }

        public AdvancedTrainingCoursesDto GetById(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(Id));
            return _mapper.Map<AdvancedTrainingCoursesDto>(_advancedTrainingCoursesRepository.Query().FirstOrDefault(e => e.Id == Id)); 
        }

        public async Task<AdvancedTrainingCoursesDto> GetByIdAsync(Guid Id)
        {
            if (Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(Id));
            var list = await _advancedTrainingCoursesRepository.QueryAsync();
            return _mapper.Map<AdvancedTrainingCoursesDto>(list.FirstOrDefault(e => e.Id == Id));
        }

        public void Remove(AdvancedTrainingCoursesDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            AdvancedTrainingCourses advancedTrainingCourses = _mapper.Map<AdvancedTrainingCourses>(entity);
            _advancedTrainingCoursesRepository.Delete(advancedTrainingCourses);
        }

        public AdvancedTrainingCoursesDto Update(AdvancedTrainingCoursesDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            AdvancedTrainingCourses advancedTrainingCourses = _mapper.Map<AdvancedTrainingCourses>(entity);
            _advancedTrainingCoursesRepository.Update(advancedTrainingCourses);
            return _mapper.Map<AdvancedTrainingCoursesDto>(advancedTrainingCourses);
        }

        public async Task<AdvancedTrainingCoursesDto> UpdateAsync(AdvancedTrainingCoursesDto entity)
        {
            CheckEntity(entity);
            if (entity.Id.CompareTo(new Guid()) == 0)
                throw new ArgumentException(nameof(entity.Id));
            AdvancedTrainingCourses advancedTrainingCourses = _mapper.Map<AdvancedTrainingCourses>(entity);
            await _advancedTrainingCoursesRepository.CreateOrUpdateAsync(advancedTrainingCourses);
            return _mapper.Map<AdvancedTrainingCoursesDto>(advancedTrainingCourses);
        }
    }
}
