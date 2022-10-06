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
    public class ResultIllnessService : IResultIllnessService
    {
        private readonly IResultIllnessRepository _resultIllnessRepository;
        private readonly IMapper _mapper;

        public ResultIllnessService(IResultIllnessRepository resultIllnessRepository, IMapper mapper)
        {
            _resultIllnessRepository = resultIllnessRepository;
            _mapper = mapper;
        }

        public ResultIllnessDto Create(ResultIllnessDto entity)
        {
            ResultIllness resultIllness = _mapper.Map<ResultIllness>(entity);
            _resultIllnessRepository.Create(resultIllness);
            return _mapper.Map<ResultIllnessDto>(resultIllness);
        }

        public IEnumerable<ResultIllnessDto> GetAll()
        {
            return _mapper.Map<List<ResultIllness>, IEnumerable<ResultIllnessDto>>(_resultIllnessRepository.Query());
        }

        public ResultIllnessDto GetByID(Guid Id)
        {
            return _mapper.Map<ResultIllnessDto>(_resultIllnessRepository.Query().FirstOrDefault(e => e.Id == Id)); //Написать запрос
        }

        public void Remove(ResultIllnessDto entity)
        {
            ResultIllness resultIllness = _mapper.Map<ResultIllness>(entity);
            _resultIllnessRepository.Delete(resultIllness);
        }

        public ResultIllnessDto Update(ResultIllnessDto entity)
        {
            ResultIllness resultIllness = _mapper.Map<ResultIllness>(entity);
            _resultIllnessRepository.Update(resultIllness);
            return _mapper.Map<ResultIllnessDto>(resultIllness);
        }
    }
}
