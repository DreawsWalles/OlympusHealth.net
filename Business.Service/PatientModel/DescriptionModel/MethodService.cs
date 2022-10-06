using AutoMapper;
using Business.Enties.PatientModel.DescriptionModel;
using Business.Interop.PatientModel.DescriptionModel;
using Business.Repository.DataRepository.MedicModel;
using Business.Repository.DataRepository.PatientModel.DescriptionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel
{
    public class MethodService : IMethodService
    {
        private readonly IMethodRepository _methodRepository;
        private readonly IMapper _mapper;

        public MethodService(IMethodRepository methdRepository, IMapper mapper)
        {
            _methodRepository= methdRepository;
            _mapper = mapper;
        }

        public MethodDto Create(MethodDto entity)
        {
            Method method = _mapper.Map<Method>(entity);
            _methodRepository.Create(method);
            return _mapper.Map<MethodDto>(method);
        }

        public IEnumerable<MethodDto> GetAll()
        {
            return _mapper.Map<List<Method>, IEnumerable<MethodDto>>(_methodRepository.Query());
        }

        public MethodDto GetById(Guid id)
        {
            return _mapper.Map<MethodDto>(_methodRepository.Query().FirstOrDefault(e => e.Id == id));
        }

        public void Remove(MethodDto entity)
        {
            Method method = _mapper.Map<Method>(entity);
            _methodRepository.Delete(method);
        }

        public MethodDto Update(MethodDto entity)
        {
            Method method = _mapper.Map<Method>(entity);
            _methodRepository.Update(method);
            return _mapper.Map<MethodDto>(method);
        }
    }
}
