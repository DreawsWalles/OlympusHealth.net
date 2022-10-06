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
    public class StatusOfTheAttributeService : IStatusOfTheAttributeService
    {
        private readonly IStatusOfTheAttributeRepository _statusOfTheAttributeRepository;
        private readonly IMapper _mapper;

        public StatusOfTheAttributeService(IStatusOfTheAttributeRepository statusOfTheAttributeRepository, IMapper mapper)
        {
            _statusOfTheAttributeRepository = statusOfTheAttributeRepository;
            _mapper = mapper;
        }

        public StatusOfTheAttributeDto Create(StatusOfTheAttributeDto entity)
        {
            StatusOfTheAttribute statusOfTheAttribute = _mapper.Map<StatusOfTheAttribute>(entity);
            _statusOfTheAttributeRepository.Create(statusOfTheAttribute);
            return _mapper.Map<StatusOfTheAttributeDto>(statusOfTheAttribute);
        }

        public IEnumerable<StatusOfTheAttributeDto> GetAll()
        {
            return _mapper.Map<List<StatusOfTheAttribute>, IEnumerable<StatusOfTheAttributeDto>>(_statusOfTheAttributeRepository.Query());
        }

        public StatusOfTheAttributeDto GetById(Guid Id)
        {
            return _mapper.Map<StatusOfTheAttributeDto>(_statusOfTheAttributeRepository.Query().FirstOrDefault(e => e.Id == Id)); //Написать запрос
        }

        public void Remove(StatusOfTheAttributeDto entity)
        {
            StatusOfTheAttribute statusOfTheAttribute = _mapper.Map<StatusOfTheAttribute>(entity);
            _statusOfTheAttributeRepository.Delete(statusOfTheAttribute);
        }

        public StatusOfTheAttributeDto Update(StatusOfTheAttributeDto entity)
        {
            StatusOfTheAttribute statusOfTheAttribute = _mapper.Map<StatusOfTheAttribute>(entity);
            _statusOfTheAttributeRepository.Update(statusOfTheAttribute);
            return _mapper.Map<StatusOfTheAttributeDto>(statusOfTheAttribute);
        }
    }
}
