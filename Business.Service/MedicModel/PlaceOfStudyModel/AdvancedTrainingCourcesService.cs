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
            _advancedTrainingCoursesRepository = advancedTrainingCoursesRepository;
            _mapper = mapper;
        }

        public AdvancedTrainingCoursesDto Create(AdvancedTrainingCoursesDto entity)
        {
            AdvancedTrainingCourses advancedTrainingCourses = _mapper.Map<AdvancedTrainingCourses>(entity);
            _advancedTrainingCoursesRepository.Create(advancedTrainingCourses);
            return _mapper.Map<AdvancedTrainingCoursesDto>(advancedTrainingCourses);
        }

        public IEnumerable<AdvancedTrainingCoursesDto> GetAll()
        {
            return _mapper.Map<List<AdvancedTrainingCourses>, IEnumerable<AdvancedTrainingCoursesDto>>(_advancedTrainingCoursesRepository.Query());
        }

        public AdvancedTrainingCoursesDto GetBuId(Guid Id)
        {
            return _mapper.Map<AdvancedTrainingCoursesDto>(_advancedTrainingCoursesRepository.Query().FirstOrDefault(e => e.Id == Id)); //Написать запрос
        }

        public void Remove(AdvancedTrainingCoursesDto entity)
        {
            AdvancedTrainingCourses advancedTrainingCourses = _mapper.Map<AdvancedTrainingCourses>(entity);
            _advancedTrainingCoursesRepository.Delete(advancedTrainingCourses);
        }

        public AdvancedTrainingCoursesDto Update(AdvancedTrainingCoursesDto entity)
        {
            AdvancedTrainingCourses advancedTrainingCourses = _mapper.Map<AdvancedTrainingCourses>(entity);
            _advancedTrainingCoursesRepository.Update(advancedTrainingCourses);
            return _mapper.Map<AdvancedTrainingCoursesDto>(advancedTrainingCourses);
        }
    }
}
