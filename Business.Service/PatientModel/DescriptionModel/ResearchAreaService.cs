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
    public class ResearchAreaService : IResearchAreaService
    {
        private readonly IResearchAreaRepository _researchAreaRepository;
        private readonly IMapper _mapper;

        public ResearchAreaService(IResearchAreaRepository researchAreaRepository, IMapper mapper)
        {
            _researchAreaRepository = researchAreaRepository;
            _mapper = mapper;
        }

        public ResearchAreaDto Create(ResearchAreaDto entity)
        {
            ResearchArea researchArea = _mapper.Map<ResearchArea>(entity);
            _researchAreaRepository.Create(researchArea);
            return _mapper.Map<ResearchAreaDto>(researchArea);
        }

        public IEnumerable<ResearchAreaDto> GetAll()
        {
            return _mapper.Map<List<ResearchArea>, IEnumerable<ResearchAreaDto>>(_researchAreaRepository.Query());
        }

        public ResearchAreaDto GetById(Guid id)
        {
            return _mapper.Map<ResearchAreaDto>(_researchAreaRepository.Query().FirstOrDefault(e => e.Id == id)); //написать запрос
        }

        public void Remove(ResearchAreaDto entity)
        {
            ResearchArea researchArea = _mapper.Map<ResearchArea>(entity);
            _researchAreaRepository.Delete(researchArea);
        }

        public ResearchAreaDto Update(ResearchAreaDto entity)
        {
            ResearchArea researchArea = _mapper.Map<ResearchArea>(entity);
            _researchAreaRepository.Update(researchArea);
            return _mapper.Map<ResearchAreaDto>(researchArea);
        }
    }
}
