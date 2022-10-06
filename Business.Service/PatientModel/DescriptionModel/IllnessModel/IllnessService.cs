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
    public class IllnessService : IIllnessService
    {
        private readonly IIllnessRepository _llnessRepository;
        private readonly IMapper _mapper;

        public IllnessService(IIllnessRepository llnessRepository, IMapper mapper)
        {
            _llnessRepository = llnessRepository;
            _mapper = mapper;
        }

        public IllnessDto Create(IllnessDto entity)
        {
            Illness illness = _mapper.Map<Illness>(entity);
            _llnessRepository.Create(illness);
            return _mapper.Map<IllnessDto>(illness);
        }

        public IEnumerable<IllnessDto> GetAll()
        {
            return _mapper.Map<List<Illness>, IEnumerable<IllnessDto>>(_llnessRepository.Query());
        }

        public IllnessDto GetById(Guid Id)
        {
            return _mapper.Map<IllnessDto>(_llnessRepository.Query().FirstOrDefault(e => e.Id == Id)); //Написать запрос
        }

        public void Remove(IllnessDto entity)
        {
            Illness illness = _mapper.Map<Illness>(entity);
            _llnessRepository.Delete(illness);
        }

        public IllnessDto Update(IllnessDto entity)
        {
            Illness illness = _mapper.Map<Illness>(entity);
            _llnessRepository.Update(illness);
            return _mapper.Map<IllnessDto>(illness);
        }
    }
}
