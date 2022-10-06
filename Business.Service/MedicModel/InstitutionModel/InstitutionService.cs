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
    public class InstitutionService : IInstitutionService
    {
        private readonly IInstitutionRepository _institutionRepository;
        private readonly IMapper _mapper;

        public InstitutionService(IInstitutionRepository institutionRepository, IMapper mapper)
        {
            _institutionRepository = institutionRepository;
            _mapper = mapper;
        }

        public InstitutionDto Create(InstitutionDto entity)
        {
            Institution institution = _mapper.Map<Institution>(entity);
            _institutionRepository.Create(institution);
            return _mapper.Map<InstitutionDto>(institution);
        }

        public IEnumerable<InstitutionDto> GetAll()
        {
            return _mapper.Map<List<Institution>, IEnumerable<InstitutionDto>>(_institutionRepository.Query());
        }

        public InstitutionDto GetById(Guid Id)
        {
            return _mapper.Map<InstitutionDto>(_institutionRepository.Query().FirstOrDefault(e => e.Id == Id)); //Написать запрос
        }

        public void Remove(InstitutionDto entity)
        {
            Institution institution = _mapper.Map<Institution>(entity);
            _institutionRepository.Delete(institution);
        }

        public InstitutionDto Update(InstitutionDto entity)
        {
            Institution institution = _mapper.Map<Institution>(entity);
            _institutionRepository.Update(institution);
            return _mapper.Map<InstitutionDto>(institution);
        }
    }
}
