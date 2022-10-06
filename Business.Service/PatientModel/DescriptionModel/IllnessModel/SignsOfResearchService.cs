using AutoMapper;
using Business.Enties.PatientModel.DescriptionModel.IllnessModel;
using Business.Interop.PatientModel.DescriptionModel.IllnessModel;
using Business.Repository.DataRepository.PatientModel.DescriptionModel.IllnessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel.IllnessModel
{
    public class SignsOfResearchService : ISignsOfResearchService
    {
        private readonly ISignsOfResearchRepository _signsOfResearchRepository;
        private readonly IMapper _mapper;

        public SignsOfResearchService(ISignsOfResearchRepository signsOfResearchRepository, IMapper mapper)
        {
            _signsOfResearchRepository = signsOfResearchRepository;
            _mapper = mapper;
        }

        public SignsOfResearchDto Create(SignsOfResearchDto entity)
        {
            SignsOfResearch signsOfResearch = _mapper.Map<SignsOfResearch>(entity);
            _signsOfResearchRepository.Create(signsOfResearch);
            return _mapper.Map<SignsOfResearchDto>(signsOfResearch);
        }

        public IEnumerable<SignsOfResearchDto> GetAll()
        {
            return _mapper.Map<List<SignsOfResearch>, IEnumerable<SignsOfResearchDto>>(_signsOfResearchRepository.Query());
        }

        public SignsOfResearchDto GetById(Guid Id)
        {
            return _mapper.Map<SignsOfResearchDto>(_signsOfResearchRepository.Query().FirstOrDefault(e => e.Id == Id)); //Написать запрос
        }

        public void Remove(SignsOfResearchDto entity)
        {
            SignsOfResearch signsOfResearch = _mapper.Map<SignsOfResearch>(entity);
            _signsOfResearchRepository.Delete(signsOfResearch);
        }

        public SignsOfResearchDto Update(SignsOfResearchDto entity)
        {
            SignsOfResearch signsOfResearch = _mapper.Map<SignsOfResearch>(entity);
            _signsOfResearchRepository.Update(signsOfResearch);
            return _mapper.Map<SignsOfResearchDto>(signsOfResearch);
        }
    }
}
