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
    public class ResearchCategoryService : IResearchCategoryService
    {
        private readonly IResearchCategoryRepository _researchCategoryRepository;
        private readonly IMapper _mapper;

        public ResearchCategoryService(IResearchCategoryRepository researchCategoryRepository, IMapper mapper)
        {
            _researchCategoryRepository = researchCategoryRepository;
            _mapper = mapper;
        }

        public ResearchCategoryDto Create(ResearchCategoryDto entity)
        {
            ResearchCategory researchCategory = _mapper.Map<ResearchCategory>(entity);
            _researchCategoryRepository.Create(researchCategory);
            return _mapper.Map<ResearchCategoryDto>(researchCategory);
        }

        public IEnumerable<ResearchCategoryDto> GetAll()
        {
            return _mapper.Map<List<ResearchCategory>, IEnumerable<ResearchCategoryDto>>(_researchCategoryRepository.Query());
        }

        public ResearchCategoryDto GetById(Guid id)
        {
            return _mapper.Map<ResearchCategoryDto>(_researchCategoryRepository.Query().FirstOrDefault(e => e.Id == id)); //написать запрос
        }

        public void Remove(ResearchCategoryDto entity)
        {
            ResearchCategory researchCategory = _mapper.Map<ResearchCategory>(entity);
            _researchCategoryRepository.Delete(researchCategory);
        }

        public ResearchCategoryDto Update(ResearchCategoryDto entity)
        {
            ResearchCategory researchCategory = _mapper.Map<ResearchCategory>(entity);
            _researchCategoryRepository.Update(researchCategory);
            return _mapper.Map<ResearchCategoryDto>(researchCategory);
        }
    }
}
