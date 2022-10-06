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
            _specialityRepository = specialityRepository;
            _mapper = mapper;
        }

        public SpecialityDto Create(SpecialityDto entity)
        {
            Speciality speciality = _mapper.Map<Speciality>(entity);
            _specialityRepository.Create(speciality);
            return _mapper.Map<SpecialityDto>(speciality);
        }

        public IEnumerable<SpecialityDto> GetAll()
        {
            return _mapper.Map<List<Speciality>, IEnumerable<SpecialityDto>>(_specialityRepository.Query());
        }

        public SpecialityDto GetById(Guid Id)
        {
            return _mapper.Map<SpecialityDto>(_specialityRepository.Query().FirstOrDefault(e => e.Id == Id)); //Написать запрос
        }

        public void Remove(SpecialityDto entity)
        {
            Speciality speciality = _mapper.Map<Speciality>(entity);
            _specialityRepository.Delete(speciality);
        }

        public SpecialityDto Update(SpecialityDto entity)
        {
            Speciality speciality = _mapper.Map<Speciality>(entity);
            _specialityRepository.Update(speciality);
            return _mapper.Map<SpecialityDto>(speciality);
        }
    }
}
