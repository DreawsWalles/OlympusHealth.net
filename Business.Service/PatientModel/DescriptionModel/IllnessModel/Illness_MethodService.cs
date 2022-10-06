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
    public class Illness_MethodService : IIllness_MethodService
    {
        private readonly IIllness_MethodRepository _illness_MethodRepository;
        private readonly IMapper _mapper;

        public Illness_MethodService(IIllness_MethodRepository illness_MethodRepository, IMapper mapper)
        {
            _illness_MethodRepository = illness_MethodRepository;
            _mapper = mapper;
        }

        public Illness_MethodDto Create(Illness_MethodDto entity)
        {
            Illness_Method illness_Method = _mapper.Map<Illness_Method>(entity);
            _illness_MethodRepository.Create(illness_Method);
            return _mapper.Map<Illness_MethodDto>(illness_Method);
        }

        public IEnumerable<Illness_MethodDto> GetAll()
        {
            return _mapper.Map<List<Illness_Method>, IEnumerable<Illness_MethodDto>>(_illness_MethodRepository.Query());
        }

        public Illness_MethodDto GetById(Guid IllnessId, Guid MethodId)
        {
            return _mapper.Map<Illness_MethodDto>(_illness_MethodRepository.Query().FirstOrDefault(e => (e.MethodId == MethodId || e.IllnessId == IllnessId))); //Написать запрос
        }

        public void Remove(Illness_MethodDto entity)
        {
            Illness_Method illness_Method = _mapper.Map<Illness_Method>(entity);
            _illness_MethodRepository.Delete(illness_Method);
        }

        public Illness_MethodDto Update(Illness_MethodDto entity)
        {
            Illness_Method illness_Method = _mapper.Map<Illness_Method>(entity);
            _illness_MethodRepository.Update(illness_Method);
            return _mapper.Map<Illness_MethodDto>(illness_Method);
        }
    }
}
