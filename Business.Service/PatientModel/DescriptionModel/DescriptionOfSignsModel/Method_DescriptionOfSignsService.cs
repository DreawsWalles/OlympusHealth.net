using AutoMapper;
using Business.Enties.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Business.Interop.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using Business.Repository.DataRepository.PatientModel.DescriptionModel.DescriptionOfSignsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.PatientModel.DescriptionModel.DescriptionOfSignsModel
{
    public class Method_DescriptionOfSignsService : IMethod_DescriptionOfSignsService
    {
        private readonly IMethod_DescriptionOfSignsRepository _method_DescriptionOfSignsRepository;
        private readonly IMapper _mapper;

        public Method_DescriptionOfSignsService(IMethod_DescriptionOfSignsRepository method_DescriptionOfSignsRepository, IMapper mapper)
        {
            _method_DescriptionOfSignsRepository = method_DescriptionOfSignsRepository;
            _mapper = mapper;
        }

        public Method_DescriptionOfSignsDto Create(Method_DescriptionOfSignsDto entity)
        {
            Method_DescriptionOfSigns method_DescriptionOfSigns = _mapper.Map<Method_DescriptionOfSigns>(entity);
            _method_DescriptionOfSignsRepository.Create(method_DescriptionOfSigns);
            return _mapper.Map<Method_DescriptionOfSignsDto>(entity);
        }

        public IEnumerable<Method_DescriptionOfSignsDto> GetAll()
        {
            return _mapper.Map<List<Method_DescriptionOfSigns>, IEnumerable<Method_DescriptionOfSignsDto>>(_method_DescriptionOfSignsRepository.Query());
        }

        public Method_DescriptionOfSignsDto GetById(Guid MethodId, Guid DescriptionOfSignsId)
        {
            return _mapper.Map<Method_DescriptionOfSignsDto>(_method_DescriptionOfSignsRepository.Query().FirstOrDefault(e => e.MethodId == MethodId && e.DescriptionOfSighs == DescriptionOfSignsId)); // Написать запрос
        }

        public void Remove(Method_DescriptionOfSignsDto entity)
        {
            Method_DescriptionOfSigns method_DescriptionOfSigns = _mapper.Map<Method_DescriptionOfSigns>(entity);
            _method_DescriptionOfSignsRepository.Delete(method_DescriptionOfSigns);
        }

        public Method_DescriptionOfSignsDto Update(Method_DescriptionOfSignsDto entity)
        {
            Method_DescriptionOfSigns method_DescriptionOfSigns = _mapper.Map<Method_DescriptionOfSigns>(entity);
            _method_DescriptionOfSignsRepository.Update(method_DescriptionOfSigns);
            return _mapper.Map<Method_DescriptionOfSignsDto>(method_DescriptionOfSigns);
        }
    }
}
