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
            _specializationRepository = specializationRepository;
            _mapper = mapper;
        }

        public SpecializationDto Create(SpecializationDto entity)
        {
            Specialization specialization = _mapper.Map<Specialization>(entity);
            _specializationRepository.Create(specialization);
            return _mapper.Map<SpecializationDto>(specialization);
        }

        public IEnumerable<SpecializationDto> GetAll()
        {
            return _mapper.Map<List<Specialization>, IEnumerable<SpecializationDto>>(_specializationRepository.Query());
        }

        public SpecializationDto GetById(Guid id)
        {
            return _mapper.Map<SpecializationDto>(_specializationRepository.Query().FirstOrDefault(e => e.Id == id)); //Написать запрос
        }

        public void Remove(SpecializationDto entity)
        {
            Specialization specialization = _mapper.Map<Specialization>(entity);
            _specializationRepository.Delete(specialization);
        }

        public SpecializationDto Update(SpecializationDto entity)
        {
            Specialization specialization = _mapper.Map<Specialization>(entity);
            _specializationRepository.Update(specialization);
            return _mapper.Map<SpecializationDto>(specialization);
        }
    }
}
